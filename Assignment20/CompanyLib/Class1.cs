using System;
using System.Collections.Generic;

namespace CompanyLib
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    // Delegate to handle the event
    public delegate void EmpListChangedEventHandler(object sender, EventArgs e);

    public class Company
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; private set; }
        public decimal TotalSalaryExpense { get; private set; }

        // Declare the event
        public event EmpListChangedEventHandler EmpListChanged;

        public Company(string name)
        {
            Name = name;
            Employees = new List<Employee>();
            TotalSalaryExpense = 0;
        }

        // Method to add employee
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
            TotalSalaryExpense += employee.Salary;

            // Fire the event
            OnEmpListChanged();
        }

        // Method to remove employee
        public void RemoveEmployee(int employeeId)
        {
            Employee employeeToRemove = Employees.Find(emp => emp.Id == employeeId);
            if (employeeToRemove != null)
            {
                Employees.Remove(employeeToRemove);
                TotalSalaryExpense -= employeeToRemove.Salary;

                // Fire the event
                OnEmpListChanged();
            }
        }

        // Method to trigger the event
        protected virtual void OnEmpListChanged()
        {
            if (EmpListChanged != null)
            {
                EmpListChanged(this, EventArgs.Empty);
            }
        }
    }
}
