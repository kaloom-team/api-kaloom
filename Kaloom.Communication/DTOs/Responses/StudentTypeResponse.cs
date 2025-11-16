using Kaloom.Communication.Enums;

namespace Kaloom.Communication.DTOs.Responses
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