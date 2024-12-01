using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{

    public static class Math
    {
        public static int Sum(int a, int b) => a + b;
        public static int Subtract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;
        public static int Divide(int a, int b) => a / b;
    }

    public class MathInstance
    {
        public int Sum(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b) => a / b;
    }
}
