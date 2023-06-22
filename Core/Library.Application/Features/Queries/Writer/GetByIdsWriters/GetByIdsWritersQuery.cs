using Library.Application.DTOs;
using Library.Application.DTOs.Writer;
using MediatR;

namespace Library.Application.Features.Queries.Writer.GetByIdsWriters
{
    public record GetByIdsWritersQuery(List<Guid> Ids) : IRequest<ResponseDto<List<WriterListDto>>>;
}
