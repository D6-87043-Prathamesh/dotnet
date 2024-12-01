using System;
using MathLib;

namespace Assignment18
{
    class Program
    {
        // Declare the delegate type
        public delegate int MathOperation(int a, int b);

        static void Main(string[] args)
        {
            // ------------------- Static Math Class -------------------
            // Create uni-cast delegate for static methods
            MathOperation mathOp = new MathOperation(MathLib.Math.Sum);
            Console.WriteLine($"Static Sum: {mathOp(10, 5)}");

            mathOp = MathLib.Math.Subtract;
            Console.WriteLine($"Static Subtract: {mathOp(10, 5)}");

            mathOp = MathLib.Math.Multiply;
            Console.WriteLine($"Static Multiply: {mathOp(10, 5)}");

            mathOp = MathLib.Math.Divide;
            Console.WriteLine($"Static Divide: {mathOp(10, 5)}");

            // Create multicast delegate for static methods
            MathOperation multiOp = MathLib.Math.Sum;
            multiOp += MathLib.Math.Multiply;
            Console.WriteLine($"Static Multicast (Sum + Multiply): {multiOp(10, 5)}");

            // ------------------- Instance Math Class -------------------
            // Create an instance of MathInstance class
            MathInstance mathInstance = new MathInstance();

            // Create uni-cast delegate for instance methods
            mathOp = new MathOperation(mathInstance.Sum);
            Console.WriteLine($"Instance Sum: {mathOp(10, 5)}");

            mathOp = mathInstance.Subtract;
            Console.WriteLine($"Instance Subtract: {mathOp(10, 5)}");

            mathOp = mathInstance.Multiply;
            Console.WriteLine($"Instance Multiply: {mathOp(10, 5)}");

            mathOp = mathInstance.Divide;
            Console.WriteLine($"Instance Divide: {mathOp(10, 5)}");

            // Create multicast delegate for instance methods
            MathOperation instanceMultiOp = mathInstance.Sum;
            instanceMultiOp += mathInstance.Multiply;
            Console.WriteLine($"Instance Multicast (Sum + Multiply): {instanceMultiOp(10, 5)}");
        }
    }
}
