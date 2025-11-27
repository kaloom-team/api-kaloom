using Kaloom.Students.Application.Factories;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Repositories.Abstractions;

namespace Kaloom.Students.Application.UseCases.Fatecs.GetAll
{
    public class GetAllFatecsUseCase : IGetAllFatecsUseCase
    {
        private readonly IFatecRepository _fatecRepository;
        private readonly IInstitutionUnitResponseFactory _fatecResponseFactory;

        public GetAllFatecsUseCase(IFatecRepository fatecRepository, IInstitutionUnitResponseFactory fatecResponseFactory)
        {
            this._fatecRepository = fatecRepository;
            this._fatecResponseFactory = fatecResponseFactory;
        }
        public async Task<IEnumerable<FatecResponse>> ExecuteAsync()
        {
            var fatecs = await this._fatecRepository.GetAllAsync();

            return fatecs
                .Select(_fatecResponseFactory.Create<FatecResponse>)
                .ToList();
        }
    }
}