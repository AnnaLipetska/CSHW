using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2
{
    // Используя Visual Studio, создайте проект по шаблону Console Application
    // Создайте программу, в которой создайте четыре лямбда оператора для выполнения арифметических действий,
    // первый лямбда оператор для сложения, второй для вычитания, третий для умножения и четвертый для деления
    // (лямбда оператор для деления должен выполнять проверку деления на ноль).
    // Каждый лямбда оператор должен принимать два аргумента и возвращать соответственный результат вычисления.
    // В программе организуйте логику, которая будет выполнять арифметическую операцию указанную пользователем.

    delegate double? Calculator(double a, double b);
    class Program
    {
        static string firstNum;
        static string secondNum;
        static string sign;

        static double firstNumber;
        static double secondNumber;

        static bool firstNumberOK;
        static bool secondNumberOK;

        static double? result;

        static void Main(string[] args)
        {
            Calculator add = (a, b) => { return a + b; };

            Calculator sub = (a, b) => { return a - b; };

            Calculator mul = (a, b) => { return a * b; };

            Calculator div = (a, b) =>
            {
                if (b == 0)
                {
                    Console.WriteLine("На ноль делить нельзя");
                    return null;
                }
                return a / b;
            };

            for (; ; )
            {
                Console.WriteLine("Введите слово exit, если хотите выйти из программы.");
                Console.Write("Введите первое число: ");
                firstNum = Console.ReadLine();

                if (firstNum == "exit")
                {
                    Console.WriteLine("Выход из программы");
                    break;
                }

                firstNumberOK = Double.TryParse(firstNum, out firstNumber);
                if (!firstNumberOK)
                {
                    Console.WriteLine("Неправильный ввод числа");
                    continue;
                }

                Console.WriteLine("Введите знак действия +, -, * или /");
                sign = Console.ReadLine();

                if (sign == "exit")
                {
                    Console.WriteLine("Выход из программы");
                    break;
                }

                else if (sign != "+" && sign != "-" && sign != "*" && sign != "/")
                {
                    Console.WriteLine("Вы ввели неправильный знак действия");
                    continue;
                }

                Console.Write("Введите второе число: ");
                secondNum = Console.ReadLine();

                if (secondNum == "exit")
                {
                    Console.WriteLine("Выход из программы");
                    break;
                }

                secondNumberOK = Double.TryParse(secondNum, out secondNumber);

                if (!secondNumberOK)
                {
                    Console.WriteLine("Неправильный ввод числа");
                    continue;
                }
                switch (sign)
                {
                    case "+":
                        {
                            result = add.Invoke(firstNumber, secondNumber);
                            break;
                        }
                    case "-":
                        {
                            result = sub.Invoke(firstNumber, secondNumber);
                            break;
                        }
                    case "*":
                        {
                            result = mul.Invoke(firstNumber, secondNumber);
                            break;
                        }
                    case "/":
                        {
                            result = div.Invoke(firstNumber, secondNumber);
                            break;
                        }
                    default:
                        {
                            result = null;
                            Console.WriteLine("Непредвиденный случай");
                            break;
                        }

                }
                if (result != null)
                {
                    ShowResult();
                }

                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void ShowResult()
        {
            Console.WriteLine($"{firstNumber} {sign} {secondNumber} = {result}");
        }
    }
}