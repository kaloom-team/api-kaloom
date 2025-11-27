using Kaloom.Students.Application.UseCases.Etecs.Delete;
using Kaloom.Students.Application.UseCases.Etecs.GetAll;
using Kaloom.Students.Application.UseCases.Etecs.GetById;
using Kaloom.Students.Application.UseCases.Etecs.Register;
using Kaloom.Students.Application.UseCases.Etecs.Update;

namespace Kaloom.Students.Application.Facades
{
    public class EtecFacade : IEtecFacade
    {
        public IGetAllEtecsUseCase GetAll { get; set; }
        public IGetEtecByIdUseCase GetById { get; set; }
        public IRegisterEtecUseCase Register { get; set; }
        public IUpdateEtecUseCase Update { get; set; }
        public IDeleteEtecUseCase Delete { get; set; }

        public EtecFacade(
            IGetAllEtecsUseCase getAll,
            IGetEtecByIdUseCase getById,
            IRegisterEtecUseCase register,
            IUpdateEtecUseCase update,
            IDeleteEtecUseCase delete)
        {
            this.GetAll = getAll;
            this.GetById = getById;
            this.Register = register;
            this.Update = update;
            this.Delete = delete;
        }
    }
}
