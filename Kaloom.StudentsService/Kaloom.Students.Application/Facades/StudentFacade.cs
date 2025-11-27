using Kaloom.Students.Application.UseCases.Students.Delete;
using Kaloom.Students.Application.UseCases.Students.GetAll;
using Kaloom.Students.Application.UseCases.Students.GetById;
using Kaloom.Students.Application.UseCases.Students.Register;
using Kaloom.Students.Application.UseCases.Students.Update;
using Kaloom.Students.Application.UseCases.Students.GetByReferenceId;

namespace Kaloom.Students.Application.Facades
{
    public class StudentFacade : IStudentFacade
    {
        public IRegisterStudentUseCase Register { get; }
        public IGetAllStudentsUseCase GetAll { get; }
        public IGetStudentByIdUseCase GetById { get; }
        public IDeleteStudentUseCase Delete { get; }
        public IUpdateStudentUseCase Update { get; }
        public IGetStudentByReferenceIdUseCase GetByReferenceId { get; }

        public StudentFacade(
            IRegisterStudentUseCase register,
            IGetAllStudentsUseCase getAll,
            IGetStudentByIdUseCase getById,
            IDeleteStudentUseCase delete,
            IUpdateStudentUseCase update,
            IGetStudentByReferenceIdUseCase getByReferenceId)
        {
            Register = register;
            GetAll = getAll;
            GetById = getById;
            Delete = delete;
            Update = update;
            GetByReferenceId = getByReferenceId;
        }
    }
}
