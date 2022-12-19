using PontoX.Application.Models.LancamentoHoras;
using PontoX.Application.Models.Perfil;
using PontoX.Application.Models.Usuario;

namespace PontoX.Application.Interfaces
{
    public interface IApplicationServiceLancamentoHoras
    {
        Task<bool> CadastrarLancamentoHoras(LancamentoHorasRequest cliente);
        Task<bool> AtualizarLancamentoHoras(LancamentoHorasRequest cliente);
        Task<List<LancamentoHorasResponse>> ListarLancamentoHoras();
    }
}
