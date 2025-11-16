using Kaloom.API.UseCases.Students.Delete;
using Kaloom.API.UseCases.Students.GetAll;
using Kaloom.API.UseCases.Students.GetById;
using Kaloom.API.UseCases.Students.Register;
using Kaloom.API.UseCases.Students.Update;

namespace Kaloom.API.Facades
{
    public interface IStudentFacade
    {
        public IRegisterStudentUseCase Register { get; }
        public IGetAllStudentsUseCase GetAll { get; }
        public IGetStudentByIdUseCase GetById { get; }
        public IDeleteStudentUseCase Delete { get; }
        public IUpdateStudentUseCase Update { get; }
    }
}
