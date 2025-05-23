using System;
using System.IO;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using e621NET;
using e621NET.Data.Posts;

namespace eBrowser;

public partial class MainWindow : Window
{
    readonly HomePage _homePage = new HomePage();
    readonly ListPage _listPage = new ListPage();
    readonly ViewPage _viewPage = new ViewPage();
    
    public MainWindow()
    {
        InitializeComponent();
        if (File.Exists("posts.json".ToPersistPath()))
        {
            var posts = JsonSerializer.Deserialize<ePosts>(File.ReadAllText("posts.json".ToPersistPath()));
            _listPage.SetPosts(posts!);
            Content = _listPage;
        }
        else
        {
            Content = _homePage;
        }

        _homePage.onSearchFinished += HomePageSearchFinished;
        _listPage.PostClicked += ListPageOnPostClicked;
        _viewPage.onBackPressed += ViewPageOnBackPressed;
    }
    
    void ViewPageOnBackPressed()
    {
        Content = _listPage;
    }

    void ListPageOnPostClicked(object? sender, PostClickedArgs e)
    {
        _viewPage.LoadPost(e.Posts, e.Index);
        Content = _viewPage;
    }

    void HomePageSearchFinished(ePosts obj)
    {
        Content = _listPage;
        _listPage.SetPosts(obj);
    }
}
