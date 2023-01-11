using AutoMapper;
using PontoX.Application.Models.LancamentoHoras;
using PontoX.Application.Models.Perfil;
using PontoX.Application.Models.Usuario;
using PontoX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoX.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {   
            //AutoMapper LancamentoHoras
            CreateMap<LancamentoHorasRequest, LancamentoHoras>();

            CreateMap<LancamentoHoras, LancamentoHorasResponse>();

            //AutoMapper Perfil
            CreateMap<PerfilRequest, Perfil>();

            CreateMap<Perfil, PerfilResponse>();

            //AutoMapper Usuario
            CreateMap<UsuarioRequest, Usuario>();

            CreateMap<Usuario, UsuarioResponse>();  
        }   
    }
}
