using System.Net.Http.Json;
using Library.Application.DTOs;
using Library.Application.DTOs.Order;
using Library.Application.Features.Command.Order.AddOrder;
using Library.Test.FakeEntity;
using Library.Test.Setup;
using Newtonsoft.Json;

namespace Library.Test.ControllerTest;

public class OrdersControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;
    private HttpClient _client;

    public OrdersControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client=_factory.HttpClientFactory();
    }


    [Fact]
    public async Task should_success_get_all_orders()
    {
        // act
        var response = await _client.GetStringAsync("/api/Orders");

        var orders = JsonConvert.DeserializeObject<ResponseDto<List<OrderListDto>>>(response);

        // assert
        Assert.Equal(200, orders.StatusCode);
        Assert.NotNull(orders.Data);
    }

    [Fact]
    public async Task should_success_get_orders_by_user_id()
    {
        // act
        var response = await _client.GetStringAsync($"/api/Orders/{FakeUser._AdminUser.Id}");
        
        var orders = JsonConvert.DeserializeObject<ResponseDto<List<OrderListDto>>>(response);
        
        // assert
        Assert.Equal(200, orders.StatusCode);
        Assert.NotNull(orders.Data);
    }

    [Fact]
    public async Task should_success_add_order()
    {
        //arrange
        var order = new AddOrderCommand(FakeBook._GolgeDuserkenBook.Id, FakeUser._AdminUser.Id, DateTime.UtcNow,
            DateTime.UtcNow.AddDays(2));

        // act
        var response = await _client.PostAsJsonAsync("/api/Orders",order);
        var orderDto =
            JsonConvert.DeserializeObject<ResponseDto<OrderDto>>(response.Content.ReadAsStringAsync().Result);

        // assert
        Assert.Equal(200, orderDto.StatusCode);
        Assert.NotNull(orderDto.Data);
    }
}