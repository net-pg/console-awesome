namespace ConsoleAwesome;

public class MathExpression
{
    public string Expression { get; set; } = "0";
    public string Output { get; set; } = "0";

    public override string ToString()
    {
        return $"{Expression}={Output}";
    }

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