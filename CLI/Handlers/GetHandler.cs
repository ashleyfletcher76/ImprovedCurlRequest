using System.Net;

namespace CLI.Handlers;

public class GetHandler
{
    private readonly HttpClient _client;
    
    public GetHandler(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> GetAsync(Uri uri)
    {
        var result = await _client.GetAsync(uri);
        switch (result.StatusCode)
        {
            case HttpStatusCode.OK:
                break;
            case HttpStatusCode.NotFound:
                throw new HttpRequestException($"Resource not found at {uri}");
            default:
                throw new HttpRequestException($"Unexpected status code: {result.StatusCode}");
        }
        return await result.Content.ReadAsStringAsync();
    }
}