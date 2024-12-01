using System;
using EmployeeLib;

namespace EmployeeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("----- Company Management -----");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Display Company Info");
                Console.WriteLine("5. Display All Employees");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployeeToCompany(company);
                        break;

                    case 2:
                        RemoveEmployeeFromCompany(company);
                        break;

                    case 3:
                        FindEmployeeById(company);
                        break;

                    case 4:
                        DisplayCompanyInfo(company);
                        break;

                    case 5:
                        DisplayAllEmployees(company);
                        break;

                    case 6:
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // Method to add an employee to the company
        private static void AddEmployeeToCompany(Company company)
        {
            Console.WriteLine("Enter Employee Details:");

            Employee employee = new Employee();
            employee.Accept();
            company.AddEmployee(employee);

            Console.WriteLine("Employee added successfully.");
        }

        // Method to remove an employee from the company by ID
        private static void RemoveEmployeeFromCompany(Company company)
        {
            Console.Write("Enter Employee ID to remove: ");
            int id = int.Parse(Console.ReadLine());

            if (company.RemoveEmployee(id))
            {
                Console.WriteLine("Employee removed successfully.");
            }
            else
            {
                Console.WriteLine("Employee with the given ID not found.");
            }
        }

        // Method to find an employee by ID
        private static void FindEmployeeById(Company company)
        {
            Console.Write("Enter Employee ID to find: ");
            int id = int.Parse(Console.ReadLine());

            var employeeNode = company.FindEmployee(id);
            if (employeeNode != null)
            {
                Console.WriteLine("Employee found:");
                Console.WriteLine(employeeNode.Value.ToString());
            }
            else
            {
                Console.WriteLine("Employee with the given ID not found.");
            }
        }

        // Method to display company information
        private static void DisplayCompanyInfo(Company company)
        {
            company.Print();
        }

        // Method to display all employees in the company
        private static void DisplayAllEmployees(Company company)
        {
            company.PrintEmployees();
        }
    }
}
