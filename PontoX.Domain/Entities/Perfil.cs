using ServiceBlack.Domain.Entities.Base;

namespace PontoX.Domain.Entities
{
    public class Perfil : BaseEntity
    {
        public Perfil() { }
        
        public long PerfilPaiId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public string Nome { get; set; }
    }
}