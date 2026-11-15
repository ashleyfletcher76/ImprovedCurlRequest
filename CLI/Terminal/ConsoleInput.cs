using Spectre.Console;

namespace CLI.Terminal;

public class ConsoleInput
{
    public string? ReadUserRequest()
    {
        var read = AnsiConsole.Ask<string>("Enter URL: ");
        if (string.IsNullOrWhiteSpace(read) || !ValidateUrl(read))
        {
            return null;
        }

        return read;
    }

    private bool ValidateUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uri) 
               && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }
}