using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculationLib;

namespace Assignment2
{
    internal class Program
    {
        public static int Menu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("-------------------------");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Menu List");
            Console.WriteLine("0. Exit \n");
            Console.WriteLine("1. Addition \n");
            Console.WriteLine("2. Substriction \n");
            Console.WriteLine("3. Multiplication \n");
            Console.WriteLine("4. Division \n ");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Enter your Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        static void Main(string[] args)
        {
            Maths math = new Maths();
            Console.WriteLine("Enter First Value : ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Value : ");
            int y = Convert.ToInt32(Console.ReadLine());
            #region
            // value of x and y is string so need to convert in string
            //String xValue = Console.ReadLine();
            //String yValue = Console.ReadLine();
            //int x = Convert.ToInt32(xValue);
            //int y = Convert.ToInt32(yValue);
            #endregion

            int choice = Menu();
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Thank You for using this Application");
                    break;
                case 1:
                    Console.WriteLine("\n");
                    Console.WriteLine(math.Add(x, y));
                    break;
                case 2:
                    Console.WriteLine("\n");
                    Console.WriteLine(math.Sub(x, y));
                    break;
                case 3:
                    Console.WriteLine("\n");
                    Console.WriteLine(math.Mul(x, y));
                    break;
                case 4:
                    Console.WriteLine("\n");
                    Console.WriteLine(math.Div(x, y));
                    break;
                default:
                    Console.WriteLine("\n");
                    Console.WriteLine("Invalid Choice ! ");
                    break;
            }
            Console.ReadLine();
        }
    }
}
