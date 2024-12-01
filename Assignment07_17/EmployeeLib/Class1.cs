using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum DepartmentType
    {
        HR,
        IT,
        Finance,
        Marketing,
        Sales
    }
    public class Date
    {
		private int day;
		private int month;
		private int year;

        public Date()
        {
            day = 1;
			month = 1;
			year = 2000;
        }

        public Date(int day, int month, int year)
        {
            this.day = day;
			this.month = month;
			this.year = year;
        }
        public int Year
		{
			get { return year; }
			set { year = value; }
		}

		public int Month
		{
			get { return month; }
			set { month = value; }
		}


		public int Day
		{
			get { return day; }
			set { day = value; }
		}

		public void AcceptDate()
		{
            Console.WriteLine("Enter Day : ");
			Day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Month : ");
            Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Year : ");
            Year = Convert.ToInt32(Console.ReadLine());
        }

		public void PrintDate()
		{
			Console.WriteLine("Date : ${Day}/${Month}/${year}");
		}

		public bool IsValid()
		{
			return Day>0 && Day<=31 && Month>0 && Month<=12 && Year>0;
		}

        public static int operator -(Date d1, Date d2)
        {
            return Math.Abs(d1.Year - d2.Year);
        }

        public static int YearDifference(Date d1, Date d2)
        {
            return d1 - d2;
        }

        // Calculate Age (Static Method)
        public static int CalculateAge(Date birthDate)
        {
            DateTime today = DateTime.Now;
            DateTime birth = new DateTime(birthDate.Year, birthDate.Month, birthDate.Day);
            int age = today.Year - birth.Year;

            if (today < birth.AddYears(age)) // Adjust for upcoming birthdays
                age--;

            return age;
        }
        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }

	public class Person
	{
		private string name;
		private bool gender;
		private string address;
		private Date birth;

		public Date Birth
		{
			get { return birth; }
			set { birth = value; }
		}

			
		public string Address
		{
			get { return address; }
			set { address = value; }
		}


		public bool Gender
		{
			get { return gender; }
			set { gender = value; }
		}


		public string Name
		{
			get { return name; }
			set { name = value; }
		}

        public int Age
        {
            get => Date.CalculateAge(Birth);
        }


        // Default Constructor
        public Person()
        {
            name = "Unknown";
            gender = true;
            birth = new Date();
            address = "Not Provided";
        }

        // Parameterized Constructor
        public Person(string name, bool gender, Date birth, string address)
        {
            this.name = name;
            this.gender = gender;
            this.birth = birth;
            this.address = address;
        }

        public void Accept()
        {
            Console.Write("Enter Name: ");
            Name = Console.ReadLine();

            Console.Write("Enter Gender (true for Male, false for Female): ");
            Gender = bool.Parse(Console.ReadLine());

            Console.WriteLine("Enter Birth Date:");
            Birth = new Date();
            Birth.AcceptDate();

            Console.Write("Enter Address: ");
            Address = Console.ReadLine();
        }

        // Print method
        public void Print()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Gender: {(Gender ? "Male" : "Female")}");
            Console.WriteLine($"Birth Date: {Birth}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Age: {Age}");
        }

        // ToString method
        public override string ToString()
        {
            return $"Name: {Name}, Gender: {(Gender ? "Male" : "Female")}, Birth Date: {Birth}, Address: {Address}, Age: {Age}";
        }
    }

        

    public class Employee : Person
    {
        private static int counter = 1; // Static counter for auto-generated IDs
        private int id;
        private double salary;
        private string designation;
        private DepartmentType dept;

        // Properties
        public int Id => id; // Read-only, auto-generated

        public double Salary { get; set; }
        public string Designation { get; set; }
        public DepartmentType Dept { get; set; }


        // Default Constructor
        public Employee() : base()
        {
            id = counter++;
            salary = 0.0;
            designation = "Not Assigned";
            dept = DepartmentType.IT; // Default department
        }

        // Parameterized Constructor
        public Employee(string name, bool gender, Date birth, string address, double salary, string designation, DepartmentType dept)
            : base(name, gender, birth, address)
        {
            id = counter++;
            this.salary = salary;
            this.designation = designation;
            this.dept = dept;
        }

        // Accept Method
        public void Accept()
        {
            base.Accept(); // Accept details for Person

            Console.Write("Enter Salary: ");
            Salary = double.Parse(Console.ReadLine());

            Console.Write("Enter Designation: ");
            Designation = Console.ReadLine();

            Console.WriteLine("Enter Department (0: HR, 1: IT, 2: Finance, 3: Marketing, 4: Sales): ");
            Dept = (DepartmentType)int.Parse(Console.ReadLine());
        }

        // Print Method
        public void Print()
        {
            base.Print(); // Print details for Person
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Designation: {Designation}");
            Console.WriteLine($"Department: {Dept}");
        }

        public virtual double CalculateSalary()
        {
            return Salary;
        }

        // ToString Override
        public override string ToString()
        {
            return base.ToString() + $", ID: {Id}, Salary: {Salary}, Designation: {Designation}, Department: {Dept}";
        }
    }


    public class Manager : Employee
    {
        private double bonus;

        // Properties
        public double Bonus { get; set; }
        // Default Constructor
        public Manager() : base()
        {
            Bonus = 0.0;
            Designation = "Manager"; // Fixed designation
        }

        // Parameterized Constructor
        public Manager(string name, bool gender, Date birth, string address, double salary, DepartmentType dept, double bonus)
            : base(name, gender, birth, address, salary, "Manager", dept)
        {
            this.bonus = bonus;
        }

        // Accept Method
        public new void Accept()
        {
            base.Accept(); 
            Console.Write("Enter Bonus: ");
            Bonus = double.Parse(Console.ReadLine());
        }

        // Print Method
        public new void Print()
        {
            base.Print();
            Console.WriteLine($"Bonus: {Bonus}");
        }

        // ToString Method
        public override string ToString()
        {
            return base.ToString() + $", Bonus: {Bonus}";
        }
    }


    public class Supervisor : Employee
    {
        private int subbordinates;

        public int Subbordinates
        {
            get { return subbordinates; }
            set { subbordinates = value; }
        }


        // Default Constructor
        public Supervisor() : base()
        {
            Subbordinates = 0;
            Designation = "Supervisor"; // Fixed designation
        }

        // Parameterized Constructor
        public Supervisor(string name, bool gender, Date birth, string address, double salary, DepartmentType dept, int subbordinates)
            : base(name, gender, birth, address, salary, "Supervisor", dept)
        {
            this.subbordinates = subbordinates;
        }

        // Accept Method
        public new void Accept()
        {
            base.Accept();
            Console.Write("Enter Number of Subbordinates: ");
            Subbordinates = int.Parse(Console.ReadLine());
        }

        // Print Method
        public new void Print()
        {
            base.Print(); 
            Console.WriteLine($"Subbordinates: {Subbordinates}");
        }

        // ToString Method
        public override string ToString()
        {
            return base.ToString() + $", Subbordinates: {Subbordinates}";
        }
    }

   

    public class WageEmp : Employee
    {
        private int hours;
        private int rate;

        // Properties
        public int Hours { get; set; }
        public int Rate { get; set; }

        // Default Constructor
        public WageEmp() : base()
        {
            Designation = "Wage";
            hours = 0;
            rate = 0;
        }

        // Parameterized Constructor
        public WageEmp(string name, bool gender, Date birth, string address, int hours, int rate, DepartmentType dept)
            : base(name, gender, birth, address, 0, "Wage", dept) 
        {
            this.hours = hours;
            this.rate = rate;
        }

        // Accept Method
        public new void Accept()
        {
            base.Accept();
            Console.Write("Enter Hours Worked: ");
            Hours = int.Parse(Console.ReadLine());

            Console.Write("Enter Hourly Rate: ");
            Rate = int.Parse(Console.ReadLine());
        }

        // Print Method
        public new void Print()
        {
            base.Print();
            Console.WriteLine($"Hours Worked: {Hours}");
            Console.WriteLine($"Hourly Rate: {Rate}");
            Console.WriteLine($"Total Salary: {CalculateSalary()}");
        }

        // Method to calculate total salary
        public double CalculateSalary()
        {
            return Hours * Rate;
        }

        // ToString Method
        public override string ToString()
        {
            return base.ToString() + $", Hours Worked: {Hours}, Hourly Rate: {Rate}, Total Salary: {CalculateSalary()}";
        }
    }

    //public class Company
    //{
    //    private string name;
    //    private string address;
    //    private LinkedList<Employee> empList;
    //    private double salaryExpense;

    //    // Properties
    //    public string Name
    //    {
    //        get => name;
    //        set => name = value;
    //    }

    //    public string Address
    //    {
    //        get => address;
    //        set => address = value;
    //    }

    //    public LinkedList<Employee> EmpList
    //    {
    //        get => empList;
    //        set => empList = value;
    //    }

    //    public double SalaryExpense
    //    {
    //        get => salaryExpense;
    //    }

    //    // Default Constructor
    //    public Company()
    //    {
    //        name = "Unknown";
    //        address = "Unknown";
    //        empList = new LinkedList<Employee>();
    //        salaryExpense = 0;
    //    }

    //    // Parameterized Constructor
    //    public Company(string name, string address)
    //    {
    //        this.name = name;
    //        this.address = address;
    //        this.empList = new LinkedList<Employee>();
    //        this.salaryExpense = 0;
    //    }

    //    // Accept Method to take data from the console
    //    public void Accept()
    //    {
    //        Console.Write("Enter Company Name: ");
    //        Name = Console.ReadLine();
    //        Console.Write("Enter Company Address: ");
    //        Address = Console.ReadLine();
    //    }

    //    // Print Method to display company information
    //    public void Print()
    //    {
    //        Console.WriteLine($"Company Name: {Name}");
    //        Console.WriteLine($"Company Address: {Address}");
    //        Console.WriteLine($"Total Monthly Salary Expense: {SalaryExpense}");
    //    }

    //    // Calculate the total salary expense per month
    //    public void CalculateSalaryExpense()
    //    {
    //        salaryExpense = 0;
    //        foreach (var employee in empList)
    //        {
    //            salaryExpense += employee.CalculateSalary(); // Assuming Employee has a method CalculateSalary()
    //        }
    //    }

    //    // Add Employee Method
    //    public void AddEmployee(Employee e)
    //    {
    //        empList.AddLast(e);
    //        CalculateSalaryExpense(); // Recalculate salary after adding the new employee
    //    }

    //    // Remove Employee Method by ID
    //    public bool RemoveEmployee(int id)
    //    {
    //        var node = FindEmployee(id);
    //        if (node != null)
    //        {
    //            empList.Remove(node);
    //            CalculateSalaryExpense(); // Recalculate salary after removal
    //            return true;
    //        }
    //        return false;
    //    }

    //    // Find Employee by ID
    //    public LinkedListNode<Employee> FindEmployee(int id)
    //    {

    //        var currentNode = empList.First;
    //        while (currentNode != null)
    //        {
    //            if (currentNode.Value.Id == id) 
    //            {
    //                return currentNode;
    //            }
    //            currentNode = currentNode.Next;
    //        }
    //        return null;
    //    }



    //    // ToString Method for company details
    //    public override string ToString()
    //    {
    //        return $"Company Name: {Name}, Address: {Address}, Total Salary Expense: {SalaryExpense}";
    //    }

    //    // Print all employees
    //    public void PrintEmployees()
    //    {
    //        Console.WriteLine("Employee List:");
    //        foreach (var employee in empList)
    //        {
    //            Console.WriteLine(employee.ToString()); // Assuming Employee has a proper ToString() method
    //        }
    //    }
    //}


    public class Company
    {
        private string name;
        private string address;
        private List<Employee> empList;  // Use List<Employee> instead of LinkedList
        private double salaryExpense;

        // Properties
        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public List<Employee> EmpList
        {
            get => empList;
            set => empList = value;
        }

        public double SalaryExpense
        {
            get => salaryExpense;
        }

        // Default Constructor
        public Company()
        {
            name = "Unknown";
            address = "Unknown";
            empList = new List<Employee>();  // Initialize with an empty list
            salaryExpense = 0;
        }

        // Parameterized Constructor
        public Company(string name, string address)
        {
            this.name = name;
            this.address = address;
            this.empList = new List<Employee>();  // Initialize with an empty list
            this.salaryExpense = 0;
        }

        // Accept Method to take data from the console
        public void Accept()
        {
            Console.Write("Enter Company Name: ");
            Name = Console.ReadLine();
            Console.Write("Enter Company Address: ");
            Address = Console.ReadLine();
        }

        // Print Method to display company information
        public void Print()
        {
            Console.WriteLine($"Company Name: {Name}");
            Console.WriteLine($"Company Address: {Address}");
            Console.WriteLine($"Total Monthly Salary Expense: {SalaryExpense}");
        }

        // Calculate the total salary expense per month
        public void CalculateSalaryExpense()
        {
            salaryExpense = 0;
            foreach (var employee in empList)
            {
                salaryExpense += employee.CalculateSalary(); // Assuming Employee has a method CalculateSalary()
            }
        }

        // Add Employee Method
        public void AddEmployee(Employee e)
        {
            empList.Add(e);
            CalculateSalaryExpense(); // Recalculate salary after adding the new employee
        }

        // Remove Employee Method by ID
        public bool RemoveEmployee(int id)
        {
            var employee = FindEmployee(id);
            if (employee != null)
            {
                empList.Remove(employee);  // Remove employee from the list
                CalculateSalaryExpense(); // Recalculate salary after removal
                return true;
            }
            return false;
        }

        // Find Employee by ID
        public Employee FindEmployee(int id)
        {
            foreach (var employee in empList)
            {
                if (employee.Id == id)  // Find the employee with the matching ID
                {
                    return employee;  // Return the found employee
                }
            }
            return null;  // Return null if not found
        }

        // ToString Method for company details
        public override string ToString()
        {
            return $"Company Name: {Name}, Address: {Address}, Total Salary Expense: {SalaryExpense}";
        }

        // Print all employees
        public void PrintEmployees()
        {
            Console.WriteLine("Employee List:");
            foreach (var employee in empList)
            {
                Console.WriteLine(employee.ToString()); // Assuming Employee has a proper ToString() method
            }
        }

        // Serialization using SoapFormatter
        public void SerializeCompany(string fileName)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(stream, this);
            }
            Console.WriteLine("Company serialized successfully.");
        }

        // Deserialization using SoapFormatter
        public static Company DeserializeCompany(string fileName)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                return (Company)formatter.Deserialize(stream);
            }
        }
    }

    }
