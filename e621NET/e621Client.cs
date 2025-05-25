using System;
using System.IO;

using System.Net;
using System.Net.Http;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using e621NET.Data.Posts;
using System.Web;
using System.Text.Json;
using HtmlAgilityPack;
using System.ComponentModel.Design;

namespace e621NET
{
    public class e621Client : HttpClientHandler
    {
        #region Variables
        public static readonly HttpClient HttpClient;
        public static e621Client Current { get; private set; }
    
        public static bool DebugMode { get; set; }

        public string Host { get; set; }
        public e621ClientOptions Options { get; private set; }
        internal List<e621ClientHeader> DefaultHeaders { get; private set; } = new List<e621ClientHeader>();
        
        static e621Client()
        {
            Current = new e621Client();
            HttpClient = new HttpClient(Current, disposeHandler: true)
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        e621Client() : base()
        {
            Host = "https://e621.net/";
            Options = new e621ClientOptions();

            Initialize();
        }

        public e621Client(e621ClientOptions options) : base()
        {
            Host = options.HostUri;
            Options = options;

            Initialize();
        }

        private void Initialize()
        {
            DefaultHeaders = new List<e621ClientHeader>() { 
                new e621ClientHeader("User-Agent", Options.UserAgent)
            };

            if (Options.Credentials != null)
                AddCredentials(Options.Credentials);
        }

        public void AddCredentials(e621APICredentials credentials)
        {
            Options.Credentials = credentials;
            if (DefaultHeaders.Exists(val => val.Name == "Authorization"))
            {
                var header = DefaultHeaders.Find(val => val.Name == "Authorization");
                if(header != null)
                    DefaultHeaders.Remove(header);
            }
            DefaultHeaders.Add(new e621ClientHeader("Authorization", BTOA($"{Options.Credentials.Username}:{Options.Credentials.APIKey}")));
        }

        private static string BTOA(string toEncode)
        {
            var bytes = Encoding.GetEncoding(28591).GetBytes(toEncode);
            var toReturn = Convert.ToBase64String(bytes);
            return toReturn;
        }

        const int POSTS_HARD_LIMIT = 320;
        public async Task<ePosts?> GetPostsAsync(string? tags = null, int page = 1, int limit = -1)
        {
            var postsUrl = GetUri(Host, "posts.json");
            var postsHtmlUrl = GetUri(Host, "posts");

            string? queryString = null;
            if (!string.IsNullOrWhiteSpace(tags))
                queryString = $"tags={HttpUtility.UrlEncode(tags)}";
            if (page > 1)
                queryString += $"&page={page}";
            if (limit > 0)
                queryString += $"&limit={limit}";
            if (limit > POSTS_HARD_LIMIT)
                throw new e621ClientException(ClientErrorType.Internal, "The posts maximum limit is 320");

            if (queryString != null)
            {
                postsUrl += "?" + queryString;
                postsHtmlUrl += "?" + queryString;
            }

            var response =  await RequestAsync(ClientRequestType.GET, postsUrl, CombineHeaders(DefaultHeaders, DefaultHeaders), HandleStringResponse);
            if (response.IsContentFetched)
            {
                if(response.Content == null)
                    throw new e621ClientException(ClientErrorType.Network, "The server doesn't return a valid response");

                try
                {
                    ePosts? posts = JsonSerializer.Deserialize<ePosts>(response.Content);
                    if (posts == null)
                        throw new e621ClientException(ClientErrorType.Deserialization, "The server returns a non-post type response") { Content = response.Content };

                    posts.Query = tags ?? "";
                    posts.Limit = limit;
                    posts.Page = page;

                    try
                    {
                        response = await RequestAsync(ClientRequestType.GET, postsHtmlUrl, CombineHeaders(DefaultHeaders, DefaultHeaders), HandleStringResponse);
                        if (response.IsContentFetched)
                        {
                            if (response.Content == null)
                                throw new e621ClientException(ClientErrorType.Network, "The server doesn't return a valid response");

                            var document = new HtmlDocument();
                            document.LoadHtml(response.Content);

                            var paginator = document.DocumentNode.SelectSingleNode("/html/body/div[1]/div[3]/div/div/div[3]/div[4]/nav");
                            if (paginator == null)
                                throw new e621ClientException(ClientErrorType.Deserialization, "The server returns a non-post type response") { Content = response.Content };

                            var nodes = new List<HtmlNode>(paginator.ChildNodes);
                            var lastNode = nodes.FindLast(val => val.GetAttributeValue("class", "none") == "page last" || val.GetAttributeValue("class", "none") == "page current");
                            if (lastNode == null)
                                throw new e621ClientException(ClientErrorType.Deserialization, "The server returns a non-post type response") { Content = response.Content };

                            posts.MaxPage = int.Parse(lastNode.ChildNodes[0].InnerText);
                        }
                    }
                    catch { }

                    return posts;
                }
                catch (Exception e)
                {
                    throw new e621ClientException(ClientErrorType.Deserialization, e.Message) { Content = response.Content };
                }
            }
            
            throw new e621ClientException(ClientErrorType.Network, "The server doesn't return a valid response");
        }

        public async Task<ePosts> GetPoolPostsAsync(int id, int page = 1)
        {
            var postsUrl = GetUri(Host, "pools/" + id);

            if (page > 1)
                postsUrl += $"?page={page}";

            var response = await RequestAsync(ClientRequestType.GET, postsUrl, CombineHeaders(DefaultHeaders, DefaultHeaders), HandleStringResponse);
            if (response.IsContentFetched)
            {
                if (response.Content == null)
                    throw new e621ClientException(ClientErrorType.Network, "The server doesn't return a valid response");

                try
                {
                    var document = new HtmlDocument();
                    document.LoadHtml(response.Content);

                    var posts = new ePosts
                    {
                        Mode = ListMode.Pools,
                        PoolId = id,
                        Page = page,
                        MaxPage = 750
                    };

                    var listNode = document.DocumentNode.SelectSingleNode("//*[@id=\"posts\"]/section");
                    if (listNode == null)
                        throw new e621ClientException(ClientErrorType.Deserialization, "The server doesn't return a valid list") { Content = response.Content };

                    var paginator = document.DocumentNode.SelectSingleNode("//*[@id=\"c-pools\"]/div[2]/menu");
                    if (paginator == null)
                        throw new e621ClientException(ClientErrorType.Deserialization, "The server returns a non-post type response") { Content = response.Content };

                    var nodes = new List<HtmlNode>(paginator.ChildNodes);
                    var lastNode = nodes.FindLast(val => val.GetAttributeValue("class", "none") == "numbered-page" || val.GetAttributeValue("class", "none") == "current-page");
                    if (lastNode == null)
                        throw new e621ClientException(ClientErrorType.Deserialization, "The server returns a non-post type response") { Content = response.Content };

                    posts.MaxPage = int.Parse(lastNode.ChildNodes[0].InnerText);

                    foreach (var node in listNode.ChildNodes)
                    {
                        if (node.Name != "article")
                            continue;

                        try
                        {
                            var post = new ePost
                            {
                                IsPartial = true,
                                Id = node.GetAttributeValue("data-id", 0),
                                Tags = new eTags()
                            };

                            post.Rating = node.GetAttributeValue("data-rating", "s");
                            post.FavCount = node.GetAttributeValue("data-fav-count", 0);
                            post.Preview.Url = node.GetAttributeValue("data-preview-url", "");
                            post.Preview.Width = node.GetAttributeValue("data-preview-width", 0);
                            post.Preview.Height = node.GetAttributeValue("data-preview-height", 0);
                            post.Sample.Url = node.GetAttributeValue("data-large-url", "");

                            post.File.Url = node.GetAttributeValue("data-file-url", "");
                            post.Score = new eScore
                            {
                                Total = node.GetAttributeValue("data-score", 0),
                            };

                            string[] tags = node.GetAttributeValue("data-tags", "").Split(' ');
                            post.Tags.General.AddRange(tags);

                            posts.Posts.Add(post);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Unable to read a post: {ex.Message}");
                        }
                    }

                    return posts;
                }
                catch (Exception e)
                {
                    throw new e621ClientException(ClientErrorType.Deserialization, e.Message) { Content = response.Content };
                }
            }
            else
            {
                throw new e621ClientException(ClientErrorType.Network, "The server doesn't return a valid response");
            }
        }
        #endregion

        #region Main Methods
        internal Task<e621ClientResponse> GetStringAsync(e621ClientRequest request) =>
            RequestAsync(ClientRequestType.GET, GetUri(Host, request.RelativeUrl), CombineHeaders(DefaultHeaders, request.Headers), HandleStringResponse);
        internal Task<e621ClientResponse> GetStringAsync(string relativeUrl) =>
            RequestAsync(ClientRequestType.GET, GetUri(Host, relativeUrl), CombineHeaders(DefaultHeaders, DefaultHeaders), HandleStringResponse);
        internal Task<e621ClientResponse> GetBytesAsync(e621ClientRequest request) =>
            RequestAsync(ClientRequestType.GET, GetUri(Host, request.RelativeUrl), CombineHeaders(DefaultHeaders, request.Headers), HandleBytesResponse);
        internal Task<e621ClientResponse> GetBytesAsync(string relativeUrl) =>
            RequestAsync(ClientRequestType.GET, GetUri(Host, relativeUrl), CombineHeaders(DefaultHeaders, DefaultHeaders), HandleBytesResponse);
        internal Task<e621ClientResponse> PostStringAsync(e621ClientRequest request, HttpContent content) =>
            RequestAsync(ClientRequestType.POST, content, GetUri(Host, request.RelativeUrl), CombineHeaders(DefaultHeaders, request.Headers), HandleStringResponse);
        internal Task<e621ClientResponse> PostStringAsync(string relativeUrl, HttpContent content) =>
            RequestAsync(ClientRequestType.POST, content, GetUri(Host, relativeUrl), CombineHeaders(DefaultHeaders, DefaultHeaders), HandleStringResponse);
        internal Task<e621ClientResponse> PostBytesAsync(e621ClientRequest request, HttpContent content) =>
            RequestAsync(ClientRequestType.POST, content, GetUri(Host, request.RelativeUrl), CombineHeaders(DefaultHeaders, request.Headers), HandleBytesResponse);
        internal Task<e621ClientResponse> PostBytesAsync(string relativeUrl, HttpContent content) =>
            RequestAsync(ClientRequestType.POST, content, GetUri(Host, relativeUrl), CombineHeaders(DefaultHeaders, DefaultHeaders), HandleBytesResponse);
        #endregion

        #region Uri
        public static string GetUri(string host, string relative)
        {
            Uri baseUri = new Uri(host);
            Uri myUri = new Uri(baseUri, relative);
            return myUri.AbsoluteUri;
        }

        public static Uri GetRawUri(string host, string relative)
        {
            Uri baseUri = new Uri(host);
            Uri myUri = new Uri(baseUri, relative);
            return myUri;
        }
        #endregion

        #region Request Methods
        internal static async Task<e621ClientResponse> RequestAsync(ClientRequestType type, string _url, List<e621ClientHeader> headers, Func<HttpResponseMessage, Task<e621ClientResponse>> responseHandler) =>
            await RequestAsync(type, new StringContent(""), _url, headers, responseHandler);
        internal static async Task<e621ClientResponse> RequestAsync(ClientRequestType type, HttpContent content, string _url, List<e621ClientHeader> headers, Func<HttpResponseMessage, Task<e621ClientResponse>> responseHandler)
        {
            if (DebugMode) ExConsole.PrettyPrint(ConsoleColor.Magenta, $"{type.ToString("G")}: ", _url);
            using (HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    // Set headers
                    foreach (var header in headers)
                    {
                        if (header.IsSingle)
                            client.DefaultRequestHeaders.TryAddWithoutValidation(header.Name, header.SingleValue);
                        else
                            client.DefaultRequestHeaders.Add(header.Name, header.Values);
                    }

                    // Send the GET request
                    HttpResponseMessage response = type == ClientRequestType.GET ? await client.GetAsync(_url) : await client.PostAsync(_url, content);
                    return response.IsSuccessStatusCode ? await responseHandler.Invoke(response) : new e621ClientResponse(response);
                }
            }
        }
        #endregion

        #region Handlers
        internal static async Task<e621ClientResponse> HandleStringResponse(HttpResponseMessage response)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();
            if (DebugMode) ExConsole.PrettyPrint(ConsoleColor.Green, "RESPONSE: ", content);

            // Take headers
            var respHeaders = response.Headers.ToArray();
            var list = new List<e621ClientHeader>();
            foreach (var key in respHeaders)
                list.Add(new e621ClientHeader(key));

            return new e621ClientResponse(true, content, list, response);
        }

        internal static async Task<e621ClientResponse> HandleBytesResponse(HttpResponseMessage response)
        {
            // Read the response content as bytes
            byte[] content = await response.Content.ReadAsByteArrayAsync();

            // Take headers
            var respHeaders = response.Headers.ToArray();
            var list = new List<e621ClientHeader>();
            foreach (var key in respHeaders)
                list.Add(new e621ClientHeader(key));
            return new e621ClientResponse(true, content, list, response);
        }
        #endregion

        #region Utility
        internal static List<e621ClientHeader> CombineHeaders(List<e621ClientHeader> Default, List<e621ClientHeader> Override)
        {
            var list = new List<e621ClientHeader>(Default);
            foreach (var value in Override)
            {
                var header = list.Find(val => val.Name.ToLower() == value.Name.ToLower());
                if (header != null)
                {
                    list.Remove(header);
                    list.Add(value);
                }
                else
                {
                    list.Add(value);
                }
            }
            return list;
        }
        #endregion
    }

    #region Ripper Classes
    [Serializable]
    internal class e621ClientHeader
    {
        public string Name { get; set; }
        public bool IsSingle { get; private set; }
        public string? SingleValue { get; set; }
        public List<string> Values { get; set; } = new List<string>();

        public e621ClientHeader(string name, string value)
        {
            Name = name;
            IsSingle = true;
            SingleValue = value;
            Values.Add(value);
        }
        public e621ClientHeader(string name, List<string> values)
        {
            IsSingle = false;
            Name = name;
            Values = values;
        }
        public e621ClientHeader(KeyValuePair<string, IEnumerable<string>> valuePair)
        {
            Name = valuePair.Key;
            foreach (var value in valuePair.Value)
                Values.Add(value);
        }
    }

    [Serializable]
    internal class e621ClientRequest
    {
        public string RelativeUrl { get; set; }
        internal List<e621ClientHeader> Headers { get; set; } = new List<e621ClientHeader>();

        public e621ClientRequest(string url, List<e621ClientHeader> headers)
        {
            RelativeUrl = url;
            Headers = headers;
        }
    }

    [Serializable]
    internal class e621ClientResponse
    {
        public RipperResponseType ResponseType { get; private set; }
        public bool IsContentFetched { get; private set; }
        public string? Content { get; private set; }
        public byte[]? Bytes { get; private set; }
        internal List<e621ClientHeader> Headers { get; private set; } = new List<e621ClientHeader>();
        public HttpResponseMessage? Message { get; private set; }

        public e621ClientResponse() { }
        public e621ClientResponse(HttpResponseMessage msg)
        {
            ResponseType = RipperResponseType.Error;
            Message = msg;
        }

        internal e621ClientResponse(bool isFetched, string text, List<e621ClientHeader> headers, HttpResponseMessage msg)
        {
            ResponseType = RipperResponseType.String;
            IsContentFetched = isFetched;
            Headers = headers;
            Content = text;
            Message = msg;
        }

        internal e621ClientResponse(bool isFetched, byte[] bytes, List<e621ClientHeader> headers, HttpResponseMessage msg)
        {
            ResponseType = RipperResponseType.Byte;
            IsContentFetched = isFetched;
            Headers = headers;
            Bytes = bytes;
            Message = msg;
        }
    }

    [Serializable]
    public class e621ClientException : Exception
    {
        public ClientErrorType ErrorType = ClientErrorType.Internal;
        public string? Content;

        public e621ClientException(string message) : base(message) { }
        public e621ClientException(ClientErrorType type, string message) : base(message) 
        { 
            ErrorType = type;
        }
    }
    #endregion

    #region Ripper Enums
    public enum ClientErrorType
    {
        Network,
        Internal,
        Deserialization
    }

    internal enum ClientRequestType
    {
        GET,
        POST
    }

    internal enum RipperResponseType
    {
        Error,
        String,
        Byte
    }
    #endregion
}
