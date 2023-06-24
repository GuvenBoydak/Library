using System.Collections.Generic;
using System.Net.Http.Headers;
using Library.MvcUi.Models;
using Library.MvcUi.Models.Order;

namespace Library.MvcUi.ApiServices;

public class OrderApiService
{
    private readonly HttpClient _httpClient;

    public OrderApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<OrderModel>> GetAllAsync(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var responseDto = await _httpClient.GetFromJsonAsync<ResponseDto<List<OrderModel>>>("Orders");

        return responseDto.Data;
    }

    public async Task<List<OrderModel>> GetOrdersByUserIdAsync(Guid id, string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var responseDto = await _httpClient.GetFromJsonAsync<ResponseDto<List<OrderModel>>>($"Orders/{id}");

        return responseDto.Data;
    }

    public async Task<bool> AddAsync(string token, AddOrderInput model)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PostAsJsonAsync("Orders", model);

        return response.IsSuccessStatusCode;
    }
}