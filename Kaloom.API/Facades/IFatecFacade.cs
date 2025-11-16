using Kaloom.API.UseCases.Fatecs.Delete;
using Kaloom.API.UseCases.Fatecs.GetAll;
using Kaloom.API.UseCases.Fatecs.GetById;
using Kaloom.API.UseCases.Fatecs.Register;
using Kaloom.API.UseCases.Fatecs.Update;

namespace Kaloom.API.Facades
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
