using PontoX.Application.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoX.Application.Models.LancamentoHoras
{
    public class LancamentoHorasResponse
    {
        public int HoraInicio { get; set; }
        public int HoraFim { get; set; }
        public UsuarioResponse Usuario { get; set; }
        public bool? Aprovacao { get; set; }
        public string? MensagemAprovacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
