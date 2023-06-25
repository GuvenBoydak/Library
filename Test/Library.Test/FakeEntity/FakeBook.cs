using Library.Domain.Entities;

namespace Library.Test.FakeEntity;

public class FakeBook
{
    public static Book _KayipHazinesiBook;
    public static Book _GolgeDuserkenBook;

    static FakeBook()
    {
        _KayipHazinesiBook = new Book()
        {
            Id = Guid.NewGuid(), Name = "Kayip Hazinesi", CategoryId = FakeCategory._MaceraCategory.Id,
            WriterId = FakeWriter._JohnStevensonWriter.Id, IsItInLibrary = true,ImageUrl = "test.img",CreatedDate = DateTime.UtcNow
        };
        _GolgeDuserkenBook = new Book()
        {
            Id = Guid.NewGuid(), Name = "Golge Duserken", CategoryId = FakeCategory._KorkuCategory.Id,
            WriterId = FakeWriter._EmmaThompsonWriter.Id, IsItInLibrary = true,ImageUrl = "test.img", CreatedDate = DateTime.UtcNow
        };
    }
}