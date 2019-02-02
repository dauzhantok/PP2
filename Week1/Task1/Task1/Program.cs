using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            num = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[num];
            for (int i = 0; i < num; i++)
            {

                string str = Console.ReadLine();

                string[] nums = str.Split(' ');
                arr[i] = Convert.ToInt32(Console.ReadKey());
            }

            for (int i = 0; i < num; i++)
            {
                Console.Write(arr[i] + " " + arr[i] + " ");

            }
        }
    }
}
