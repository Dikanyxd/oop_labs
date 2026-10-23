using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int choice;

        do
        {
            Console.WriteLine("1. Двумерный массив: удалить строку");
            Console.WriteLine("2. Рваный массив: добавить строки");
            Console.WriteLine("3. Строка: удалить первое и последнее предложение");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ошибка: введите число.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Task1(rnd);
                    break;
                case 2:
                    Task2(rnd);
                    break;
                case 3:
                    Task3();
                    break;
                case 0:
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.WriteLine("Нет такого пункта, попробуйте снова.");
                    break;
            }
        } while (choice != 0);
    }

    // Задание 1: удалить строку с номером K из двумерного массива
    static void Task1(Random rnd)
    {
        Console.Write("Количество строк: ");
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0)
        {
            Console.WriteLine("Ошибка: нужно положительное число.");
            return;
        }

        Console.Write("Количество столбцов: ");
        if (!int.TryParse(Console.ReadLine(), out int cols) || cols <= 0)
        {
            Console.WriteLine("Ошибка: нужно положительное число.");
            return;
        }

        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = rnd.Next(1, 10);

        Console.WriteLine("Исходный массив:");
        PrintMatrix(matrix);

        Console.Write($"Номер строки для удаления (1..{rows}): ");
        if (!int.TryParse(Console.ReadLine(), out int k) || k < 1 || k > rows)
        {
            Console.WriteLine("Ошибка: неверный номер строки.");
            return;
        }

        Console.WriteLine("Результат:");
        for (int i = 0; i < rows; i++)
        {
            if (i == k - 1) continue;
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }

    // Задание 2: добавить K строк в рваный массив, начиная с номера N
    static void Task2(Random rnd)
    {
        Console.Write("Количество строк: ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            Console.WriteLine("Ошибка: нужно положительное число.");
            return;
        }

        int[][] jag = new int[count][];
        for (int i = 0; i < count; i++)
        {
            jag[i] = new int[rnd.Next(1, 6)];
            for (int j = 0; j < jag[i].Length; j++)
                jag[i][j] = rnd.Next(0, 10);
        }

        Console.WriteLine("Исходный рваный массив:");
        PrintJagged(jag);

        Console.Write("Сколько строк добавить (K): ");
        if (!int.TryParse(Console.ReadLine(), out int addCount) || addCount < 0)
        {
            Console.WriteLine("Ошибка: нужно неотрицательное число.");
            return;
        }

        Console.Write($"С какого номера вставить (1..{count + 1}): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 1 || n > count + 1)
        {
            Console.WriteLine("Ошибка: неверный номер позиции.");
            return;
        }

        int[][] result = new int[count + addCount][];
        int srcIndex = 0;
        for (int i = 0; i < result.Length; i++)
        {
            if (i >= n - 1 && i < n - 1 + addCount)
            {
                result[i] = new int[rnd.Next(1, 6)];
                for (int j = 0; j < result[i].Length; j++)
                    result[i][j] = rnd.Next(0, 10);
            }
            else
            {
                result[i] = jag[srcIndex];
                srcIndex++;
            }
        }

        Console.WriteLine("Результат:");
        PrintJagged(result);
    }

    // Задание 3: удалить первое и последнее предложение
    static void Task3()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Ошибка: пустая строка.");
            return;
        }

        MatchCollection sentences = Regex.Matches(text, @"[^.!?]*[.!?]");

        if (sentences.Count < 3)
        {
            Console.WriteLine("Недостаточно предложений для удаления первого и последнего.");
            return;
        }

        string result = "";
        for (int i = 1; i < sentences.Count - 1; i++)
            result += sentences[i].Value;

        Console.WriteLine("Результат: " + result.Trim());
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }

    static void PrintJagged(int[][] jag)
    {
        foreach (int[] row in jag)
        {
            foreach (int x in row)
                Console.Write(x + " ");
            Console.WriteLine();
        }
    }
}