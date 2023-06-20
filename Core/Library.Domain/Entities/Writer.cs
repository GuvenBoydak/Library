namespace Library.Domain.Entities;

public class Writer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Book> Books { get; set; }
}