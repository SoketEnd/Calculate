using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculator<double> calculator = new Calculate();

            try
            {
                Console.WriteLine("Введите пример (например, 3 + 5):");
                string input = Console.ReadLine();
                var parts = input.Split(' ');

                if (parts.Length != 3)
                {
                    throw new FormatException("Некорректный формат ввода. Пример правильного ввода: 3 + 5");
                }

                double a = Convert.ToDouble(parts[0]);
                char operation = Convert.ToChar(parts[1]);
                double b = Convert.ToDouble(parts[2]);

                double rezul;

                switch (operation)
                {
                    case '+':                     
                        rezul = calculator.Sum(a, b);
                        break;
                    case '-':
                        rezul = calculator.Minus(a,b);
                        break;
                    case '*':
                        rezul = calculator.Multyplecate(a,b);
                        break;
                    case '/':
                        rezul = calculator.Division(a, b);
                        break;
                    default:
                        throw new InvalidOperationException("Некорректная операция. Используйте +, -, *, или /.");
                }
                Console.WriteLine($" {a} {operation} {b} = {rezul}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ошибка формата: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Ошибка операции: " + ex.Message);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка: деление на ноль.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }

    interface ICalculator<T>
    {
        T Sum(T num1, T num2);
        T Minus(T num1, T num2);
        T Multyplecate(T num1, T num2);
        T Division(T num1, T num2);
    }
    class Calculate : ICalculator<double>
    {
        public double Division(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException();
            }
            return num1 / num2;
        }

        public double Minus(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multyplecate(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Sum(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
