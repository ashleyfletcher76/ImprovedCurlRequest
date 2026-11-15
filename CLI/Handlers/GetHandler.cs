namespace CLI.Handlers;

public class GetHandler
{
    private readonly HttpClient _client;
    
    public GetHandler(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> GetAsync(string uri)
    {
        var result = await _client.GetAsync(uri);
        if (!result.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error occurred while fetching data from {uri}");
        }
        return await result.Content.ReadAsStringAsync();
    }
}