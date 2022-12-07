using ServiceBlack.Domain.Entities.Base;

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
    }
}