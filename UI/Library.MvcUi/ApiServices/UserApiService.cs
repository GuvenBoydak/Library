using System.Net.Http.Headers;
using Library.MvcUi.Models;
using Library.MvcUi.Models.User;
using System.Text.Json;

namespace Library.MvcUi.ApiServices;

public class UserApiService
{
    private readonly HttpClient _httpClient;

    public UserApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserModel> GetByEmailAsync(string token, string email)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetFromJsonAsync<ResponseDto<UserModel>>($"Users/{email}");

        return response.Data;
    }

    public async Task<HttpResponseMessage> RegisterAsync(RegisterModel model)
    {
        var response = await _httpClient.PostAsJsonAsync("Users/Register", model);

        return response;
    }

    public async Task<HttpResponseMessage> LoginAsync(LoginModel model)
    {
        var response = await _httpClient.PostAsJsonAsync("Users/Login", model);

        return response;
    }
}