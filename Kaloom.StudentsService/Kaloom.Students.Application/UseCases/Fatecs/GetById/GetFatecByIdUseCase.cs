using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Application.Factories;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Repositories.Abstractions;

namespace Kaloom.Students.Application.UseCases.Fatecs.GetById
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