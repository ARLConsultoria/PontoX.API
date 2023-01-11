using AutoMapper;
using PontoX.Application.Interfaces;
using PontoX.Application.Models.Usuario;
using PontoX.Domain.Entities;
using ServiceBlackDomain.Core.Interfaces.Services;

namespace PontoX.Application
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _service;
        private readonly IServicePerfil _servicePerfil;
        private readonly IMapper _mapper;
        public ApplicationServiceUsuario(IServiceUsuario service, IServicePerfil servicePerfil, IMapper mapper)
        {
            _service = service;
            _servicePerfil = servicePerfil;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarUsuario(UsuarioRequest request)
        {
            return await _service.Atualizar(_mapper.Map<Usuario>(request));
        }

        public async Task<bool> CadastrarUsuario(UsuarioRequest request)
        {
            if (request.PerfilId == 0 || request.PerfilId == null)
            {
                return false;
            }
            else
            {
                var verification = await _servicePerfil.Consultar(request.PerfilId);
                if (verification == null)
                {
                    return false;
                }
                else
                {
                    return await _service.Adicionar( _mapper.Map<Usuario>(request));
                }
            }
        }

        public async Task<bool> DesativarUsuario(int idCliente)
        {
            var usuario = await _service.Consultar(idCliente);
            usuario.Ativo = false;
            return await _service.Atualizar(usuario);
        }

        public async Task<List<UsuarioResponse>> ListarUsuarios()
        {
            List<UsuarioResponse> usuarioResponses = new List<UsuarioResponse>();
            var usuarios = await _service.Consultar();
            //todo = criar autoMapper
            foreach (var item in usuarios)
                usuarioResponses.Add(_mapper.Map<UsuarioResponse>(item));

            return usuarioResponses;
        }

        public async Task<Usuario> BuscarPor(string email, string senha)
        {
            var usuario = await _service.BuscarLogin(email, senha);
            if (usuario == null)
            {
                return usuario;
            }
            else
                return usuario;
        }
    }
}
