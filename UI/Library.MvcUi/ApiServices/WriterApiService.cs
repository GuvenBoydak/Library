using System.Net.Http.Headers;
using Library.MvcUi.Models.Writer;

namespace Library.MvcUi.ApiServices;

public class WriterApiService
{
    private readonly HttpClient _httpClient;

    public WriterApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<bool> AddAsync(string token, WriterModel model)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PostAsJsonAsync("Writers", model);

        return response.IsSuccessStatusCode;
    }
}