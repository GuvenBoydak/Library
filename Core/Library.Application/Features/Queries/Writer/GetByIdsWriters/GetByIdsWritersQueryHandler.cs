using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.Writer;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.Writer.GetByIdsWriters
{
    public class GetByIdsWritersQueryHandler : IRequestHandler<GetByIdsWritersQuery, ResponseDto<List<WriterListDto>>>
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;

        public GetByIdsWritersQueryHandler(IMapper mapper, IWriterRepository writerRepository)
        {
            _mapper = mapper;
            _writerRepository = writerRepository;
        }

        public async Task<ResponseDto<List<WriterListDto>>> Handle(GetByIdsWritersQuery request, CancellationToken cancellationToken)
        {
            var categories = await _writerRepository.GetByIdsAsync(x => request.Ids.Contains(x.Id));

            return ResponseDto<List<WriterListDto>>.Success(_mapper.Map<List<Domain.Entities.Writer>, List<WriterListDto>>(categories), 200);
        }
    }
}
