using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = System.IO.Path.GetRandomFileName();
            string path = System.IO.Path.Combine(@"C:\Users\dauzh\Desktop\PP2\Lab2\Task4\", filename);
            Console.WriteLine(path);
            string path1 = @"C:\Users\dauzh\Desktop\PP2\Lab2\Task4\Path\";
            FileStream file = System.IO.File.Create(path);
            file.Close();
            System.IO.File.Move(path, path1 + filename);
            Console.ReadKey();
        }
    }
}