using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Writer;
using Library.Application.Features.Queries.Writer.GetAllWriters;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Book.GetAllBook;

public class GetAllWritersQueryHandler : IRequestHandler<GetAllWritersQuery, ResponseDto<List<WriterListDto>>>
{
    private readonly IWriterRepository _writerRepository;
    private readonly IMapper _mapper;

    public GetAllWritersQueryHandler(IMapper mapper, IWriterRepository writerRepository)
    {
        _mapper = mapper;
        _writerRepository = writerRepository;
    }

    public async Task<ResponseDto<List<WriterListDto>>> Handle(GetAllWritersQuery request,
        CancellationToken cancellationToken)
    {
        var writers = await _writerRepository.GetAllAsync();

        return ResponseDto<List<WriterListDto>>.Success(_mapper.Map<List<Domain.Entities.Writer>, List<WriterListDto>>(writers),
            200);
    }
}