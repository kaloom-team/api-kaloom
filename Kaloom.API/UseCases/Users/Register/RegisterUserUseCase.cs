using AutoMapper;
using Kaloom.API.Context;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;
using static Kaloom.API.UseCases.Users.Utils.UserValidate;

namespace Kaloom.API.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly KaloomContext _context;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(KaloomContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<UserResponse> ExecuteAsync(UserRequest request)
        {
            if (!(await this._context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == request.Email) is null))
                throw new ErrorOnValidationException("Email já cadastrado.");

            Validate(request);

            var usuario = _mapper.Map<Usuario>(request);

            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(usuario);
        }
    }
}
