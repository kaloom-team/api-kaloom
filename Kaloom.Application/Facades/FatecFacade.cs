using Kaloom.Application.UseCases.Fatecs.Delete;
using Kaloom.Application.UseCases.Fatecs.GetAll;
using Kaloom.Application.UseCases.Fatecs.GetById;
using Kaloom.Application.UseCases.Fatecs.Register;
using Kaloom.Application.UseCases.Fatecs.Update;

namespace Kaloom.Application.Facades
{
    public class FatecFacade : IFatecFacade
    {
        public IGetAllFatecsUseCase GetAll { get; }
        public IGetFatecByIdUseCase GetById { get; }
        public IRegisterFatecUseCase Register { get; }
        public IUpdateFatecUseCase Update { get; }
        public IDeleteFatecUseCase Delete { get; }

        public FatecFacade(
            IGetAllFatecsUseCase getAll,
            IGetFatecByIdUseCase getById,
            IRegisterFatecUseCase register,
            IUpdateFatecUseCase update,
            IDeleteFatecUseCase delete)
        {
            this.GetAll = getAll;
            this.GetById = getById;
            this.Register = register;
            this.Update = update;
            this.Delete = delete;
        }
    }
}
