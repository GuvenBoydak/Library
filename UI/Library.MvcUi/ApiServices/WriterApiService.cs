using System.Net.Http.Headers;
using Library.MvcUi.Models;
using Library.MvcUi.Models.Book;
using Library.MvcUi.Models.Writer;
using Newtonsoft.Json;

namespace Library.MvcUi.ApiServices;

public class WriterApiService
{
    private readonly HttpClient _httpClient;

    public WriterApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<WriterModel>> GetAllAsync(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<WriterModel>>>("Writers");

        return response.Data;
    }

    public async Task<List<WriterModel>> GetByIdsAsync(List<Guid> ids, string token)
    {
        var model = new GetByIdsWriterInput { Ids = ids };

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PostAsJsonAsync("Writers/GetByIds", model);

        var writers = JsonConvert.DeserializeObject<ResponseDto<List<WriterModel>>>(await response.Content.ReadAsStringAsync());

        return writers.Data;
    }

    public async Task<bool> AddAsync(string token, WriterModel model)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PostAsJsonAsync("Writers", model);

        return response.IsSuccessStatusCode;
    }
}