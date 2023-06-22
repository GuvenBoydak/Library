namespace Library.MvcUi.Models.Book;

public class BookModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public bool IsItInLibrary { get; set; }

    public Guid WriterId { get; set; }
    public Guid CategoryId { get; set; } 
}