using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_3
{
    // Используя Visual Studio, создайте проект по шаблону Console Application.
    // Создайте программу в которой создайте класс калькулятор (Calculator).
    // Класс Calculator должен содержать два универсальных параметра типа T1, T2 (Calculator<T1, T2>).
    public class Calculator<T1, T2>
    {
        // В теле класса создайте методы для сложения (Add), вычитания (Subtract) и умножения (Multiply),
        // которые в качестве аргументов должны принимать T1, T2, и возвращать тип double
        // (можно использовать класс Convert или приведение типов)
        public double Calculate(T1 operand1, T2 operand2)
        {
            Program.resultIsValid = true;
            Program.resultIsString = false;
            Program.stringResult = string.Empty;

            if (Program.op == Operation.Adding)
            {
                return Add(operand1, operand2);
            }

            else if (Program.op == Operation.Subtraction)
            {
                return Subtract(operand1, operand2);
            }

            else if (Program.op == Operation.Multiplying)
            {
                return Multiply(operand1, operand2);
            }

            else
            {
                Program.resultIsValid = false;
                return default(double);
            }
        }
        double Add(T1 operand1, T2 operand2)
        {
            if (typeof(T1) == typeof(int) && typeof(T2) == typeof(int))
            {
                return (double)((int)(object)operand1 + (int)(object)operand2);
            }

            else if (typeof(T1) == typeof(double) && typeof(T2) == typeof(double))
            {
                return (double)((double)(object)operand1 + (double)(object)operand2);
            }

            else if (typeof(T1) == typeof(int) && typeof(T2) == typeof(double))
            {
                return (double)((int)(object)operand1 + (double)(object)operand2);
            }

            else if (typeof(T1) == typeof(double) && typeof(T2) == typeof(int))
            {
                return (double)((double)(object)operand1 + (int)(object)operand2);
            }

            else if (typeof(T1) == typeof(string) && typeof(T2) == typeof(string))
            {
                double op1, op2;
                if (double.TryParse(((string)(object)operand1).Replace('.', ','), out op1) && double.TryParse(((string)(object)operand2).Replace('.', ','), out op2))
                {
                    return op1 + op2;
                }
                else
                {
                    Program.stringResult = ((string)(object)operand1 + (string)(object)operand2);
                    Program.resultIsString = true;
                    return default(double);
                }
            }

            else
            {
                Program.resultIsValid = false;
                return default(double);
            }
        }
        double Subtract(T1 operand1, T2 operand2)
        {
            if (typeof(T1) == typeof(int) && typeof(T2) == typeof(int))
            {
                return (double)((int)(object)operand1 - (int)(object)operand2);
            }

            else if (typeof(T1) == typeof(double) && typeof(T2) == typeof(double))
            {
                return (double)((double)(object)operand1 - (double)(object)operand2);
            }

            else if (typeof(T1) == typeof(int) && typeof(T2) == typeof(double))
            {
                return (double)((int)(object)operand1 - (double)(object)operand2);
            }

            else if (typeof(T1) == typeof(double) && typeof(T2) == typeof(int))
            {
                return (double)((double)(object)operand1 - (int)(object)operand2);
            }

            else if (typeof(T1) == typeof(string) && typeof(T2) == typeof(string))
            {
                double op1, op2;
                if (double.TryParse(((string)(object)operand1).Replace('.', ','), out op1) && double.TryParse(((string)(object)operand2).Replace('.', ','), out op2))
                {
                    return op1 - op2;
                }
                else
                {
                    int index = ((string)(object)operand1).IndexOf((string)(object)operand2);
                    if (index >= 0)
                    {
                        Program.stringResult = (((string)(object)operand1).Remove(index, ((string)(object)operand2).Length));
                        Program.resultIsString = true;
                    }
                    else
                    {
                        Program.resultIsValid = false;
                    }
                    return default(double);
                }
            }

            else
            {
                Program.resultIsValid = false;
                return default(double);
            }
        }
        double Multiply(T1 operand1, T2 operand2)
        {
            if (typeof(T1) == typeof(int) && typeof(T2) == typeof(int))
            {
                return (double)((int)(object)operand1 * (int)(object)operand2);
            }

            else if (typeof(T1) == typeof(double) && typeof(T2) == typeof(double))
            {
                return (double)((double)(object)operand1 * (double)(object)operand2);
            }

            else if (typeof(T1) == typeof(int) && typeof(T2) == typeof(double))
            {
                return (double)((int)(object)operand1 * (double)(object)operand2);
            }

            else if (typeof(T1) == typeof(double) && typeof(T2) == typeof(int))
            {
                return (double)((double)(object)operand1 * (int)(object)operand2);
            }

            else if (typeof(T1) == typeof(string) && typeof(T2) == typeof(string))
            {
                double op1, op2;
                if (double.TryParse(((string)(object)operand1).Replace('.', ','), out op1) && double.TryParse(((string)(object)operand2).Replace('.', ','), out op2))
                {
                    return op1 * op2;
                }
                else
                {
                    Program.resultIsValid = false;
                    return default(double);
                }
            }

            else
            {
                Program.resultIsValid = false;
                return default(double);
            }
        }
    }
    public enum Operation
    {
        Adding,
        Subtraction,
        Multiplying
    }

    class Program
    {
        public static bool resultIsValid;
        public static bool resultIsString;
        public static string stringResult;
        public static Operation op;
        
        static void Main(string[] args)
        {
            int i1 = 2; int i2 = 3;
            double d1 = 2.2; double d2 = 3.3;
            string s1 = "Hello world!!! "; string s2 = "world!!!";
            string sn1 = "5,1"; string sn2 = "6.9";

            Calculator<int, int> ii = new Calculator<int, int>();
            Calculator<double, double> dd = new Calculator<double, double>();
            Calculator<int, double> id = new Calculator<int, double>();
            Calculator<double, int> di = new Calculator<double, int>();
            Calculator<string, string> ss = new Calculator<string, string>();

            // Для разных тестов использовать разные типы операций можно:
            //op = Operation.Adding;
            //op = Operation.Subtraction; 
            op = Operation.Multiplying;

            Display(i1, i2, ii.Calculate(i1, i2));
            Display(d1, d2, dd.Calculate(d1, d2));
            Display(i1, d2, id.Calculate(i1, d2));
            Display(d1, i2, di.Calculate(d2, i1));
            Display(s1, s2, ss.Calculate(s1, s2));
            Display(sn1, sn2, ss.Calculate(sn1, sn2));

            Console.ReadKey();
        }

        private static void Display<T1, T2, T3>(T1 operand1, T2 operand2, T3 result)
        {
            if (!resultIsValid)
            {
                Console.WriteLine($"There is no way of {op.ToString().ToLower()} {operand1} and {operand2}.");
            }

            else if (!resultIsString)
            {
                Console.WriteLine($"The result of {op.ToString().ToLower()} {operand1} and {operand2} is {result}.");
            }

            else if (resultIsString)
            {
                Console.WriteLine($"The result of {op.ToString().ToLower()} '{operand1}' and '{operand2}' is '{stringResult}'.");
            }
        }
    }
}
