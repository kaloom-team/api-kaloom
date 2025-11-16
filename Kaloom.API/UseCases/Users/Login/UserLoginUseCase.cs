using AutoMapper;
using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;
using static Kaloom.API.UseCases.Users.Utils.UserValidate;

namespace Kaloom.API.UseCases.Users.Login
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        private readonly KaloomContext _context;
        private readonly IMapper _mapper;
        public UserLoginUseCase(KaloomContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<UserLoginResponse> ExecuteAsync(UserRequest request)
        {
            Validate(request);

            var usuarios = await this._context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == request.Email) 
                ?? throw new UnauthorizedException("Usuário não encontrado.");
            
            if (usuarios.Senha != request.Senha)
                throw new UnauthorizedException($"Senha incorreta.");

            var aluno = await this._context.Alunos
                .AsNoTracking()
                .Include(a => a.TipoAluno)
                .FirstOrDefaultAsync(a => a.IdUsuario == usuarios.Id)
                ?? throw new NotFoundException("Aluno não encontrado para este usuário.");

            return new UserLoginResponse("Login realizado com sucesso!", _mapper.Map<StudentResponse>(aluno));
        }
    }
}