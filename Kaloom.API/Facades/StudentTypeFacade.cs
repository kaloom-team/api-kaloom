using Kaloom.API.UseCases.StudentsTypes.Delete;
using Kaloom.API.UseCases.StudentsTypes.GetAll;
using Kaloom.API.UseCases.StudentsTypes.GetById;
using Kaloom.API.UseCases.StudentsTypes.Register;
using Kaloom.API.UseCases.StudentsTypes.Update;

namespace Kaloom.API.Facades
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
