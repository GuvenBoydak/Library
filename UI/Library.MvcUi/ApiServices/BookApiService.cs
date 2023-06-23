using System;
using System.Net.Http.Headers;
using Library.MvcUi.Helper;
using Library.MvcUi.Models;
using Library.MvcUi.Models.Book;
using Newtonsoft.Json;

namespace Library.MvcUi.ApiServices;

public class BookApiService
{
    private readonly HttpClient _httpClient;

    public BookApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BookModel>> GetAllAsync(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<BookModel>>>("Books");

        return response.Data;
    }

    public async Task<BookModel> GetByIdAsync(Guid id, string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetFromJsonAsync<ResponseDto<BookModel>>($"Books/GetById/{id}");

        return response.Data;
    }

    public async Task<List<BookModel>> GetByIdsAsync(List<Guid> ids, string token)
    {
        var model = new GetByIdsBookInput { Ids = ids };

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PostAsJsonAsync("Books/GetByIds", model);

        var books = JsonConvert.DeserializeObject<ResponseDto<List<BookModel>>>(await response.Content.ReadAsStringAsync());

        return books.Data;
    }

    public async Task<bool> AddAsync(string token, AddBookInput input)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var model = new BookModel
        {
            Name = input.Name,
            CategoryId = input.CategoryId,
            WriterId = input.WriterId,
            ImageUrl = $"https://localhost:7241/Uploads/{FileHelper.Add(input.ImageUrl, "wwwroot\\Uploads\\")}"
        };

        var response = await _httpClient.PostAsJsonAsync("Books", model);

        return response.IsSuccessStatusCode;
    }
}