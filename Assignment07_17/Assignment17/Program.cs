using System;
using EmployeeLib;

namespace Assignment17
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Display Company Info");
                Console.WriteLine("5. Display All Employees");
                Console.WriteLine("6. Serialize Company");
                Console.WriteLine("7. Deserialize Company");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Employee emp = new Employee();
                        emp.Accept();
                        company.AddEmployee(emp);
                        break;
                    case "2":
                        Console.Write("Enter Employee ID to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        if (company.RemoveEmployee(removeId))
                        {
                            Console.WriteLine("Employee removed.");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter Employee ID to find: ");
                        int findId = int.Parse(Console.ReadLine());
                        Employee foundEmp = company.FindEmployee(findId);
                        if (foundEmp != null)
                        {
                            Console.WriteLine(foundEmp.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;
                    case "4":
                        company.Print();
                        break;
                    case "5":
                        company.PrintEmployees();
                        break;
                    case "6":
                        Console.Write("Enter filename to serialize: ");
                        string serializeFile = Console.ReadLine();
                        company.SerializeCompany(serializeFile);
                        break;
                    case "7":
                        Console.Write("Enter filename to deserialize: ");
                        string deserializeFile = Console.ReadLine();
                        Company deserializedCompany = Company.DeserializeCompany(deserializeFile);
                        Console.WriteLine("Company deserialized.");
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
