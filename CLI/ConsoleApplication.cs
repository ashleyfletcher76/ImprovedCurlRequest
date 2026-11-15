using CLI.Handlers;
using CLI.Terminal;
using CLI.Services;

namespace CLI;

public class ConsoleApplication
{
    private readonly HttpRequestService _httpRequestService;
    private readonly ConsoleInput _consoleInput;
    private readonly GetHandler _getHandler;
    
    public ConsoleApplication(HttpRequestService httpRequestService, ConsoleInput input, GetHandler getHandler)
    {
        _httpRequestService = httpRequestService;
        _consoleInput = input;
        _getHandler = getHandler;
    }
    
    public void RunAsync()
    {
        while (true)
        {
            string? url = _consoleInput.ReadUserRequest();
            if (string.IsNullOrWhiteSpace(url))
            {
                Console.WriteLine("Valid URL required");
                continue;
            }

            string method = _httpRequestService.ParseRequest(url);
            switch (method)
            {
                case "GET" :
                    string result = _getHandler.GetAsync(url).Result;
                    Console.WriteLine(result);
                    break;
                default:
                    Console.WriteLine("Invalid request type");
                    break;
            }

        }
    }
}