namespace Library.Application.DTOs.Order;

public class OrderDto
{
    public DateTime RecivedDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
}