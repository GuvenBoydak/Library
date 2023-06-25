using System.Net.Http.Json;
using Library.Application.DTOs;
using Library.Application.DTOs.Writer;
using Library.Application.Features.Command.Writer.AddWriter;
using Library.Application.Features.Queries.Writer.GetByIdsWriters;
using Library.Test.FakeEntity;
using Library.Test.Setup;
using Newtonsoft.Json;

namespace Library.Test.ControllerTest;

public class WritersControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;

    public WritersControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task should_success_get_all_witers()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync("/api/Categories");

        var writers = JsonConvert.DeserializeObject<ResponseDto<List<WriterListDto>>>(response);

        // assert
        Assert.Equal(200, writers.StatusCode);
        Assert.NotNull(writers.Data);
    }

    [Fact]
    public async Task should_success_get_by_ids_writer()
    {
        //arrange
        var ids = new GetByIdsWritersQuery(new List<Guid>()
            { FakeWriter._JohnStevensonWriter.Id, FakeWriter._EmmaThompsonWriter.Id });

        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync($"/api/Writers/GetByIds", ids);

        var writers =
            JsonConvert.DeserializeObject<ResponseDto<List<WriterListDto>>>(response.Content.ReadAsStringAsync()
                .Result);

        // assert
        Assert.Equal(200, writers.StatusCode);
        Assert.Equal(2, writers.Data.Count());
        Assert.NotNull(writers);
    }

    [Fact]
    public async Task should_success_add_writer()
    {
        //arrange
        var writer = new AddWriterCommand("Test", "Test");

        // act
        var client = _factory.HttpClientFactory();
        var response = await client.PostAsJsonAsync("/api/Writers", writer);
        var writerDto =
            JsonConvert.DeserializeObject<ResponseDto<WriterDto>>(response.Content.ReadAsStringAsync().Result);

        // assert
        Assert.Equal(200, writerDto.StatusCode);
        Assert.NotNull(writerDto.Data);
    }
}