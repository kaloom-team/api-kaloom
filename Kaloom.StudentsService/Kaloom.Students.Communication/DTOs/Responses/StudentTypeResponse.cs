using Kaloom.Students.Domain.Enums;

namespace Kaloom.Students.Communication.DTOs.Responses
{
    public sealed record StudentTypeResponse
    (
        int Id,
        bool Fatec,
        bool Etec,
        EAcademicStatus? StatusEtec,
        EAcademicStatus? StatusFatec,
        string Description
    );
}