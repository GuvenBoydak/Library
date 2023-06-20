namespace Library.Domain.Entities;

public class Writer : BaseEntity
{
    public String FirstName { get; set; }
    public String LastName { get; set; }

    public List<Book> Books { get; set; }
}