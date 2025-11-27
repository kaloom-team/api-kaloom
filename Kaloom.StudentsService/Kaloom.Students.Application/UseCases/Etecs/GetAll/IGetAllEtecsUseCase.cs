using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.Etecs.GetAll
{
    public interface IGetAllEtecsUseCase
    {
        public Task<IEnumerable<EtecResponse>> ExecuteAsync();
    }
}
