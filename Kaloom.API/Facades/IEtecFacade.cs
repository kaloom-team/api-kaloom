using Kaloom.API.UseCases.Etecs.Delete;
using Kaloom.API.UseCases.Etecs.GetAll;
using Kaloom.API.UseCases.Etecs.GetById;
using Kaloom.API.UseCases.Etecs.Register;
using Kaloom.API.UseCases.Etecs.Update;

namespace Kaloom.API.Facades
{
    public interface IEtecFacade
    {
        public IGetAllEtecsUseCase GetAll { get; }
        public IGetEtecByIdUseCase GetById { get; }
        public IRegisterEtecUseCase Register { get; }
        public IUpdateEtecUseCase Update { get; }  
        public IDeleteEtecUseCase Delete { get; }
    }
}
