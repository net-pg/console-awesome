namespace ConsoleAwesome;

public static class DoubleExtensions
{
    public static string ToExpressionNumber(this double number)
    {
        if (number < 0)
        {
            return $"({number})";
        }

        return number.ToString();
    }
}