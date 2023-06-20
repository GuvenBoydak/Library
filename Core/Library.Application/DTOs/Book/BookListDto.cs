namespace Library.Application.DTOs.Book;

public class BookListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public bool IsItInLibrary { get; set; }

    public Guid WriterId { get; set; }
    public Guid CategoryId { get; set; }
}