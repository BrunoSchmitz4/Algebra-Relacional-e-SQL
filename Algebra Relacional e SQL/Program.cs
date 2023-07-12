using System;
using Algebra_Relacional_e_SQL.Entities;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Algebra_Relacional_e_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgebraAndSQL();
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