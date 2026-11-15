using CLI.Handlers;
using CLI.Services;
using CLI.Terminal;

namespace CLI;

class Program
{
    static async Task Main(string[] args)
    {
        // create and inject dependencies
        HttpClient client = new HttpClient();
        GetHandler getHandler = new GetHandler(client);
        ConsoleInput consoleInput = new ConsoleInput();
        HttpRequestService requestService = new HttpRequestService(getHandler);
        
        ConsoleApplication app = new ConsoleApplication(consoleInput, requestService);
        await app.RunAsync();
    }
}