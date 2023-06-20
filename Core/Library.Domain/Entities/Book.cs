namespace Library.Domain.Entities
{
    public class Book:BaseEntity
    {
        public String Name { get; set; }

        public String ImageUrl { get; set; }

        public bool IsItInLibrary { get; set; }

        public Guid WriterId { get; set; }
        public Guid CategoryId { get; set; }

        public Writer Writer { get; set; }
        public Category Category { get; set; }
    }
}
