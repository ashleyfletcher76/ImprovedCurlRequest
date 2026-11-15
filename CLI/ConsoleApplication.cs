using CLI.Handlers;
using CLI.Terminal;

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

            Uri url = _consoleInput.ParseRequest();
            switch (method)
            {
                case "GET" :
                    string result = await _getHandler.GetAsync(url);
                    Console.WriteLine(result);
                    break;
                default:
                    Console.WriteLine("Invalid request type");
                    break;
            }
        }
    }
}