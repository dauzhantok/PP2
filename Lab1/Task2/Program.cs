using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        public string name = "Dauzhan";
        public int year = 1;
        public int id = 123456;

        public static int count = 0;

        public Student()
        {
            name = Console.ReadLine();
            year = Convert.ToInt32(Console.ReadLine());
            id = Convert.ToInt32(Console.ReadLine());
            count++;
        }

        public Student(string name, int year, int id)
        {
            this.name = name;
            this.year = year;
            this.id = id;
            count++;
            Print();
        }

        public void Print()//print
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Year: " + year);
            Console.WriteLine("ID: " + id);
        }
        public void nextyear()
        {
            year++;
            Console.WriteLine( year);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Student Aruzhan = new Student("Aruzhan", 1, 66666);

            Student a = new Student();


            a.Print();
            a.nextyear();

            Console.WriteLine(Student.count);
        }
    }
}