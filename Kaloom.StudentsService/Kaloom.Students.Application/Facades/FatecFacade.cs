using Kaloom.Students.Application.UseCases.Fatecs.Delete;
using Kaloom.Students.Application.UseCases.Fatecs.GetAll;
using Kaloom.Students.Application.UseCases.Fatecs.GetById;
using Kaloom.Students.Application.UseCases.Fatecs.Register;
using Kaloom.Students.Application.UseCases.Fatecs.Update;

namespace Kaloom.Students.Application.Facades
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
