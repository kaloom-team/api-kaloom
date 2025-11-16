using Kaloom.API.UseCases.Etecs.Delete;
using Kaloom.API.UseCases.Etecs.GetAll;
using Kaloom.API.UseCases.Etecs.GetById;
using Kaloom.API.UseCases.Etecs.Register;
using Kaloom.API.UseCases.Etecs.Update;

namespace Kaloom.API.Facades
{
    public interface IEtecFacade
    {
        public IGetAllEtecsUseCase GetAll { get; set; }
        public IGetEtecByIdUseCase GetById { get; set; }
        public IRegisterEtecUseCase Register { get; set; }
        public IUpdateEtecUseCase Update { get; set; }  
        public IDeleteEtecUseCase Delete { get; set; }
    }
}
