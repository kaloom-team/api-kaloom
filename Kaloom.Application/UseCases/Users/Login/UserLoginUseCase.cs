using AutoMapper;
using Kaloom.Application.Services;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;
using static Kaloom.Application.UseCases.Users.Utils.UserValidate;

namespace Kaloom.Application.UseCases.Users.Login
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public UserLoginUseCase(
            IUserRepository userRepository, 
            IStudentRepository studentRepository,
            IMapper mapper,
            IJwtTokenGenerator tokenGenerator)
        {
            this._userRepository = userRepository;
            this._studentRepository = studentRepository;
            this._mapper = mapper;
            this._tokenGenerator = tokenGenerator;
        }
        public async Task<UserLoginResponse> ExecuteAsync(UserRequest request)
        {
            Validate(request);

            var users = await this._userRepository.GetAllAsync();

            if(users is null || !users.Any())
                throw new UnauthorizedException("Nenhum usuário cadastrado.");

            var user = users.FirstOrDefault(u => u.Email == request.Email) ??
                throw new UnauthorizedException("Usuário não encontrado.");
            
            if (user.Senha != request.Senha)
                throw new UnauthorizedException("Senha incorreta.");

            var aluno = await this._studentRepository.GetByReferenceIdAsync(
                    a => a.IdUsuario == user.Id,
                    a => a.TipoAluno)
                ?? throw new NotFoundException("Aluno não encontrado para este usuário.");

            var token = _tokenGenerator.GenerateToken(user.Id, user.Email);

            return new UserLoginResponse(
                msg: "Login realizado com sucesso!", 
                student: this._mapper.Map<StudentResponse>(aluno),
                token: token
            );
        }
    }
}