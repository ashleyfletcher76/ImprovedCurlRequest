using CLI.Handlers;
using Spectre.Console;

namespace CLI.Services;

public class HttpRequestService
{
    private readonly GetHandler _getHandler;

    public HttpRequestService(GetHandler get)
    {
        _getHandler = get;
    }

    public async Task ProcessRequest(string method, Uri url)
    {
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
                AnsiConsole.MarkupLine($"[red]Invalid request type[/]");
                break;
        }
    }
}