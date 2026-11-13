namespace Practice9;

public class Program
{
    public static void Main()
    {
        ConsoleUI ui = new ConsoleUI();

        ShowPartOne(ui);
        ShowPartTwo(ui);
        ShowPartThree(ui);
    }

    // Находит диапазон с максимальной верхней границей Y.
    public static Diapason? GetMaxDiapason(DiapasonArray ranges)
    {
        ArgumentNullException.ThrowIfNull(ranges);

        if (ranges.Length == 0)
        {
            return null;
        }

        Diapason max = ranges[0];

        for (int i = 1; i < ranges.Length; i++)
        {
            if (ranges[i].Y > max.Y)
            {
                max = ranges[i];
            }
        }

        return max;
    }

    private static void ShowPartOne(ConsoleUI ui)
    {
        ui.PrintHeader("Часть 1. Работа с объектами");

        Diapason first = new Diapason(1, 5);
        Diapason second = new Diapason(4, 8);
        Diapason third = new Diapason(10, 15);
        Diapason fourth = new Diapason(5, 9);

        ui.PrintMessage($"Первый диапазон: {first}");
        ui.PrintMessage($"Второй диапазон: {second}");
        ui.PrintMessage($"Третий диапазон: {third}");
        ui.PrintMessage($"Четвёртый диапазон: {fourth}");

        ui.PrintMessage($"Пересечение первого и второго: {Diapason.IsIntersects(first, second)}");
        ui.PrintMessage($"Пересечение первого и третьего: {first.IsIntersects(third)}");
        ui.PrintMessage($"Количество объектов Diapason: {Diapason.Count}");
    }

    private static void ShowPartTwo(ConsoleUI ui)
    {
        ui.PrintHeader("Часть 2. Перегрузка операторов");

        Diapason range = new Diapason(2, 7);

        ui.PrintMessage($"Исходный диапазон: {range}");
        ui.PrintNumber("Длина диапазона: ", !range);

        range++;
        ui.PrintMessage($"После ++: {range}");

        int xPart = range;
        double yValue = (double)range;

        ui.PrintMessage($"Преобразование в int: {xPart}");
        ui.PrintMessage($"Преобразование в double: {yValue}");

        Diapason subtractFromX = range - 2;
        Diapason subtractFromY = 2 - range;

        ui.PrintMessage($"После range - 2: {subtractFromX}");
        ui.PrintMessage($"После 2 - range: {subtractFromY}");

        Diapason other = new Diapason(5, 10);

        ui.PrintMessage($"Оператор < (пересекаются): {range < other}");
        ui.PrintMessage($"Оператор > (не пересекаются): {range > other}");
    }

    private static void ShowPartThree(ConsoleUI ui)
    {
        ui.PrintHeader("Часть 3. Класс-коллекция");

        DiapasonArray empty = new DiapasonArray();
        DiapasonArray randomRanges = new DiapasonArray(3);
        Diapason[] userValues = ui.ReadDiapasons();
        DiapasonArray userRanges = new DiapasonArray(userValues);

        ui.PrintMessage("Пустой массив:");
        ui.PrintMessage(empty.ToString());

        ui.PrintMessage("Массив со случайными значениями:");
        ui.PrintMessage(randomRanges.ToString());

        ui.PrintMessage("Массив с введёнными значениями:");
        ui.PrintMessage(userRanges.ToString());

        Diapason? max = GetMaxDiapason(userRanges);

        if (max is null)
        {
            ui.PrintMessage("В массиве нет диапазонов.");
        }
        else
        {
            ui.PrintMessage($"Диапазон с максимальным Y: {max}");
        }

        ui.PrintMessage($"Создано коллекций DiapasonArray: {DiapasonArray.Count}");
        ui.PrintMessage($"Создано объектов Diapason: {Diapason.Count}");
    }
}
