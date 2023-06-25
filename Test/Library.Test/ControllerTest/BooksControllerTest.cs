using System.Net.Http.Json;
using Library.Application.DTOs;
using Library.Application.DTOs.Book;
using Library.Application.Features.Command.Book.AddBook;
using Library.Application.Features.Queries.Book.GetByIdsBook;
using Library.Test.FakeEntity;
using Library.Test.Setup;
using Newtonsoft.Json;

namespace Library.Test.ControllerTest;

public class BooksControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;

    public BooksControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task should_success_get_all_books()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync("/api/Books");

        var books = JsonConvert.DeserializeObject<ResponseDto<List<BookListDto>>>(response);

        // assert
        Assert.Equal(200, books.StatusCode);
        Assert.NotNull(books.Data);
    }

    [Fact]
    public async Task should_success_get_by_id_book()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync($"/api/Books/GetById/{FakeBook._GolgeDuserkenBook.Id}");

        var book = JsonConvert.DeserializeObject<ResponseDto<BookDto>>(response);

        // assert
        Assert.Equal(200, book.StatusCode);
        Assert.NotNull(book);
    }

    [Fact]
    public async Task should_success_get_by_ids_book()
    {
        //arrange
        var ids = new GetByIdsBooksQuery(new List<Guid>()
            { FakeBook._GolgeDuserkenBook.Id, FakeBook._KayipHazinesiBook.Id });

        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync($"/api/Books/GetByIds", ids);

        var books =
            JsonConvert.DeserializeObject<ResponseDto<List<BookListDto>>>(response.Content.ReadAsStringAsync()
                .Result);

        // assert
        Assert.Equal(200, books.StatusCode);
        Assert.Equal(2, books.Data.Count());
        Assert.NotNull(books);
    }

    [Fact]
    public async Task should_success_add_book()
    {
        //arrange
        var book = new AddBookCommand(FakeCategory._MaceraCategory.Id, FakeWriter._EmmaThompsonWriter.Id, true, "Test",
            "test.img");

        // act
        var client = _factory.HttpClientFactory();
        var response = await client.PostAsJsonAsync("/api/Books", book);
        var bookDto =
            JsonConvert.DeserializeObject<ResponseDto<BookDto>>(response.Content.ReadAsStringAsync().Result);

        // assert
        Assert.Equal(200, bookDto.StatusCode);
        Assert.NotNull(bookDto.Data);
    }
}