using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoX.Domain.Entities;

namespace PontoX.Infrastucture.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario").HasKey(x => x.Id);
                
            builder.Property(nameof(Usuario.Id)).ValueGeneratedOnAdd();
            builder.Property(nameof(Usuario.Email)).IsRequired();
            builder.Property(nameof(Usuario.Senha)).IsRequired();
            builder.Property(nameof(Usuario.Nome)).IsRequired();
            builder.Property(nameof(Usuario.CPF)).IsRequired();
            builder.Property(nameof(Usuario.Ativo)).IsRequired();
        }
    }
}
