using System.Globalization;

namespace Practice9;

public class ConsoleUI
{
    public int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }

            Console.WriteLine("Введите целое число.");
        }
    }

    public int ReadNonNegativeInt(string message)
    {
        while (true)
        {
            int value = ReadInt(message);

            if (value >= 0)
            {
                return value;
            }

            Console.WriteLine("Число не должно быть отрицательным.");
        }
    }

    public double ReadDouble(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (TryParseDouble(input, out double value))
            {
                return value;
            }

            Console.WriteLine("Введите корректное число.");
        }
    }

    public Diapason[] ReadDiapasons()
    {
        int length = ReadNonNegativeInt("Введите количество диапазонов: ");
        Diapason[] values = new Diapason[length];

        for (int i = 0; i < length; i++)
        {
            Console.WriteLine($"Диапазон {i + 1}:");

            double start = ReadDouble("Введите X: ");
            double end;

            do
            {
                end = ReadDouble("Введите Y: ");

                if (end < start)
                {
                    Console.WriteLine("Y не может быть меньше X.");
                }
            }
            while (end < start);

            values[i] = new Diapason(start, end);
        }

        return values;
    }

    public static bool TryParseDouble(string? input, out double value)
    {
        value = 0;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        string normalized = input.Trim().Replace(',', '.');

        return double.TryParse(
                   normalized,
                   NumberStyles.Float,
                   CultureInfo.InvariantCulture,
                   out value)
               && !double.IsNaN(value)
               && !double.IsInfinity(value);
    }

    public void PrintDiapason(Diapason diapason)
    {
        Console.WriteLine(diapason);
    }

    public void PrintHeader(string message)
    {
        Console.WriteLine();
        Console.WriteLine($"--- {message} ---");
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintNumber(string message, double value)
    {
        Console.WriteLine($"{message}{value}");
    }
}
