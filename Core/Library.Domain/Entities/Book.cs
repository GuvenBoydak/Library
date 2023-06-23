namespace Library.Domain.Entities
{
    public class Book : BaseEntity
    {

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsItInLibrary { get; set; } = true;

        public Guid WriterId { get; set; }
        public Guid CategoryId { get; set; }

        public Writer Writer { get; set; }
        public Category Category { get; set; }
    }
}
