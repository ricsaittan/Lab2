using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
namespace Lab2
{
    internal class Program
    {
        //ReadFiles method that goes through the entire txt file and creates an Employee object for the specific inheritaed class
        static List<Employee> ReadFiles()
        {
            string path = @"employees.txt";

            var lines = File.ReadLines(path);

            var Employees = new List<Employee>();
            foreach (var line in lines)
            {
                var person = line.Split(":");
                long sin = Convert.ToInt64(person[4]);
                if (person[0][0] <= '4')
                {
                    double salary = Convert.ToDouble(person[7]);
                    Employees.Add(new Salaried(person[0], person[1], person[2], person[3], sin, person[5], person[6], salary));
                }

                else if (person[0][0] > '4' && person[0][0] <= '7')
                {
                    double rate = Convert.ToDouble(person[7]);
                    double hours = Convert.ToDouble(person[8]);
                    Employees.Add(new Wages(person[0], person[1], person[2], person[3], sin, person[5], person[6], rate, hours));
                }

                else if (person[0][0] > '7' && person[0][0] <= '9')
                {
                    double rate = Convert.ToDouble(person[7]);
                    double hours = Convert.ToDouble(person[8]);
                    Employees.Add(new PartTime(person[0], person[1], person[2], person[3], sin, person[5], person[6], rate, hours));
                }
            }
            return Employees;
        }

        //Method that sorts through the Employee list and returns a list of salaried employees
        static List<Employee> SortSalaried(List<Employee> ListEmployees)
        {
            var SalariedList = new List<Employee>();
            foreach (var people in ListEmployees)
            {
                if (people is Salaried)
                {
                    var temp = (Salaried) people;
                    SalariedList.Add(temp);
                }
            }
            return SalariedList;
        }

        //Method that sorts through the Employee list and returns a list of waged employees
        static List<Employee> SortWages(List<Employee> ListEmployees)
        {
            var WagesList = new List<Employee>();
            foreach (var people in ListEmployees)
            {
                if (people is Wages)
                {
                    var temp = (Wages) people;
                    WagesList.Add(temp);
                }
            }
            return WagesList;
        }

        //Method that sorts through the Employee list and returns a list of parttime employees
        static List<Employee> SortPartTime(List<Employee> ListEmployees)
        {
            var PartTimeList = new List<Employee>();
            foreach (var people in ListEmployees)
            {
                if (people is PartTime)
                {
                    var temp = (PartTime) people;
                    PartTimeList.Add(temp);
                }
            }
            return PartTimeList;
        }

        //Method that gets the avg weekly pay for all 3 employee types
        static void WeeklyPay(List<Employee> ListEmployees)
        {
            var SalariedEmployees = SortSalaried(ListEmployees);
            var WagesEmployees = SortWages(ListEmployees);
            var PartTimeEmployess = SortPartTime(ListEmployees);
            double AvgSum = 0;
            foreach (Salaried people in SalariedEmployees)
            {
                AvgSum += people.getPay()/SalariedEmployees.Count();
            }
            Console.WriteLine($"The average weekly pay for Salaried employees is ${Math.Round(AvgSum, 2)}");
            AvgSum = 0;
            foreach (Wages people in WagesEmployees)
            {
                AvgSum += people.getPay()/SalariedEmployees.Count();
            }
            Console.WriteLine($"The average weekly pay for Waged employees is ${Math.Round(AvgSum, 2)}");
            AvgSum = 0;
            foreach (PartTime people in PartTimeEmployess)
            {
                AvgSum += people.getPay()/SalariedEmployees.Count();
            }
            Console.WriteLine($"The average weekly pay for Part Time employees is ${Math.Round(AvgSum, 2)}");
        }
        
        //Method that gets the highest paid employee for each employee type
        static void HighestPay(List<Employee> ListEmployees)
        {
            var SalariedEmployees = SortSalaried(ListEmployees);
            var WagesEmployees = SortWages(ListEmployees);
            var PartTimeEmployees = SortPartTime(ListEmployees);
            double HighestPay = 0;
            string Name = "";
            foreach (Salaried people in SalariedEmployees)
            {
                if (HighestPay < people.getPay())
                {
                    HighestPay = people.getPay();
                    Name = people.getName();
                }
            }
            Console.WriteLine($"The Highest Salray paid Employee is {Name} who has a a pay of ${Math.Round(HighestPay, 2)}");
            HighestPay = 0;
            Name = "";
            foreach (Wages people in WagesEmployees)
            {
                if (HighestPay < people.getPay())
                {
                    HighestPay = people.getPay();
                    Name = people.getName();
                }
            }
            Console.WriteLine($"The Highest Wage paid Employee is {Name} who has a a pay of ${Math.Round(HighestPay, 2)}");
            HighestPay = 0;
            Name = "";
            foreach (PartTime people in PartTimeEmployees)
            {
                if (HighestPay < people.getPay())
                {
                    HighestPay = people.getPay();
                    Name = people.getName();
                }
            }
            Console.WriteLine($"The Highest PartTime paid Employee is {Name} who has a a pay of ${Math.Round(HighestPay, 2)}");
        }

        //Method that gets the lowest paid employee for each employee type
        static void LowestPay(List<Employee> ListEmployees)
        {
            var SalariedEmployees = SortSalaried(ListEmployees);
            var WagesEmployees = SortWages(ListEmployees);
            var PartTimeEmployees = SortPartTime(ListEmployees);
            double LowestPay = 9999999999;
            string Name = "";
            foreach (Salaried people in SalariedEmployees)
            {
                if (LowestPay > people.getPay())
                {
                    LowestPay = people.getPay();
                    Name = people.getName();
                }
            }
            Console.WriteLine($"The Lowest Salray paid Employee is {Name} who has a a pay of ${Math.Round(LowestPay, 2)}");
            LowestPay = 9999999999;
            Name = "";
            foreach (Wages people in WagesEmployees)
            {
                if (LowestPay > people.getPay())
                {
                    LowestPay = people.getPay();
                    Name = people.getName();
                }
            }
            Console.WriteLine($"The Lowest Wage paid Employee is {Name} who has a a pay of ${Math.Round(LowestPay, 2)}");
            LowestPay = 9999999999;
            Name = "";
            foreach (PartTime people in PartTimeEmployees)
            {
                if (LowestPay > people.getPay())
                {
                    LowestPay = people.getPay();
                    Name = people.getName();
                }
            }
            Console.WriteLine($"The Lowest PartTime paid Employee is {Name} who has a a pay of ${Math.Round(LowestPay, 2)}");
        }

        //Method that gets the employee percetange of all 3 types
        static void PercentEmployees(List<Employee> ListEmployees)
        {
            var SalariedEmployees = SortSalaried(ListEmployees);
            var WagesEmployees = SortWages(ListEmployees);
            var PartTimeEmployees = SortPartTime(ListEmployees);
            double SalariedPercent = Convert.ToDouble(SalariedEmployees.Count())/Convert.ToDouble(ListEmployees.Count()) * 100;
            double WagesPercent = Convert.ToDouble(WagesEmployees.Count())/Convert.ToDouble(ListEmployees.Count()) * 100;
            double PartTimePercent = Convert.ToDouble(PartTimeEmployees.Count())/Convert.ToDouble(ListEmployees.Count()) * 100;
            Console.WriteLine($"Salary Employees: {SalariedPercent}%");
            Console.WriteLine($"Waged Employess: {WagesPercent}%");
            Console.WriteLine($"Pert Time Employess: {PartTimePercent}%");
        }
    
        //Main method that starts the program
        static void Main(string[] arg) 
        {
            List<Employee>ListEmployees = ReadFiles();
            WeeklyPay(ListEmployees);
            HighestPay(ListEmployees);
            LowestPay(ListEmployees);
            PercentEmployees(ListEmployees);
        }
    }
}