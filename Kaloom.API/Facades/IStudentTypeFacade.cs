using Kaloom.API.UseCases.StudentsTypes.Delete;
using Kaloom.API.UseCases.StudentsTypes.GetAll;
using Kaloom.API.UseCases.StudentsTypes.GetById;
using Kaloom.API.UseCases.StudentsTypes.Register;
using Kaloom.API.UseCases.StudentsTypes.Update;

namespace Kaloom.API.Facades
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
