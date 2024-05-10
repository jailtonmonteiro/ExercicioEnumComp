using ExercicioEnumComp.Entities.Enums;
using ExercicioEnumComp.Entities;
using System.Globalization;
using System;

namespace ExercicioEnumComp
{
    class Program
    {
        static void Main(string[] args)
        {
            string deptName, name;
            WorkerLevel level;
            double baseSalary;

            Console.WriteLine("Enter departament's name: ");
            deptName = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");
            Console.WriteLine("Name: ");
            name = Console.ReadLine();

            Console.WriteLine("Level (Junior/MidLevel/Senior): ");
            level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.WriteLine("Base Salary: ");
            baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, department);

            Console.Write("Quantidade de contratos: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) 
            {
                Console.WriteLine($"Contrato #{i}: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine());

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine("Mês e ano para calcular(MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month)}");
        }
    }
}
