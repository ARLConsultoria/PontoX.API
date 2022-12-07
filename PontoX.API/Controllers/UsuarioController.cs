using Microsoft.AspNetCore.Mvc;
using PontoX.Application.Interfaces;
using PontoX.Application.Models.Usuario;

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


        [HttpGet]
        [Route("ListarUsuarios")]
        public  Task<List<UsuarioResponse>> ListarUsuarios()
        {
            return  _applicationServiceUsuario.ListarUsuarios();
        }

        [HttpPost]
        public Task<bool> Post([FromBody] UsuarioRequest model)
        {
            return _applicationServiceUsuario.CadastrarUsuario(model);
        }

        [HttpPatch]
        [Route("DesativarUsuario")]
        public Task<bool> DesativarUsuario(int id)
        {
            return _applicationServiceUsuario.DesativarUsuario(id);
        }

        [HttpPut]
        public Task<bool> AtualizarDadosUsuario(UsuarioRequest usuario)
        {
            return _applicationServiceUsuario.AtualizarUsuario(usuario);
        }
    }
}
