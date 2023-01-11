using ServiceBlack.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PontoX.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario() { }
        
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
        public long PerfilId { get; set; }
        [ForeignKey("PerfilId")]
        public Perfil Perfil { get; set; }  
    }
}