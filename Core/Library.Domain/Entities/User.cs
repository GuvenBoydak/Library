namespace Library.Domain.Entities;

public class User : BaseEntity
{
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public string PhoneNumber { get; set; }
    public String Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public List<Order> Orders { get; set; }
}