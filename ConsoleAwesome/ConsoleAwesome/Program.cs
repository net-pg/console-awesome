using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace ConsoleAwesome;

public static partial class Program
{
    public static ApplicationConfiguration GetConfiguration()
    {
        var config = new ApplicationConfiguration();
        new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().Bind(config);
        return config;
    }

    public static void Greet(ApplicationConfiguration configuration)
    {
        var mode = AnsiConsole.Prompt(new SelectionPrompt<Mode>()
            .Title("Select authentication mode: ")
            .AddChoices(
                Mode.Anonymous,
                Mode.Authenticated)
        );

        if (mode == Mode.Anonymous)
        {
            AnsiConsole.MarkupLine($"[{configuration.TextColor} on {configuration.BackgroundColor}]Hello Anonymous![/]");
            return;
        }

        var name = AnsiConsole.Prompt(new TextPrompt<string>("Enter your name: "));
        AnsiConsole.MarkupLine($"[{configuration.TextColor} on {configuration.BackgroundColor}]Hello {name}![/]");
    }

    public static void Main(string[] args)
    {
        var config = GetConfiguration();

        Greet(config);

        double number;
        var output = 0d;
        var expression = new MathExpression();
        var calculator = new Calculator();
        while (true)
        {
            var operation = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select operation: ")
                .AddChoices(
                    "Show output",
                    "Add",
                    "Subtract",
                    "Multiply",
                    "Divide",
                    "Exit"
                ));

            switch (operation)
            {
                case "Show output":
                    AnsiConsole.MarkupLine($"[{config.TextColor}]${expression}[/]");
                    break;
                case "Add":
                    number = AnsiConsole.Prompt(new TextPrompt<double>("Enter number: "));
                    output = calculator.Add(output, number);
                    expression.AddOperation('+', number, output.ToExpressionNumber());
                    break;
                case "Subtract":
                    number = AnsiConsole.Prompt(new TextPrompt<double>("Enter number: "));
                    output = calculator.Subtract(output, number);
                    expression.AddOperation('-', number, output.ToExpressionNumber());
                    break;
                case "Multiply":
                    number = AnsiConsole.Prompt(new TextPrompt<double>("Enter number: "));
                    output = calculator.Multiply(output, number);
                    expression.AddOperation('*', number, output.ToExpressionNumber());
                    break;
                case "Divide":
                    number = AnsiConsole.Prompt(new TextPrompt<double>("Enter number: "));
                    try
                    {
                        output = calculator.Divide(output, number);
                        expression.AddOperation('/', number, output.ToExpressionNumber());
                    }
                    catch (DivideByZeroException e)
                    {
                        AnsiConsole.MarkupLine($"[red]{e.Message}[/]");
                    }
                    break;
                case "Exit":
                default:
                    AnsiConsole.MarkupLine($"[{config.TextColor}]${expression}[/]");
                    return;
            }
        }
    }
}