using System.Net;

namespace CLI.Handlers;

public class GetHandler
{
    private readonly HttpClient _client;
    
    public GetHandler(HttpClient client)
    {
        _client = client;
    }

    public async Task<HttpResponseMessage> GetAsync(Uri uri) => await _client.GetAsync(uri);
}