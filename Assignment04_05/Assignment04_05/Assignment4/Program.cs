using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public struct Student
    {
        string name;
        Gender gender;
        int age;
        int std;
        char div;
        double marks;
        
        //default constructor
        public Student()
        {
            name = "Dummy";
            gender = Gender.Male;
            age = 15;
            std = 10;
            div = 'A';
            marks = 80;
        }

        // parameterized constructor
        public Student(string name, Gender gender, int age, int std, char div, double marks)
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.std = std;
            this.div = div;
            this.marks = marks;
        }

        // get and set method
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public int Std { get; set; }
        public char Div { get; set; }
        public double Marks { get; set; }

        //Accept Details
        public void AcceptDetails()
        {
            Console.Write("Enter Name: ");
            Name = Console.ReadLine();

            Console.Write("Enter Gender (0 for Male, 1 for Female, 2 for Other): ");
            Gender = (Gender)int.Parse(Console.ReadLine());

            Console.Write("Enter Age: ");
            Age = int.Parse(Console.ReadLine());

            Console.Write("Enter Standard: ");
            Std = int.Parse(Console.ReadLine());

            Console.Write("Enter Division: ");
            Div = char.Parse(Console.ReadLine());

            Console.Write("Enter Marks: ");
            Marks = double.Parse(Console.ReadLine());
        }

        // PrintDetails method
        public void PrintDetails()
        {
            Console.WriteLine($"Name: {Name}, Gender: {Gender}, Age: {Age}, Standard: {Std}, Division: {Div}, Marks: {Marks}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.AcceptDetails();
            student.PrintDetails();
        }
    }
}
