using AutoMapper;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Repositories.Abstractions;

namespace Kaloom.Application.UseCases.Students.GetAll
{
    public class GetAllStudentsUseCase : IGetAllStudentsUseCase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetAllStudentsUseCase(IStudentRepository studentRepository, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<StudentResponse>> ExecuteAsync()
        {
            var alunos = await this._studentRepository.GetAllAsync();

            return this._mapper.Map<IEnumerable<StudentResponse>>(alunos);
        }
    }
}