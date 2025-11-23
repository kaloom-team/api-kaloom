using Kaloom.Application.UseCases.StudentsTypes.Delete;
using Kaloom.Application.UseCases.StudentsTypes.GetAll;
using Kaloom.Application.UseCases.StudentsTypes.GetById;
using Kaloom.Application.UseCases.StudentsTypes.Register;
using Kaloom.Application.UseCases.StudentsTypes.Update;

namespace Kaloom.Application.Facades
{
    public interface IStudentTypeFacade
    {
        public IRegisterStudentTypeUseCase Register { get; }
        public IGetAllStudentsTypesUseCase GetAll { get; }
        public IGetStudentTypeByIdUseCase GetById { get; }
        public IDeleteStudentTypeUseCase Delete { get; }
        public IUpdateStudentTypeUseCase Update { get; }
    }
}
