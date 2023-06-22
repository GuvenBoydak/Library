using Library.Application.DTOs;
using Library.Application.DTOs.Writer;
using MediatR;

namespace Library.Application.Features.Queries.Writer.GetAllWriters;

public record GetAllWritersQuery : IRequest<ResponseDto<List<WriterListDto>>>;