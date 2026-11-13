namespace Practice9;

public class DiapasonArray
{
    private Diapason[] ranges;
    private static int count;

    public DiapasonArray()
    {
        ranges = new Diapason[0];
        count++;
    }

    public DiapasonArray(int length)
    {
        if (length < 0)
        {
            throw new ArgumentException("Размер массива не может быть отрицательным.");
        }

        ranges = new Diapason[length];
        FillWithRandomRanges();
        count++;
    }

    public DiapasonArray(Diapason[] values)
    {
        ArgumentNullException.ThrowIfNull(values);

        ranges = new Diapason[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            ranges[i] = values[i] ?? throw new ArgumentException("Массив не должен содержать null.");
        }

        count++;
    }

    public static int Count => count;

    public int Length => ranges.Length;

    public Diapason this[int index]
    {
        get
        {
            ValidateIndex(index);
            return ranges[index];
        }
        set
        {
            ValidateIndex(index);
            ranges[index] = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    public override string ToString()
    {
        if (ranges.Length == 0)
        {
            return "Массив пуст.";
        }

        string result = "";

        for (int i = 0; i < ranges.Length; i++)
        {
            result += $"[{i}] {ranges[i]}";

            if (i < ranges.Length - 1)
            {
                result += Environment.NewLine;
            }
        }

        return result;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= ranges.Length)
        {
            throw new ArgumentException("Индекс находится за пределами массива.");
        }
    }

    // Заполняет массив случайными диапазонами.
    private void FillWithRandomRanges()
    {
        Random random = new Random();

        for (int i = 0; i < ranges.Length; i++)
        {
            double start = random.Next(-10, 11);
            double length = random.Next(0, 11);
            ranges[i] = new Diapason(start, start + length);
        }
    }
}
