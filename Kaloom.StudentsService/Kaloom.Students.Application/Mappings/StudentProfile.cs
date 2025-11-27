using AutoMapper;
using Kaloom.SharedContracts.DTOs;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Domain.Models;

namespace Kaloom.Students.Application.Mappings
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
