using Kaloom.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Kaloom.Communication.DTOs.Requests
{
    public class StudentTypeRequest
    {
        public int Id { get; set; }
        public bool Fatec { get; set; }
        public bool Etec { get; set; }

        [EnumDataType(typeof(EAcademicStatus))]
        public EAcademicStatus? StatusEtec { get; set; }

        [EnumDataType(typeof(EAcademicStatus))]
        public EAcademicStatus? StatusFatec { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}