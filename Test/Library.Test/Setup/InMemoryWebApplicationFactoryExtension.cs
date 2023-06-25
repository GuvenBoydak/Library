using System.Net.Http.Headers;
using System.Net.Http.Json;
using Library.Application.DTOs;
using Library.Test.Dtos;
using Newtonsoft.Json;

namespace Library.Test.Setup;

public static class InMemoryWebApplicationFactoryExtension
{
    public static HttpClient HttpClientFactory(this InMemoryWebApplicationFactory<Program> factory)
    {
        var client = factory.CreateClient();

        var loginUserDto = new LoginUserDto() { Email = "admin@admin.com", Password = "123456" };

        var response = client.PostAsJsonAsync("api/Users/login", loginUserDto).GetAwaiter().GetResult();

        var token = JsonConvert.DeserializeObject<Dtos.ResponseDto<TokenDto>>(response.Content.ReadAsStringAsync()
            .Result);

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", $"{token.Data.AccessToken}");

        return client;
    }  
}