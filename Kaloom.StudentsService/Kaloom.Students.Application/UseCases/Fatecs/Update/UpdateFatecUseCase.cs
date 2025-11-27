using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Domain.Repositories.Abstractions;
using static Kaloom.Students.Application.UseCases.Fatecs.Utils.FatecValidate;

namespace Kaloom.Students.Application.UseCases.Fatecs.Update
{
    public class UpdateFatecUseCase : IUpdateFatecUseCase
    {
        private readonly IFatecRepository _fatecRepository;

        public UpdateFatecUseCase(IFatecRepository fatecRepository)
        {
            this._fatecRepository = fatecRepository;
        }
        public async Task ExecuteAsync(int id, FatecRequest request)
        {
            Validate(request);

            var fatec = await this._fatecRepository.GetByIdAsync(id)
               ?? throw new NotFoundException($"Fatec com ID {id} não encontrada.");

            var fatecs = await this._fatecRepository.GetAllAsync();

            if (fatecs.Any(e => e.NomeUnidade.ToLower() == request.NomeUnidade.ToLower() && e.Id != id))
            {
                throw new ErrorOnValidationException("Fatec já cadastrada.");
            }

            fatec.NomeUnidade = request.NomeUnidade;

            await this._fatecRepository.UpdateAsync(fatec);
        }
    }
}