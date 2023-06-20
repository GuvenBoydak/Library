using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Writer;
using Library.Application.Repositories;
using Library.Application.UnitOfWork;
using MediatR;

namespace Library.Application.Features.Command.Writer.AddWriter;

public class AddWriterCommandHandler : IRequestHandler<AddWriterCommand, ResponseDto<WriterDto>>
{
    private readonly IWriterRepository _writerRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddWriterCommandHandler(IWriterRepository writerRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _writerRepository = writerRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDto<WriterDto>> Handle(AddWriterCommand request, CancellationToken cancellationToken)
    {
        var writer = _mapper.Map<AddWriterCommand, Domain.Entities.Writer>(request);

        var writerDto = _mapper.Map<Domain.Entities.Writer, WriterDto>(await _writerRepository.AddAsync(writer));

        await _unitOfWork.SaveChanges();
        return ResponseDto<WriterDto>.Success(writerDto, 200);
    }
}