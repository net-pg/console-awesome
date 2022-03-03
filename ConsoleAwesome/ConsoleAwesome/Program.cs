using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace ConsoleAwesome;

public static class Program
{

    /// <summary>
    /// Retrieves configuration from appsettings.json file.
    /// </summary>
    /// <returns>Application configuration.</returns>
    public static ApplicationConfiguration GetConfiguration()
    {
        // create config class object
        var config = new ApplicationConfiguration();
        // use configuration builder to populate key/value based settings and bound them to custom config object
        // For more information about ConfigurationBuilder see
        // https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.configurationbuilder?view=dotnet-plat-ext-6.0
        new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().Bind(config);
        return config;
    }

    public static void Greet(ApplicationConfiguration configuration)
    {
        // Create console prompt using Spectre.Console library that asks user to select one of available choices
        // In this prompt, choice is a custom enum type that exists in Mode.cs file
        // For more information about SelectionPrompt see
        // https://spectreconsole.net/prompts/selection
        var mode = AnsiConsole.Prompt(new SelectionPrompt<Mode>()
            .Title("Select authentication mode: ")
            .AddChoices(
                Mode.Anonymous,
                Mode.Authenticated)
        );

        if (mode == Mode.Anonymous)
        {
            // Spectre.Console allows using custom markup for better styling in console window
            // For more information about Spectre.Console markup see
            // https://spectreconsole.net/markup
            AnsiConsole.MarkupLine($"[{configuration.TextColor} on {configuration.BackgroundColor}]Hello Anonymous![/]");
            return;
        }

        // Create console prompt that asks user for text input (string as generic parameter)
        // For more information about TextPrompt see
        // https://spectreconsole.net/prompts/text
        var name = AnsiConsole.Prompt(new TextPrompt<string>("Enter your name: "));
        AnsiConsole.MarkupLine($"[{configuration.TextColor} on {configuration.BackgroundColor}]Hello {name}![/]");
    }

    public static void Main(string[] args)
    {
        var config = GetConfiguration();

        Greet(config);

        double number, output = 0;
        var expression = new MathExpression();
        var calculator = new Calculator();
        // Main program loop allows program to run indefinitely (until switch case "Exit" or default leaves this loop)
        while (true)
        {
            // Create console prompt that asks user to select one of available choices
            // In this prompt, choice is a string type
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

            // Perform operation selected by user
            switch (operation)
            {
                case "Show output":
                    AnsiConsole.MarkupLine($"[{config.TextColor}]${expression}[/]");
                    break;
                case "Add":
                    // Create console prompt that asks user for number input (double as generic parameter)
                    number = AnsiConsole.Prompt(new TextPrompt<double>("Enter number: "));
                    // Call methods of objects from Calculator.cs and MathExpression.cs files
                    output = calculator.Add(output, number);
                    expression.AddOperation('+', number, output.ToExpressionNumber());
                    break;
                case "Subtract":
                    // Create console prompt that asks user for number input (double as generic parameter)
                    number = AnsiConsole.Prompt(new TextPrompt<double>("Enter number: "));
                    // Call methods of objects from Calculator.cs and MathExpression.cs files
                    output = calculator.Subtract(output, number);
                    expression.AddOperation('-', number, output.ToExpressionNumber());
                    break;
                case "Multiply":
                    // Create console prompt that asks user for number input (double as generic parameter)
                    number = AnsiConsole.Prompt(new TextPrompt<double>("Enter number: "));
                    // Call methods of objects from Calculator.cs and MathExpression.cs files
                    output = calculator.Multiply(output, number);
                    expression.AddOperation('*', number, output.ToExpressionNumber());
                    break;
                case "Divide":
                    // Create console prompt that asks user for number input (double as generic parameter)
                    number = AnsiConsole.Prompt(new TextPrompt<double>("Enter number: "));
                    // Use try/catch that catches DivideByZeroException (if user tries to divide by 0)
                    try
                    {
                        // Call methods of objects from Calculator.cs and MathExpression.cs files
                        output = calculator.Divide(output, number);
                        expression.AddOperation('/', number, output.ToExpressionNumber());
                    }
                    catch (DivideByZeroException e)
                    {
                        // Show exception message as error
                        AnsiConsole.MarkupLine($"[red]{e.Message}[/]");
                    }
                    break;
                case "Exit":
                default:
                    // handle "Exit" and all default (unhandled) cases like this
                    AnsiConsole.MarkupLine($"[{config.TextColor}]${expression}[/]");
                    return;
            }
        }
    }
}