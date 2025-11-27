using Kaloom.Students.Application.UseCases.StudentsTypes.Delete;
using Kaloom.Students.Application.UseCases.StudentsTypes.GetAll;
using Kaloom.Students.Application.UseCases.StudentsTypes.GetById;
using Kaloom.Students.Application.UseCases.StudentsTypes.Register;
using Kaloom.Students.Application.UseCases.StudentsTypes.Update;

namespace Kaloom.Students.Application.Facades
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
