using Library.Application.Helpers;
using Library.Domain.Entities;

namespace Library.Test.FakeEntity;

public class FakeUser
{
    public static User _AdminUser;

    static FakeUser()
    {
        _AdminUser = Add();
    }

    private static User Add()
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash("123456", out passwordHash, out passwordSalt);

        return new User()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, FirstName = "admin", LastName = "admin",
            Email = "admin@admin.com", PhoneNumber = "555555555", PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
    }
}