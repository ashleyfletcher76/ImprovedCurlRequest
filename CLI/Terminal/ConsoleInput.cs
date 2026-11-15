using Spectre.Console;

namespace CLI.Terminal;

public class ConsoleInput
{
    public string ReadMethod()
    {
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a [red]method.[/]")
                .PageSize(10)
                .AddChoices("GET")
        );

        return userInput;
    }
    
    public Uri? ParseRequest()
    {
        var userInput = AnsiConsole.Ask<string>("Enter URL: ");
        Uri? url =  ValidateUrl(userInput);
        return url == null ? null : url;
    }
    
    private Uri? ValidateUrl(string url)
    {
        if (Uri.TryCreate(url, UriKind.Absolute, out var uri) 
            && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
        {
            return uri;
        }

        return null;
    }
}