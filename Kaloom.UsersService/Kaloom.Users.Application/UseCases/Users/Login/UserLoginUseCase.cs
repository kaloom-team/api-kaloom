using AutoMapper;
using Kaloom.Users.Application.Services;
using Kaloom.Users.Application.Services.Abstractions;
using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Communication.DTOs.Responses;
using Kaloom.Users.Domain.Repositories.Abstractions;
using Kaloom.Users.Exceptions.ExceptionsBase;
using static Kaloom.Users.Application.UseCases.Users.Utils.UserLoginValidate;

namespace Kaloom.Users.Application.UseCases.Users.Login
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IEventPublisher _eventPublisher;
        private readonly IStudentDataClient _studentDataClient;


        public UserLoginUseCase(
            IUserRepository userRepository, 
            IMapper mapper,
            IJwtTokenGenerator tokenGenerator,
            IEventPublisher eventPublisher,
            IStudentDataClient studentDataClient)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._tokenGenerator = tokenGenerator;
            this._eventPublisher = eventPublisher;
            this._studentDataClient = studentDataClient;
        }
        public async Task<UserLoginResponse> ExecuteAsync(UserLoginRequest request)
        {
            Validate(request);

            var users = await this._userRepository.GetAllAsync();

            if(users is null || !users.Any())
                throw new UnauthorizedException("Nenhum usuário cadastrado.");

            var user = users.FirstOrDefault(u => u.Email == request.Email) ??
                throw new UnauthorizedException("Usuário não encontrado.");
            
            if (user.Senha != request.Senha)
                throw new UnauthorizedException("Senha incorreta.");

            var studentResponse = await this._studentDataClient.GetStudentByUserIdAsync(user.Id)
                ?? throw new NotFoundException("Aluno não encontrado para este usuário.");

            var token = _tokenGenerator.GenerateToken(user.Id, user.Email);

            return new UserLoginResponse(
                msg: "Login realizado com sucesso!",
                token: token
            );
        }
    }
}