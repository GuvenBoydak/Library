using System.Net;
using System.Net.Http.Json;
using Library.Application.DTOs;
using Library.Application.DTOs.Category;
using Library.Application.Features.Command.Category.AddCategory;
using Library.Application.Features.Queries.Category.GetByIdsCategories;
using Library.Test.FakeEntity;
using Library.Test.Setup;
using Newtonsoft.Json;

namespace Library.Test.ControllerTest;

public class CategoriesControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;

    public CategoriesControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task should_success_get_all_categories()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync("/api/Categories");

        var categories = JsonConvert.DeserializeObject<ResponseDto<List<CategoryListDto>>>(response);

        // assert
        Assert.Equal(200, categories.StatusCode);
        Assert.NotNull( categories.Data);
    }

    [Fact]
    public async Task should_success_get_by_id_category()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync($"/api/Categories/GetById/{FakeCategory._KorkuCategory.Id}");

        var category = JsonConvert.DeserializeObject<ResponseDto<CategoryDto>>(response);

        // assert
        Assert.Equal(200, category.StatusCode);
        Assert.NotNull(category);
    }

    [Fact]
    public async Task should_success_get_by_ids_category()
    {
        //arrange
        var ids = new GetByIdsCategoriesQuery(new List<Guid>()
            { FakeCategory._KorkuCategory.Id, FakeCategory._MaceraCategory.Id });

        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync($"/api/Categories/GetByIds", ids);

        var categories =
            JsonConvert.DeserializeObject<ResponseDto<List<CategoryListDto>>>(response.Content.ReadAsStringAsync()
                .Result);

        // assert
        Assert.Equal(200, categories.StatusCode);
        Assert.NotNull(categories);
    }

    [Fact]
    public async Task should_success_add_category()
    {
        //arrange
        var category = new AddCategoryCommand("Test");

        // act
        var client = _factory.HttpClientFactory();
        var response = await client.PostAsJsonAsync("/api/Categories", category);
        var categoryDto =
            JsonConvert.DeserializeObject<ResponseDto<CategoryDto>>(response.Content.ReadAsStringAsync().Result);

        // assert
        Assert.Equal(200, categoryDto.StatusCode);
        Assert.NotNull(categoryDto.Data);
    }
}