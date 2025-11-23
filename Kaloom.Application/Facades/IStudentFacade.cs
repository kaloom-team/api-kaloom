using Kaloom.Application.UseCases.Students.Delete;
using Kaloom.Application.UseCases.Students.GetAll;
using Kaloom.Application.UseCases.Students.GetById;
using Kaloom.Application.UseCases.Students.Register;
using Kaloom.Application.UseCases.Students.Update;

namespace Kaloom.Application.Facades
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
