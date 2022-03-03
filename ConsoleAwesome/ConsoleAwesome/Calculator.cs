namespace ConsoleAwesome;

public class Calculator
{
    /// <summary>
    /// Adds all numbers passed as parameters.
    /// </summary>
    /// <param name="numbers">Array of numbers to be added.</param>
    /// <returns>Sum of numbers.</returns>
    public double Add(params double[] numbers)
    {
        double sum = 0;
        for (var i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    /// <summary>
    /// Subtracts numbers passed as parameters.
    /// </summary>
    /// <param name="x">Minuend.</param>
    /// <param name="y">Subtrahend.</param>
    /// <returns>Difference of two numbers.</returns>
    public double Subtract(double x, double y)
    {
        return x - y;
    }

    /// <summary>
    /// Multiplies numbers passed as parameters.
    /// </summary>
    /// <param name="x">Multiplicand.</param>
    /// <param name="y">Multiplier.</param>
    /// <returns>Product of two numbers.</returns>
    public double Multiply(double x, double y)
    {
        return x * y;
    }

    /// <summary>
    /// Divides numbers passed as parameters.
    /// </summary>
    /// <param name="x">Dividend.</param>
    /// <param name="y">Divisor.</param>
    /// <returns>Quotient of two numbers.</returns>
    /// <exception cref="DivideByZeroException">Thrown when trying to divide by 0.</exception>
    public double Divide(double x, double y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Can not divide by 0!");
        }
        return x / y;
    }
}