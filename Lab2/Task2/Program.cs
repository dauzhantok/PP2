using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream(@"C:\Users\dauzh\Desktop\PP2\Lab2\Task2\TextFile1.txt", FileMode.Open, FileAccess.Read); //open to read
            StreamReader sr = new StreamReader(file);//read stream
            FileStream sec  = new FileStream(@"C:\Users\dauzh\Desktop\PP2\Lab2\Task2\TextFile2.txt", FileMode.Open, FileAccess.Write);//open to write
            StreamWriter sw = new StreamWriter(sec);//write
            string[] st = sr.ReadLine().Split(' ');
            int[] arr = new int[100000];
            for (int i = 0; i < st.Length; i++)
            {
                arr[i] = Convert.ToInt32(st[i]);
                if (Prim(arr[i]))//lab1 task1
                {
                    sw.Write(arr[i] + " ");
                }
                else continue;
            }
            sw.Close();
            sec.Close();
        }
        public static bool Prim(int arr)// lab1 Task1
        {
            if (arr == 1)
                return false;
            double nu = Math.Sqrt(arr);
            double n = Math.Round(nu);
            for (int i = 2; i <= n; i++)
            {
                if (arr % i == 0)
                    return false;
            }
            return true;

        }
    }
}