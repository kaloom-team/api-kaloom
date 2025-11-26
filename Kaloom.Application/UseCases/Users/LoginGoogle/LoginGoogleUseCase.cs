using AutoMapper;
using Kaloom.Application.Services;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Models;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.Users.LoginGoogle
{
    public class LoginGoogleUseCase : ILoginGoogleUseCase
    {
        private readonly IGoogleAuthService _googleService;
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;

        public LoginGoogleUseCase(
            IGoogleAuthService googleService, 
            IUserRepository userRepository,
            IJwtTokenGenerator tokenGenerator,
            IStudentRepository studentRepository,
            IMapper mapper)
        {
            this._googleService = googleService;
            this._userRepository = userRepository;
            this._tokenGenerator = tokenGenerator;
            this._studentRepository = studentRepository;
            this._mapper = mapper;  
        }

        public async Task<UserLoginResponse> ExecuteAsync(GoogleLoginRequest request)
        {
            var payload = await this._googleService.ValidateAsync(request.Code);

            var user = await this._userRepository.GetByEmailAsync(payload.Email);

            if (user != null && user.Senha != null && !user.Senha.StartsWith("GOOGLE-"))
                throw new ErrorOnValidationException("Este email já está em uso em uma conta tradicional.");

            if (user == null)
            {
                var aluno = new Aluno
                {
                    Nome = payload.GivenName ?? payload.Name,
                    Sobrenome = payload.FamilyName ?? string.Empty,
                    NomeUsuario = $"{(payload.GivenName ?? "").Replace(" ", "").ToLower()}" +
                                  $"{(payload.FamilyName ?? "").Replace(" ", "").ToLower()}",
                    FotoPerfil = payload.Picture,
                    DataNascimento = new DateOnly(1970, 1, 1),
                    DataCadastro = DateTime.Now,
                    IdTipoAluno = 1,
                    TipoAluno = null,
                    Usuario = null
                };

                user = new Usuario
                {
                    Email = payload.Email,
                    Senha = $"GOOGLE-{Guid.NewGuid()}",
                    Aluno = aluno
                };

                aluno.Usuario = user;

                await this._userRepository.AddAsync(user);
            }

            var token = this._tokenGenerator.GenerateToken(user.Id, user.Email);

            var alunoEntity = await this._studentRepository.GetByReferenceIdAsync(e => e.IdUsuario == user.Id);

            var studentResponse = alunoEntity == null
                ? null
                : this._mapper.Map<StudentResponse>(alunoEntity);

            return new UserLoginResponse("Login realizado com sucesso!", studentResponse, token);
        }
    }
}
