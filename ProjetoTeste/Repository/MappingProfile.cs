using AutoMapper;
using ProjetoTeste.DTOs;
using ProjetoTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Repository
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Contrato, ContratoDTO>().ReverseMap();
            CreateMap<Prestacao, PrestacaoDTO>().ReverseMap();
        }
    }
}
