namespace Library.Domain;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedDate=DateTime.UtcNow;
    }
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; }
}