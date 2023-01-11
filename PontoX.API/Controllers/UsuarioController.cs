using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoX.Application;
using PontoX.Application.Interfaces;
using PontoX.Application.Models.Usuario;
using PontoX.Domain.Entities;
using PontoX.Infrastucture.Infrastructure.Data.Repositories;

namespace PontoX.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IApplicationServiceUsuario _applicationServiceUsuario;

        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario)
        {
            _applicationServiceUsuario = applicationServiceUsuario;
        }

        

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromQuery] string email, string senha )
        {
           
           var user = await _applicationServiceUsuario.BuscarPor(email, senha);
           
           if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

           var token =  ApplicationServiceToken.GerarToken(user);
           
           user.Senha = "";

           return new
           {
              user = user,
              token = token
           };
        }

        [HttpGet]
        [Route("ListarUsuarios")]
        [Authorize]
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                return Ok( await _applicationServiceUsuario.ListarUsuarios());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        [Route("CadastrarUsuario")]
        public async Task<IActionResult> Post([FromBody] UsuarioRequest model)
        {
            try
            {
                return Ok(await _applicationServiceUsuario.CadastrarUsuario(model));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete]
        [Route("DesativarUsuario")]
        [Authorize]
        public async Task<IActionResult> DesativarUsuario(int id)
        {
            try
            {
                return Ok( await _applicationServiceUsuario.DesativarUsuario(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        [Route("AtualizarUsuario")]
        [Authorize]
        public async Task<IActionResult> AtualizarDadosUsuario(UsuarioRequest usuario)
        {
            try
            {
                return Ok( await _applicationServiceUsuario.AtualizarUsuario(usuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
