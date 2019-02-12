using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            num = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[num];
            string[] st = Console.ReadLine().Split(new char[] { ' ' });
            for (int i = 0; i < num; i++)
            {

                arr[i] = Convert.ToInt32(st[i]);
            }
            for (int i = 0; i < num; i++)
            {
                Console.Write(arr[i] + " " + arr[i] + " ");
            }
        }
    }
}
