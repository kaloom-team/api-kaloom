using Kaloom.Application.UseCases.Students.Delete;
using Kaloom.Application.UseCases.Students.GetAll;
using Kaloom.Application.UseCases.Students.GetById;
using Kaloom.Application.UseCases.Students.Register;
using Kaloom.Application.UseCases.Students.Update;

namespace Kaloom.Application.Facades
{
    public class StudentFacade : IStudentFacade
    {
        public IRegisterStudentUseCase Register { get; }
        public IGetAllStudentsUseCase GetAll { get; }
        public IGetStudentByIdUseCase GetById { get; }
        public IDeleteStudentUseCase Delete { get; }
        public IUpdateStudentUseCase Update { get; }

        public StudentFacade(
            IRegisterStudentUseCase register,
            IGetAllStudentsUseCase getAll,
            IGetStudentByIdUseCase getById,
            IDeleteStudentUseCase delete,
            IUpdateStudentUseCase update)
        {
            Register = register;
            GetAll = getAll;
            GetById = getById;
            Delete = delete;
            Update = update;
        }
    }
}
