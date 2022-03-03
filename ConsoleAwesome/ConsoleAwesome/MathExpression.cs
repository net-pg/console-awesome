namespace ConsoleAwesome;

public class MathExpression
{
    public string Expression { get; set; } = "0";
    public string Output { get; set; } = "0";

    public override string ToString()
    {
        return $"{Expression}={Output}";
    }

    /// <summary>
    /// Adds operation to math expression.
    /// </summary>
    /// <param name="operator">Operation's operator.</param>
    /// <param name="number">Second number of the operation.</param>
    /// <param name="output">Expression output after added operation.</param>
    public void AddOperation(char @operator, double number, string output)
    {
        Output = output;
        if (@operator is '*' or '/')
        {
            Expression = $"({Expression}){@operator}{number.ToExpressionNumber()}";
            return;
        }
        Expression = $"{Expression}{@operator}{number.ToExpressionNumber()}";
    }
}