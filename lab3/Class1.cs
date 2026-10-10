using System;

namespace Laba3
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double a = 0.1;       // начало 
            double b = 1.0;       // конец 
            int k = 9;            // 9 интервалов = 10 точек
            int n = 10;           // число членов 
            double eps = 0.0001;  // точность 

            double h = (b - a) / k;   // шаг по методичке

            Console.WriteLine("Вычисление функции y=(1+2*x*x)*exp(x*x)");

            for (int i = 0; i <= k; i++)
            {
                double x = a + i * h;
                double sn = SumN(x, n);
                double se = SumEps(x, eps);
                double y = (1 + 2 * x * x) * Math.Exp(x * x);

                Console.WriteLine("X={0:F1}\tSN={1:F8}\tSE={2:F8}\tY={3:F8}",
                    x, sn, se, y);
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        // SN (арифметический цикл)
        static double SumN(double x, int n)
        {
            double sum = 1.0;
            double t = 1.0;

            for (int j = 1; j <= n; j++)
            {
                t = t * x * x / j;
                sum = sum + (2 * j + 1) * t;
            }

            return sum;
        }

        // SE (итерационный цикл)
        static double SumEps(double x, double eps)
        {
            double sum = 1.0;
            double t = 1.0;
            int j = 0;

            while (true)
            {
                j++;
                t = t * x * x / j;
                double next = (2 * j + 1) * t;

                if (next < eps)   // члены положительные, модуль не нужен
                    break;

                sum = sum + next;
            }

            return sum;
        }
    }
}
