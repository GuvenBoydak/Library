using System.Net;
using System.Net.Http.Json;
using Library.Application.DTOs;
using Library.Application.DTOs.User;
using Library.Application.Features.Command.User.LoginUser;
using Library.Application.Features.Command.User.RegisterUser;
using Library.Test.FakeEntity;
using Library.Test.Setup;
using Newtonsoft.Json;

namespace Library.Test.ControllerTest;

public class UsersControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;

    public UsersControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task should_success_get_all_users()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync("/api/Users");

        var userList = JsonConvert.DeserializeObject<ResponseDto<List<UserListDto>>>(response);

        // assert
        Assert.Equal(200, userList.StatusCode);
        Assert.NotNull(userList.Data);
    }
    
    [Fact]
    public async Task should_success_get_by_user_email()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync($"/api/Users/{FakeUser._AdminUser.Email}");

        var user = JsonConvert.DeserializeObject<ResponseDto<UserDto>>(response);

        // assert
        Assert.Equal(200, user.StatusCode);
        Assert.NotNull(user.Data);
    }

    [Fact]
    public async Task should_success_register_user()
    {
        //arrange
        var user = new RegisterUserCommand("admin", "admin", "test@test.co", "555555555", "123456");

        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync("/api/Users/register", user);

        var userdto =
            JsonConvert.DeserializeObject<ResponseDto<UserDto>>(await response.Content.ReadAsStringAsync());
        // assert
        Assert.Equal(200, userdto.StatusCode);
        Assert.NotNull(userdto.Data);
    }

    [Fact]
    public async Task should_success_login_user()
    {
        //arrange
        var user = new LoginUserCommand(FakeUser._AdminUser.Email, "123456");

        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync("/api/Users/login", user);

        var token =
            JsonConvert.DeserializeObject<ResponseDto<TokenDto>>(await response.Content.ReadAsStringAsync());

        // assert
        Assert.Equal((HttpStatusCode)200, response.StatusCode);
        Assert.NotNull(token.Data);
    }
}