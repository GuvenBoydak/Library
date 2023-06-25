using Library.Domain.Entities;

namespace Library.Test.FakeEntity;

public class FakeWriter
{
    public static Writer _JohnStevensonWriter;
    public static Writer _EmmaThompsonWriter;

    static FakeWriter()
    {
        _JohnStevensonWriter = new Writer()
        {
            Id = Guid.NewGuid(), FirstName = "John", LastName = "Stevenson", CreatedDate = DateTime.UtcNow
        };
        _EmmaThompsonWriter = new Writer()
        {
            Id = Guid.NewGuid(), FirstName = "Emma", LastName = "Thompson", CreatedDate = DateTime.UtcNow
        };
    }
}