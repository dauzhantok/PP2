using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            FileStream file = new FileStream(@"C:\Users\dauzh\Desktop\PP2\Lab2\Task1\TextFile.txt", FileMode.Open, FileAccess.Read);//location of documebt
            StreamReader sr = new StreamReader(file); // read
            string st = sr.ReadLine();//st now have text that was in document
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] != st[st.Length - n])// chek first and last element
                {
                    Console.WriteLine("No");
                    break;// finish 
                }
                else n++;//last letter move left
            }
            Console.WriteLine("Yes");
            

        }
    }
}