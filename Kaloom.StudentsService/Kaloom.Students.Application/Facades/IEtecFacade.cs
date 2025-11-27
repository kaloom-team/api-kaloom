using Kaloom.Students.Application.UseCases.Etecs.Delete;
using Kaloom.Students.Application.UseCases.Etecs.GetAll;
using Kaloom.Students.Application.UseCases.Etecs.GetById;
using Kaloom.Students.Application.UseCases.Etecs.Register;
using Kaloom.Students.Application.UseCases.Etecs.Update;

namespace Kaloom.Students.Application.Facades
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
