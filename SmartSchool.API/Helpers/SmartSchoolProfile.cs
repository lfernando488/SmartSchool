using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SmartSchool.API.DTO;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.API.Helper{
    public class SmartSchoolProfile : Profile{

        public SmartSchoolProfile(){
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt  => opt.MapFrom(src => src.DataNasc.GetCurrentAge()));

            CreateMap<AlunoDTO, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDTO>().ReverseMap();

            CreateMap<ProfessorDTO, Professor>();
            CreateMap<Professor, ProfessorRegistrarDTO>().ReverseMap();

        }

    }
}
