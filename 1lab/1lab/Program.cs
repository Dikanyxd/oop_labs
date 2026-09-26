using System;

namespace Lab1Variant11
{
    class Program
    {
        static void Main()
        {
            RunTask1();
            RunTask2();
            RunTask3();

            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
        }

        static void RunTask1()
        {
            Console.WriteLine("Задача 1");

            int m = ReadInt("Введите m: ");
            int n = ReadInt("Введите n: ");
            double x = ReadDouble("Введите x: ");

            //1
            int sum = (n++) + (m--);
            Console.WriteLine("1) (n++)+(m--)     = {0}   [m={1}, n={2}]", sum, m, n);
            //2
            bool less = n * m < n++;
            Console.WriteLine("2) n*m < n++       = {0}   [m={1}, n={2}]", less, m, n);
            //3
            bool greater = n-- > ++m;
            Console.WriteLine("3) n-- > ++m       = {0}   [m={1}, n={2}]", greater, m, n);
            //4
            double expr = Math.Pow(2, x) * x * Math.Cos(x) + 1;
            Console.WriteLine("4) 2^x*x*cos(x)+1  = {0:F4}", expr);
            //итоговые значение
            Console.WriteLine("Итог: m={0}, n={1}", m, n);
            Console.WriteLine();
        }

        static void RunTask2()
        {
            Console.WriteLine("Задача 2");
            double x = ReadDouble("Введите X: ");
            double y = ReadDouble("Введите Y: ");

            bool inside = x * x + y * y <= 1 && !(x < 0 && y < 0);
            Console.WriteLine("Точка в области: {0}", inside);
            Console.WriteLine();
        }

        static void RunTask3()
        {
            Console.WriteLine("Задача 3");
            const double a = 1000, b = 0.0001;

            double d = CalcDouble(a, b);
            float f = CalcFloat((float)a, (float)b);

            Console.WriteLine("double = {0}", d);
            Console.WriteLine("float  = {0}", f);
            Console.WriteLine();
        }

        static double CalcDouble(double a, double b)
        {
            double s = a + b;
            return (Math.Pow(s, 4) - (Math.Pow(a, 4) + 4 * Math.Pow(a, 3) * b))
                 / (6 * a * a * b * b + 4 * a * b * b * b + b * b * b * b);
        }

        static float CalcFloat(float a, float b)
        {
            float s = a + b;
            float a2 = a * a, a3 = a2 * a, a4 = a3 * a, s4 = s * s * s * s;
            float b2 = b * b, b3 = b2 * b, b4 = b3 * b;
            return (s4 - (a4 + 4 * a3 * b)) / (6 * a2 * b2 + 4 * a * b3 + b4);
        }

        static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            string s = Console.ReadLine();
            int v;
            while (!int.TryParse(s, out v))
            {
                Console.Write("Неверный ввод, повторите: ");
                s = Console.ReadLine();
            }
            return v;
        }

        static double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            string s = Console.ReadLine();
            double v;
            while (!double.TryParse(s, out v))
            {
                Console.Write("Повторите: ");
                s = Console.ReadLine();
            }
            return v;
        }
    }
}