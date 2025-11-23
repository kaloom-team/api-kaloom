using Kaloom.Application.Factories;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.Fatecs.GetById
{
    public class GetFatecByIdUseCase : IGetFatecByIdUseCase
    {
        private readonly IFatecRepository _fatecRepository;
        private readonly IInstitutionUnitResponseFactory _fatecResponseFactory;

        public GetFatecByIdUseCase(IFatecRepository fatecRepository, IInstitutionUnitResponseFactory fatecResponseFactory)
        {
            this._fatecRepository = fatecRepository;
            this._fatecResponseFactory = fatecResponseFactory;
        }

        public async Task<FatecResponse> ExecuteAsync(int id)
        {
            var fatec = await this._fatecRepository.GetByIdAsync(id)
               ?? throw new NotFoundException($"Nenhuma Etec encontrada com o ID {id}.");

            return this._fatecResponseFactory.Create<FatecResponse>(fatec);
        }
    }
}