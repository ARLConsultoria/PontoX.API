using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> ListarPerfis()
        {
            try
            {
                return Ok( await _applicationServicePerfil.ListarPerfis());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
           
        }

        [HttpPost]
        [Route("CadastrarPerfil")]
        [Authorize]
        public async Task<IActionResult> CadastrarPerfil([FromBody] PerfilRequest model)
        {
            try
            {
                return Ok ( await _applicationServicePerfil.CadastrarPerfil(model));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [HttpDelete]
        [Route("ExcluirPerfil")]
        [Authorize]
        public async Task<IActionResult> ExcluirPerfil(long id)
        {
            try
            {
                return Ok( await _applicationServicePerfil.ExcluirPerfil(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        [Route("AtualizarPerfil")]
        [Authorize]
        public async Task<IActionResult> AtualizarPerfil(PerfilRequest usuario)
        {
            try
            {
                return Ok( await _applicationServicePerfil.AtualizarPerfil(usuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
