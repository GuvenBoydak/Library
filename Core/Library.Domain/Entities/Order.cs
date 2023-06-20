﻿namespace Library.Domain.Entities;

public class Order : BaseEntity
{
    public DateTime RecivedDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public bool IsCompleted { get; set; }

    public Guid BookId { get; set; }
    public Guid UserId { get; set; }

    public Book Book { get; set; }
    public User User { get; set; }
}