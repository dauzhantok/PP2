﻿using System;
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
            int n;
            n = Convert.ToInt32(Console.ReadLine());// convert in to number
            string[] st = Console.ReadLine().Split(' ');// do an arry where ' '
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(st[i]);
                if (Prim(arr[i]) == true)// if prim out
                    Console.Write(arr[i] + " ");
                else continue;
            }

        }
        public static bool Prim(int arr)// chek prim num
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