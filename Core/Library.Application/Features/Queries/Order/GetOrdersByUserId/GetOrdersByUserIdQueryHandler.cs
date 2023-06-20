using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Order;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Order.GetOrdersByUserId;

public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, ResponseDto<List<OrderListDto>>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersByUserIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<List<OrderListDto>>> Handle(GetOrdersByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersByUserId(request.Id);

        return ResponseDto<List<OrderListDto>>.Success(
            _mapper.Map<List<Domain.Entities.Order>, List<OrderListDto>>(orders), 200);
    }
}