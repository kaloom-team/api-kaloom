using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Domain.Repositories.Abstractions;
using static Kaloom.Students.Application.UseCases.Etecs.Utils.EtecValidate;

namespace Kaloom.Students.Application.UseCases.Etecs.Update
{
    public class UpdateEtecUseCase : IUpdateEtecUseCase
    {
        private readonly IEtecRepository _etecRepository;

        public UpdateEtecUseCase(IEtecRepository etecRepository)
        {
            this._etecRepository = etecRepository;
        }
        public async Task ExecuteAsync(int id, EtecRequest request)
        {
            Validate(request);

            var etec = await this._etecRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Etec com ID {id} não encontrada.");

            var etecs = await _etecRepository.GetAllAsync();

            if (etecs.Any(e => e.NomeUnidade.ToLower() == request.NomeUnidade.ToLower() && e.Id != id))
            {
                throw new ErrorOnValidationException("Etec já cadastrada.");
            }

            etec.NomeUnidade = request.NomeUnidade;

            await _etecRepository.UpdateAsync(etec);
        }
    }
}