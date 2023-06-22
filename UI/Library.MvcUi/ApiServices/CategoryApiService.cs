using System.Net.Http.Headers;
using Library.MvcUi.Models;
using Library.MvcUi.Models.Book;
using Library.MvcUi.Models.Category;
using Newtonsoft.Json;

namespace Library.MvcUi.ApiServices;

public class CategoryApiService
{
    private readonly HttpClient _httpClient;

    public CategoryApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<CategoryModel>> GetAllAsync(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var responseDto = await _httpClient.GetFromJsonAsync<ResponseDto<List<CategoryModel>>>("Categories");

        return responseDto.Data;
    }
    
    public async Task<CategoryModel> GetByIdAsync(int id, string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        
        var responseDto = await _httpClient.GetFromJsonAsync<ResponseDto<CategoryModel>>($"Categories/GetById/{id}");

        return responseDto.Data;
    }

    public async Task<List<CategoryModel>> GetByIdsAsync(List<Guid> ids, string token)
    {
        var model = new GetByIdsCategoryInput { Ids = ids };

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PostAsJsonAsync("Categories/GetByIds", model);

        var categories = JsonConvert.DeserializeObject<ResponseDto<List<CategoryModel>>>(await response.Content.ReadAsStringAsync());

        return categories.Data;
    }

    public async Task<bool> AddAsync(string token, CategoryModel model)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PostAsJsonAsync("Categories", model);

        return response.IsSuccessStatusCode;
    }
}