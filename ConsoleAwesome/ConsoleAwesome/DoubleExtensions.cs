namespace ConsoleAwesome;

// For more information about extension methods see
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
public static class DoubleExtensions
{
    /// <summary>
    /// Converts number to string for printing in math expressions (adds parentheses if number is negative).
    /// </summary>
    /// <param name="number">Number to be expressed as part of math expressions.</param>
    /// <returns>Number expressed as part of math expressions.</returns>
    public static string ToExpressionNumber(this double number)
    {
        if (number < 0)
        {
            return $"({number})";
        }

        return number.ToString();
    }
}