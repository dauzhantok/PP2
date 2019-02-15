using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
    public class FarMan
    {
        int cursor;
        DirectoryInfo dir;
        public static FileSystemInfo[] vse;
        public FarMan()
        {
            dir = new DirectoryInfo(@"C:\Users\dauzh\Desktop\");
            vse = dir.GetFileSystemInfos();
        }
        FarMan(string path)
        {
            dir = new DirectoryInfo(path);

        }
        public void Start()
        {
            while (true)
            {
                Show();
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == vse.Length)
                        cursor = 0;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = vse.Length - 1;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    cursor = 0;
                    dir = new DirectoryInfo(dir.Parent.FullName);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (vse[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        dir = new DirectoryInfo(vse[cursor].FullName);
                        cursor = 0;
                    }
                    else
                    {
                        string content = File.ReadAllText(vse[cursor].FullName);
                        Cleaner();
                        Console.WriteLine(content);
                        Console.ReadKey();
                    }

                }
            }
        }
        public void Show()
        {
            Cleaner();
            vse = dir.GetFileSystemInfos();
            for (int i = 0; i < vse.Length; i++)
            {
                if (i == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (vse[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.WriteLine(vse[i]);
            }
        }
        public void Cleaner()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FarMan DaDaYa = new FarMan();
            DaDaYa.Start();

        }
    }
}