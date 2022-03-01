namespace ConsoleAwesome;

public class Calculator
{
    public double Add(params double[] numbers)
    {
        var sum = 0d;
        for (var i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    public double Subtract(double x, double y)
    {
        return x - y;
    }

    public double Multiply(double x, double y)
    {
        return x * y;
    }

    public double Divide(double x, double y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Can not divide by 0!");
        }
        return x / y;
    }
}