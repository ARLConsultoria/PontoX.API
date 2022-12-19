using Microsoft.AspNetCore.Mvc;
using PontoX.Application.Interfaces;
using PontoX.Application.Models.Perfil;

namespace PontoX.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly IApplicationServicePerfil _applicationServicePerfil;

        public PerfilController(IApplicationServicePerfil applicationServicePerfil)
        {
            _applicationServicePerfil = applicationServicePerfil;
        }


        [HttpGet]
        [Route("ListarPerfis")]
        public  Task<List<PerfilResponse>> ListarPerfis()
        {
            return _applicationServicePerfil.ListarPerfis();
        }

        [HttpPost]
        [Route("CadastrarPerfil")]
        public Task<bool> CadastrarPerfil([FromBody] PerfilRequest model)
        {
            return _applicationServicePerfil.CadastrarPerfil(model);
        }

        [HttpDelete]
        [Route("ExcluirPerfil")]
        public Task<bool> ExcluirPerfil(long id)
        {
            return _applicationServicePerfil.ExcluirPerfil(id);
        }

        [HttpPut]
        [Route("AtualizarPerfil")]
        public Task<bool> AtualizarPerfil(PerfilRequest usuario)
        {
            return _applicationServicePerfil.AtualizarPerfil(usuario);
        }
    }
}
