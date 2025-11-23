using AutoMapper;
using Kaloom.Domain.Models;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentRequest, Aluno>()
             .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<Aluno, StudentResponse>();
        }
    }
}
