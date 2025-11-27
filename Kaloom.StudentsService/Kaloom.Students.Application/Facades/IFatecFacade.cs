using Kaloom.Students.Application.UseCases.Fatecs.Delete;
using Kaloom.Students.Application.UseCases.Fatecs.GetAll;
using Kaloom.Students.Application.UseCases.Fatecs.GetById;
using Kaloom.Students.Application.UseCases.Fatecs.Register;
using Kaloom.Students.Application.UseCases.Fatecs.Update;

namespace Kaloom.Students.Application.Facades
{
    public interface IFatecFacade
    {
        public IGetAllFatecsUseCase GetAll { get; }
        public IGetFatecByIdUseCase GetById { get; }
        public IRegisterFatecUseCase Register { get; }
        public IUpdateFatecUseCase Update { get; }
        public IDeleteFatecUseCase Delete { get; }
    }
}
