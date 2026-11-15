using CLI.Handlers;
using CLI.Terminal;

namespace CLI;

class Program
{
    static void Main(string[] args)
    {
        HttpClient client = new HttpClient();
        GetHandler getHandler = new GetHandler(client);
        ConsoleInput consoleInput = new ConsoleInput();
        
        ConsoleApplication app = new ConsoleApplication(consoleInput, getHandler);
        app.RunAsync().Wait();
    }
}