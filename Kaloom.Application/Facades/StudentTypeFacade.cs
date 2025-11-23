using Kaloom.Application.UseCases.StudentsTypes.Delete;
using Kaloom.Application.UseCases.StudentsTypes.GetAll;
using Kaloom.Application.UseCases.StudentsTypes.GetById;
using Kaloom.Application.UseCases.StudentsTypes.Register;
using Kaloom.Application.UseCases.StudentsTypes.Update;

namespace Kaloom.Application.Facades
{
    public class StudentTypeFacade : IStudentTypeFacade
    {
        public IRegisterStudentTypeUseCase Register { get; }
        public IGetAllStudentsTypesUseCase GetAll { get; }
        public IGetStudentTypeByIdUseCase GetById { get; }
        public IDeleteStudentTypeUseCase Delete { get; }
        public IUpdateStudentTypeUseCase Update { get; }

        public StudentTypeFacade(
            IRegisterStudentTypeUseCase register,
            IGetAllStudentsTypesUseCase getAll,
            IGetStudentTypeByIdUseCase getById,
            IDeleteStudentTypeUseCase delete,
            IUpdateStudentTypeUseCase update)
        {
            Register = register;
            GetAll = getAll;
            GetById = getById;
            Delete = delete;
            Update = update;
        }
    }
}
