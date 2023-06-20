using Library.Application.DTOs;
using Library.Application.DTOs.Order;
using MediatR;

namespace Library.Application.Features.Queries.Order.GetOrdersByUserId;

public record GetOrdersByUserIdQuery(Guid Id) : IRequest<ResponseDto<List<OrderListDto>>>;