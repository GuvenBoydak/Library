namespace Library.MvcUi.Models.Book;

public class AddBookInput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsItInLibrary { get; set; }
    public Guid WriterId { get; set; }
    public Guid CategoryId { get; set; }
    public IFormFile ImageUrl { get; set; }
}