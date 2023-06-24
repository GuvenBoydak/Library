using Library.Application.DTOs;
using Library.Application.DTOs.Order;
using MediatR;

namespace Library.Application.Features.Queries.Order.GetAllOrders
{
    public record GetAllOrdersQuery : IRequest<ResponseDto<List<OrderListDto>>>;
}
