using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    public class FarMan
    {
        int cursor;
        DirectoryInfo dir;
        public static FileSystemInfo[] vse;
        public FarMan()
        {
            dir = new DirectoryInfo(@"C:\Users\dauzh\Desktop\HW");
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
                else if (key.Key == ConsoleKey.F2)
                {
                    Cleaner();
                    string name = Console.ReadLine();
                    string path = Path.GetDirectoryName(vse[cursor].FullName);
                    if (vse[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        Directory.Move(vse[cursor].FullName, Path.Combine(path, name));
                    }
                    else
                    {
                        string ext = Path.GetExtension(vse[cursor].FullName);
                        File.Move(vse[cursor].FullName, Path.Combine(path, name + ext));
                    }

                    cursor = 0;
                }
                else if (key.Key == ConsoleKey.F5)
                    continue;
                else if (key.Key == ConsoleKey.Delete)
                {
                    if (vse[cursor].GetType() == typeof(FileInfo))
                        File.Delete(vse[cursor].FullName);
                    else
                    {
                        Remove(vse[cursor].FullName);
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
        public void Remove(string path)
        {
            bool Is_Deleted = true;
            try
            {
                Directory.Delete(path);
                Is_Deleted = false;
            }
            catch
            {
                DirectoryInfo Dir = new DirectoryInfo(path);
                foreach (DirectoryInfo a in Dir.GetDirectories())
                {
                    Remove(a.FullName);
                }
                foreach (FileInfo file in Dir.GetFiles())
                {
                    File.Delete(file.FullName);
                }
            }
            finally
            {
                if (Is_Deleted)
                    Directory.Delete(path);
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