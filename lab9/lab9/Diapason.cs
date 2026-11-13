using System.Globalization;

namespace Practice9;

public class Diapason
{
    private double x;
    private double y;
    private static int count;

    public Diapason()
        : this(0, 0)
    {
    }

    public Diapason(double x, double y)
    {
        X = x;
        Y = y;
        count++;
    }

    public double X
    {
        get => x;
        set => x = value;
    }

    public double Y
    {
        get => y;
        set => y = value;
    }

    public static int Count => count;

    // Проверяет пересечение двух диапазонов.
    public static bool IsIntersects(Diapason first, Diapason second)
    {
        ArgumentNullException.ThrowIfNull(first);
        ArgumentNullException.ThrowIfNull(second);

        return !(first.Y < second.X || second.Y < first.X);
    }

    public bool IsIntersects(Diapason other)
    {
        return IsIntersects(this, other);
    }

    public override string ToString()
    {
        return $"[{FormatCoordinate(X)}; {FormatCoordinate(Y)}]";
    }

    // Возвращает длину диапазона.
    public static double operator !(Diapason diapason)
    {
        ArgumentNullException.ThrowIfNull(diapason);
        return diapason.y - diapason.x;
    }

    public static Diapason operator ++(Diapason diapason)
    {
        ArgumentNullException.ThrowIfNull(diapason);
        return new Diapason(diapason.x + 1, diapason.y + 1);
    }

    // Неявное преобразование возвращает целую часть X.
    public static implicit operator int(Diapason diapason)
    {
        ArgumentNullException.ThrowIfNull(diapason);
        return (int)diapason.x;
    }

    public static explicit operator double(Diapason diapason)
    {
        ArgumentNullException.ThrowIfNull(diapason);
        return diapason.y;
    }

    public static Diapason operator -(Diapason diapason, int value)
    {
        ArgumentNullException.ThrowIfNull(diapason);
        return new Diapason(diapason.x - value, diapason.y);
    }

    public static Diapason operator -(int value, Diapason diapason)
    {
        ArgumentNullException.ThrowIfNull(diapason);
        return new Diapason(diapason.x, diapason.y - value);
    }

    // По условию варианта оператор < проверяет пересечение.
    public static bool operator <(Diapason first, Diapason second)
    {
        return IsIntersects(first, second);
    }

    public static bool operator >(Diapason first, Diapason second)
    {
        return !IsIntersects(first, second);
    }

    private static string FormatCoordinate(double value)
    {
        return value.ToString("0.###", CultureInfo.InvariantCulture);
    }
}
