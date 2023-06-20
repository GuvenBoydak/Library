using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.User;
using Library.Application.Helpers;
using Library.Application.Repositories;
using Library.Application.UnitOfWork;
using MediatR;

namespace Library.Application.Features.Command.User.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseDto<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDto<UserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userRepository.Where(x => x.Email == request.Email).FirstOrDefault();

        if (currentUser != null)
            throw new Exception("User Already Exist");

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        var user = new Domain.Entities.User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        var result = await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChanges();

        return ResponseDto<UserDto>.Success(_mapper.Map<Domain.Entities.User, UserDto>(result), 200);
    }
}