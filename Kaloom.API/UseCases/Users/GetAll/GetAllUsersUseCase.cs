using AutoMapper;
using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Users.GetAll
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly KaloomContext _context;
        private readonly IMapper _mapper;
        public GetAllUsersUseCase(KaloomContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> ExecuteAsync()
        {
            var usuarios = await this._context.Usuarios
                .AsNoTracking()
                .ToListAsync();

            var response = this._mapper.Map<IEnumerable<UserResponse>>(usuarios);

            return response;
        }
    }
}