using CLI.Handlers;
using CLI.Terminal;
using Spectre.Console;

namespace CLI;

public class ConsoleApplication
{
    private readonly ConsoleInput _consoleInput;
    private readonly GetHandler _getHandler;
    
    public ConsoleApplication(ConsoleInput input, GetHandler getHandler)
    {
        _consoleInput = input;
        _getHandler = getHandler;
    }
    
    public async Task RunAsync()
    {
        while (true)
        {
            string method = _consoleInput.ReadMethod();

            Uri? url = _consoleInput.ParseRequest();
            while (url == null)
            {
                AnsiConsole.MarkupLine("[red]Invalid URL[/]");
                if (url != null) break;
                url = _consoleInput.ParseRequest();
            }
            switch (method)
            {
                case "GET" :
                {
                    using HttpResponseMessage result = await _getHandler.GetAsync(url);
                    AnsiConsole.MarkupLine($"[green]{result.StatusCode}[/]");
                    AnsiConsole.MarkupLine($"[green]{result.RequestMessage}[/]");
                    break;
                }
                default:
                    Console.WriteLine("Invalid request type");
                    break;
            }
        }
    }
}