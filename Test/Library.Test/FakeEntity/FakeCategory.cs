using System.ComponentModel;
using Library.Domain.Entities;

namespace Library.Test.FakeEntity;

public class FakeCategory
{
    public static Category _MaceraCategory;
    public static Category _KorkuCategory;

    static FakeCategory()
    {
        _MaceraCategory = new Category()
        {
            Id = Guid.NewGuid(), Name = "Macera", CreatedDate = DateTime.UtcNow
        };
        _KorkuCategory = new Category()
        {
            Id = Guid.NewGuid(), Name = "Korku", CreatedDate = DateTime.UtcNow
        };
    }
}