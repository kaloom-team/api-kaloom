using AutoMapper;
using Kaloom.SharedContracts.Events;
using Kaloom.Users.Application.Services;
using Kaloom.Users.Application.Services.Abstractions;
using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Communication.DTOs.Responses;
using Kaloom.Users.Domain.Models;
using Kaloom.Users.Domain.Repositories.Abstractions;
using Kaloom.Users.Exceptions.ExceptionsBase;
using System.Text.Json;

namespace Kaloom.Users.Application.UseCases.Users.LoginGithub
{
    public class LoginGithubUseCase : ILoginGithubUseCase
    {
        private readonly IGithubAuthService _githubService;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;

        public LoginGithubUseCase(
            IGithubAuthService githubService,
            IUserRepository userRepository,
            IJwtTokenGenerator tokenGenerator,
            IMapper mapper,
            IEventPublisher eventPublisher)
        {
            this._githubService = githubService;
            this._userRepository = userRepository;
            this._tokenGenerator = tokenGenerator;
            this._mapper = mapper;
            this._eventPublisher = eventPublisher;
        }

        public async Task<UserLoginResponse> ExecuteAsync(GithubLoginRequest request)
        {
            var payload = await this._githubService.ValidateAsync(request.Code);

            var user = await this._userRepository.GetByEmailAsync(payload.Email);

            if (user != null && user.Senha != null && !user.Senha.StartsWith("GITHUB-"))
                throw new ErrorOnValidationException("Este email já está em uso em uma conta tradicional.");

            if (user == null)
            {
                
                user = new Usuario
                {
                    Email = payload.Email,
                    Senha = $"GITHUB-{Guid.NewGuid()}",
                };


                await this._userRepository.AddAsync(user);

                var userCreatedEvent = new UserCreatedEvent(
                    user.Id,
                    user.Email,
                    payload.GivenName ?? payload.Name,
                    payload.FamilyName ?? string.Empty,
                    payload.Picture ?? string.Empty
                );

                await this._eventPublisher.PublishAsync(userCreatedEvent, "user.created");
            }

            var token = this._tokenGenerator.GenerateToken(user.Id, user.Email);

            return new UserLoginResponse("Login realizado com sucesso!", token);
        }
    }
}
