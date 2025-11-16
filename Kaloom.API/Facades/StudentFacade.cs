using Kaloom.API.UseCases.Students.Delete;
using Kaloom.API.UseCases.Students.GetAll;
using Kaloom.API.UseCases.Students.GetById;
using Kaloom.API.UseCases.Students.Register;
using Kaloom.API.UseCases.Students.Update;

namespace Kaloom.API.Facades
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
