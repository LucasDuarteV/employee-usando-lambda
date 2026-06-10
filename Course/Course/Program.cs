using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Reflection.Metadata;
using System.Linq;
using Course.Entiites;
using System.Globalization;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            Console.Write("Enter path: ");
            string path = Console.ReadLine()!;

            using(StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine()!.Split(',');
                    string name = line[0];
                    string email = line[1];
                    double salary = double.Parse(line[2] ,CultureInfo.InvariantCulture);
                    list.Add(new Employee(name,email, salary));
                }
            }

            Console.Write("Enter salary: ");
            double enterSalary = double.Parse(Console.ReadLine()!,CultureInfo.InvariantCulture);

            var resultSalary = list.Where(p => p.Salary >= enterSalary).Select(p => p.Email);
            Console.WriteLine("Email of people whose salary is more than 200.00:");
            foreach( var empEmail in resultSalary)
            {
                Console.WriteLine(empEmail);
            }

            var sum = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);

           Console.Write("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2" , CultureInfo.InvariantCulture));
           
        }
    }
    // C:\Users\Lucas Vanderlei\Documents\projetos-udemy\in.txt
}