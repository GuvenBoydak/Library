using Library.Application.DTOs;
using Library.Application.DTOs.Order;
using MediatR;

namespace Library.Application.Features.Command.Order.AddOrder;

public record AddOrderCommand
    (Guid BookId, Guid UserId, DateTime RecivedDate, DateTime ReturnDate) : IRequest<ResponseDto<OrderDto>>;