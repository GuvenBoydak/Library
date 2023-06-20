using Library.Application.DTOs;
using Library.Application.DTOs.Writer;
using MediatR;

namespace Library.Application.Features.Command.Writer.AddWriter;

public record AddWriterCommand(string FirstName,string LastName):IRequest<ResponseDto<WriterDto>>;