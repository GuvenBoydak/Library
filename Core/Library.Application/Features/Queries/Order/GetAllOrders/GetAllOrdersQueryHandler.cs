using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Order;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ResponseDto<List<OrderListDto>>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<OrderListDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            return ResponseDto<List<OrderListDto>>.Success(_mapper.Map<List<Domain.Entities.Order>, List<OrderListDto>>(orders), 200);
        }
    }

}
