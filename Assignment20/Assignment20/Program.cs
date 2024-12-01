using System;
using CompanyLib; 
namespace Assignment20
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create company and employees
            Company company = new Company("TechCorp");

            // Subscribe to the EmpListChanged event
            company.EmpListChanged += UpdateSalaryExpense;

            // Create some employees
            Employee emp1 = new Employee { Id = 1, Name = "Alice", Salary = 50000 };
            Employee emp2 = new Employee { Id = 2, Name = "Bob", Salary = 60000 };

            // Add employees
            company.AddEmployee(emp1);
            company.AddEmployee(emp2);

            // Remove an employee
            company.RemoveEmployee(1);

            Console.WriteLine($"Total Salary Expense of {company.Name}: {company.TotalSalaryExpense}");
        }

        // Event handler method to update salary expense
        static void UpdateSalaryExpense(object sender, EventArgs e)
        {
            Company company = (Company)sender;

            Console.WriteLine($"Employee list changed. Updated Salary Expense: {company.TotalSalaryExpense}");
        }
    }
}
