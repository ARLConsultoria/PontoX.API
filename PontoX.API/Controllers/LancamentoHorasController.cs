using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoX.Application.Interfaces;
using PontoX.Application.Models.LancamentoHoras;
using System.Net;


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
        [Authorize]
        public async Task<IActionResult> ListarLancamentoHoras()

        {
            try
            {
                return Ok(await _applicationServiceLancamentoHoras.ListarLancamentoHoras());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        [Route("CadastrarHoras")]
        [Authorize]
        public async Task<IActionResult> CadastrarLancamentoHoras([FromBody] LancamentoHorasRequest model)
        {
            try
            {
                return Ok(await _applicationServiceLancamentoHoras.CadastrarLancamentoHoras(model));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        [Route("AtualizarHoras")]
        [Authorize]
        public async Task<IActionResult> AtualizarLancamentoHoras(LancamentoHorasRequest usuario)
        {
            try
            {
                return Ok(await _applicationServiceLancamentoHoras.AtualizarLancamentoHoras(usuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}
