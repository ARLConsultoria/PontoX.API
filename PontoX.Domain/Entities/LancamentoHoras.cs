using ServiceBlack.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PontoX.Domain.Entities
{
    public class LancamentoHoras : BaseEntity
    {
        public LancamentoHoras() { }
       
        public int HoraInicio { get; set; }
        public int HoraFim { get; set; }
        public long UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }    
        public bool? Aprovacao { get; set; }
        public string? MensagemAprovacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}


