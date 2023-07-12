using System;
using Algebra_Relacional_e_SQL.Entities;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace Algebra_Relacional_e_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise();
        }

        static void Exercise()
        {
            Console.Write("Caminho do arquivo: ");
            string path = Console.ReadLine();

            List<Employee> employees_list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    employees_list.Add(new Employee(name, email, salary));
                }
            }
            Console.Clear();
            Console.WriteLine("Informações solicitadas: ");
            Console.WriteLine("Valor de salário mínimo p/ busca de email: ");
            double minSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            var emails = employees_list.Where(e => e.Salary > minSalary).OrderBy(e => e.Email).Select(e => e.Email);
            Console.WriteLine("================================");
            foreach (string email in emails)
            {
                Console.Write($"| {email}\n");
            }
            Console.WriteLine("================================");
            var names = employees_list.Where(e => e.Name.StartsWith('M')).Select(e => e.Salary).Sum();
            Console.WriteLine("| Sum of salary whose name starts with M: R$ " + names.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("================================");
        }
        static void AlgebraAndSQL()
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Product> list = new List<Product>();

            using (StreamReader sr = File.OpenText(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    list.Add(new Product(name, price));
                }
            }
            Console.Clear();

            Console.WriteLine("================================");
            var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("| Average price: R$ " + avg.ToString("F2", CultureInfo.InvariantCulture));

            Console.Write("\n| Produtos: \n");
            var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach (string name in names)
            {
                Console.WriteLine("| " + name);
            }
            Console.WriteLine("================================");
        }
    }
}