namespace Library.MvcUi.Models.Order;

public class AddOrderInput
{
    public DateTime ReceivedDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
}