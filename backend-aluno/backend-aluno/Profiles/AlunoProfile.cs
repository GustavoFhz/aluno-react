using AutoMapper;
using backend_aluno.Dto;
using backend_aluno.Models;

namespace backend_aluno.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<AlunoCriacaoDto, AlunoModel>();
        }
    }
}
