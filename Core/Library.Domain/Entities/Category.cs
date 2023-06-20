namespace Library.Domain.Entities;

public class Category : BaseEntity
{
    public String Name { get; set; }

    public List<Book> Books { get; set; }
}