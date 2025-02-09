using System;

namespace e621NET
{
    public static class ExConsole
    {
        public static void PrettyPrint(ConsoleColor start, ConsoleColor end, string header, string info)
        {
            Console.ForegroundColor = start;
            Console.Write(header);
            Console.ForegroundColor = end;
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrettyPrintRev(ConsoleColor color, string header, string info)
        {
            Console.Write(header);
            Console.ForegroundColor = color;
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrettyPrint(ConsoleColor color, string header, string info)
        {
            Console.ForegroundColor = color;
            Console.Write(header);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(info);
        }
    }
}
