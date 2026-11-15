using CLI.Handlers;
using CLI.Services;
using CLI.Terminal;

namespace CLI;

class Program
{
    static void Main(string[] args)
    {
        HttpClient client = new HttpClient();
        GetHandler getHandler = new GetHandler(client);
        HttpRequestService requestService = new HttpRequestService();
        ConsoleInput consoleInput = new ConsoleInput();
        
        ConsoleApplication app = new ConsoleApplication(requestService, consoleInput, getHandler);
        app.RunAsync();
    }
}