using Library.Domain.Entities;

namespace Library.Test.FakeEntity;

public class FakeOrder
{
    public static Order _testOrder;
    public static Order _test2Order;

    static FakeOrder()
    {
        _testOrder = new Order()
        {
            Id = Guid.NewGuid(), BookId = FakeBook._KayipHazinesiBook.Id, UserId = FakeUser._AdminUser.Id,
            ReceivedDate = DateTime.UtcNow, ReturnDate = DateTime.UtcNow.AddDays(2), CreatedDate = DateTime.UtcNow
        };
        _test2Order = new Order()
        {
            Id = Guid.NewGuid(), BookId = FakeBook._GolgeDuserkenBook.Id, UserId = FakeUser._AdminUser.Id,
            ReceivedDate = DateTime.UtcNow, ReturnDate = DateTime.UtcNow.AddDays(3), CreatedDate = DateTime.UtcNow
        };
    }
}