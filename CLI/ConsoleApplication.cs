using CLI.Handlers;
using CLI.Services;
using CLI.Terminal;
using Spectre.Console;

namespace CLI;

public class ConsoleApplication
{
    private readonly ConsoleInput _consoleInput;
    private readonly HttpRequestService _requestService;
    
    public ConsoleApplication(ConsoleInput input, HttpRequestService requestService)
    {
        _consoleInput = input;
        _requestService = requestService;
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
            await _requestService.ProcessRequest(method, url);
        }
    }
}