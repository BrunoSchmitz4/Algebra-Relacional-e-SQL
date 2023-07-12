using System.ComponentModel.DataAnnotations;

namespace Algebra_Relacional_e_SQL.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string email, double salary)
        {
            Name = name;
            Email = email;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"| Nome: {Name} | Email: {Email} | Salário: R$ {Salary}";
        }
    }
}
