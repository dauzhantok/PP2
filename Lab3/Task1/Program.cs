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

        public FarMan() //constructor with default path
        {
            dir = new DirectoryInfo(@"C:\Users\dauzh\Desktop\");
            vse = dir.GetFileSystemInfos();
        }
        FarMan(string path)//Constructor with custom path
        {
            dir = new DirectoryInfo(path);

        }
        public void Start()
        {
            while (true)
            {
                Show();//Shows contents of the folder
                ConsoleKeyInfo key = Console.ReadKey();//reads a key to know what to do next

                if (key.Key == ConsoleKey.Escape)
                {
                    break;//quits the loop and porgram ends
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == vse.Length)// moves cursor down
                        cursor = 0;
                }
                else if (key.Key == ConsoleKey.UpArrow)//moves cursor up
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = vse.Length - 1;
                }
                else if (key.Key == ConsoleKey.Backspace)//changes current directory to upper directory
                {
                    cursor = 0;
                    dir = new DirectoryInfo(dir.Parent.FullName);//upper directory is parent so we change our path to the parent
                }
                else if (key.Key == ConsoleKey.Enter)//Enters selected directory or opens file
                {
                    if (vse[cursor].GetType() == typeof(DirectoryInfo))//changes current directory if selected item is a folder    
                    {
                        dir = new DirectoryInfo(vse[cursor].FullName);
                        cursor = 0;
                    }
                    else// opens a file
                    {
                        string content = File.ReadAllText(vse[cursor].FullName);
                        Cleaner();
                        Console.WriteLine(content);
                        Console.ReadKey();
                    }

                }
                else if (key.Key == ConsoleKey.F2)//renames file or directory
                {
                    Cleaner();
                    string name = Console.ReadLine();//gets the future name of the file/directory
                    string path = Path.GetDirectoryName(vse[cursor].FullName);
                    if (vse[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        Directory.Move(vse[cursor].FullName, Path.Combine(path, name));//just move it to the same directory with name changing
                    }
                    else
                    {
                        string ext = Path.GetExtension(vse[cursor].FullName);//get file's extension to add it later
                        File.Move(vse[cursor].FullName, Path.Combine(path, name + ext));//combines current path, new file name and extension
                    }

                    cursor = 0;
                }
                else if (key.Key == ConsoleKey.F5)
                    continue;
                else if (key.Key == ConsoleKey.Delete)//function to delete file
                {
                    if (vse[cursor].GetType() == typeof(FileInfo))
                        File.Delete(vse[cursor].FullName);//if it is a file it just deletes it
                    else
                    {
                        Remove(vse[cursor].FullName);//if it is directory initialize a function
                    }
                }
            }
        }
        public void Show()//function to show all directories and files in the current folder
        {
            Cleaner();

            vse = dir.GetFileSystemInfos();//get list of files and directories in current folder
            vse = SorterDaDaYa(vse);
            for (int i = 0; i < vse.Length; i++)//checks every item in vse to color console
            {
                if (i == cursor)//colors selected item
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (vse[i].GetType() == typeof(DirectoryInfo))//colors folder
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else// colors files
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.WriteLine(vse[i]);//print name of the file/directory
            }
        }
        public void Remove(string path)//function to delete folders
        {
            try//tries to delete folder if it is empty
            {
                Directory.Delete(path);
            }
            catch//if did not delete the folder it deletes everything inside
            {
                DirectoryInfo Dir = new DirectoryInfo(path);//we do this to get information about files inside the folder we want to delete
                foreach (DirectoryInfo a in Dir.GetDirectories())
                {
                    Remove(a.FullName);//if it is a directory we use function again
                }
                foreach (FileInfo file in Dir.GetFiles())
                {
                    File.Delete(file.FullName);//just delets it if it is a file
                }
            }
      
        }
        public void Cleaner()//cleans console
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
        public FileSystemInfo[] SorterDaDaYa(FileSystemInfo[] Da)
        {
            bool conti = true;
            FileSystemInfo Ya;
            while (conti)
            {
                conti = false;
                for (int i = 1; i < vse.Length; i++)
                {


                    if (Da[i].GetType() == typeof(DirectoryInfo) && Da[i - 1].GetType() == typeof(FileInfo))
                    {
                        Ya = Da[i];
                        Da[i] = Da[i - 1];
                        Da[i - 1] = Ya;
                        conti = true;
                    }
                }
            }
            return Da;
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