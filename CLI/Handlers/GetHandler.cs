using System.Net;

namespace CLI.Handlers;

public class GetHandler
{
    private readonly HttpClient _client;
    
    public GetHandler(HttpClient client)
    {
        _client = client;
    }

    public async Task<HttpResponseMessage> GetAsync(Uri uri)
    {
        var result = await _client.GetAsync(uri);
        return result;
    }
}