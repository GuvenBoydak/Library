using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Order;
using Library.Application.Repositories;
using Library.Application.UnitOfWork;
using MediatR;

namespace Library.Application.Features.Command.Order.AddOrder;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, ResponseDto<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDto<OrderDto>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<AddOrderCommand, Domain.Entities.Order>(request);

        var orderDto = _mapper.Map<Domain.Entities.Order, OrderDto>(await _orderRepository.AddAsync(order));

        await _unitOfWork.SaveChanges();

        return ResponseDto<OrderDto>.Success(orderDto, 200);
    }
}