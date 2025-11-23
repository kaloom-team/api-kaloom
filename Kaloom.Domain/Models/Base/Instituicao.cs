using Kaloom.Domain.Models.Base;

namespace Kaloom.Domain.Models.Base
{
    public abstract class Instituicao : Entity
    {
        public string NomeUnidade { get; set; } = string.Empty;
    }
}
