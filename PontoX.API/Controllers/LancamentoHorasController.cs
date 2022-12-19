using Microsoft.AspNetCore.Mvc;
using PontoX.Application.Interfaces;
using PontoX.Application.Models.LancamentoHoras;

namespace PontoX.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoHorasController : ControllerBase
    {
        private readonly IApplicationServiceLancamentoHoras _applicationServiceLancamentoHoras;

        public LancamentoHorasController(IApplicationServiceLancamentoHoras applicationServiceLancamentoHoras)
        {
            _applicationServiceLancamentoHoras = applicationServiceLancamentoHoras;
        }


        [HttpGet]
        [Route("ListarHoras")]
        public  Task<List<LancamentoHorasResponse>> ListarLancamentoHoras()
        {
            return _applicationServiceLancamentoHoras.ListarLancamentoHoras();
        }

        [HttpPost]
        [Route("CadastrarHoras")]
        public Task<bool> CadastrarLancamentoHoras([FromBody] LancamentoHorasRequest model)
        {
            return _applicationServiceLancamentoHoras.CadastrarLancamentoHoras(model);
        }

        [HttpPut]
        [Route("AtualizarHoras")]
        public Task<bool> AtualizarLancamentoHoras(LancamentoHorasRequest usuario)
        {
            return _applicationServiceLancamentoHoras.AtualizarLancamentoHoras(usuario);
        }
    }
}
