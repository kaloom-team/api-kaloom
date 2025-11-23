using Kaloom.Application.UseCases.Etecs.Delete;
using Kaloom.Application.UseCases.Etecs.GetAll;
using Kaloom.Application.UseCases.Etecs.GetById;
using Kaloom.Application.UseCases.Etecs.Register;
using Kaloom.Application.UseCases.Etecs.Update;

namespace Kaloom.Application.Facades
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
