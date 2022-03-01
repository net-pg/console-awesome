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

    public static void Main(string[] args)
    {
        var config = GetConfiguration();
        
        var mode = AnsiConsole.Prompt(new SelectionPrompt<Mode>()
            .Title("Select authentication mode: ")
            .AddChoices(
                Mode.Anonymous,
                Mode.Authenticated)
            );

        if (mode == Mode.Anonymous)
        {
            AnsiConsole.Markup($"[{config.TextColor} on {config.BackgroundColor}]Hello Anonymous![/]");
            return;
        }

        var name = AnsiConsole.Prompt(new TextPrompt<string>("Enter your name: "));

        AnsiConsole.Markup($"[{config.TextColor} on {config.BackgroundColor}]Hello {name}![/]");
    }
}