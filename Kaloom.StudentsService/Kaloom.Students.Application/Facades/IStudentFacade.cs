using Kaloom.Students.Application.UseCases.Students.Delete;
using Kaloom.Students.Application.UseCases.Students.GetAll;
using Kaloom.Students.Application.UseCases.Students.GetById;
using Kaloom.Students.Application.UseCases.Students.GetByReferenceId;
using Kaloom.Students.Application.UseCases.Students.Register;
using Kaloom.Students.Application.UseCases.Students.Update;

namespace Kaloom.Students.Application.Facades
{
    public interface IStudentFacade
    {
        public IRegisterStudentUseCase Register { get; }
        public IGetAllStudentsUseCase GetAll { get; }
        public IGetStudentByIdUseCase GetById { get; }
        public IDeleteStudentUseCase Delete { get; }
        public IUpdateStudentUseCase Update { get; }
        public IGetStudentByReferenceIdUseCase GetByReferenceId { get; }

    }
}
