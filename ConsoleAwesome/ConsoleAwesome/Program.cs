using Spectre.Console;

namespace ConsoleAwesome;

public static partial class Program
{
    public static void Main(string[] args)
    {
        var mode = AnsiConsole.Prompt(new SelectionPrompt<Mode>()
            .Title("Select authentication mode: ")
            .AddChoices(
                Mode.Anonymous,
                Mode.Authenticated)
            );

        if (mode == Mode.Anonymous)
        {
            AnsiConsole.Markup("[blue]Hello Anonymous![/]");
            return;
        }

        var name = AnsiConsole.Prompt(new TextPrompt<string>("Enter your name: "));

        AnsiConsole.Markup($"[blue]Hello {name}![/]");
    }
}