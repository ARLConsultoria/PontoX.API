using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoX.Domain.Entities;

namespace PontoX.Infrastucture.Infrastructure.Data.Configurations
{
    public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil").HasKey(x => x.Id);
                
            builder.Property(nameof(Perfil.Id)).ValueGeneratedOnAdd();
            builder.Property(nameof(Perfil.PerfilPaiId)).IsRequired();
            builder.Property(nameof(Perfil.DataCriacao)).IsRequired();
            builder.Property(nameof(Perfil.DataModificacao)).IsRequired();
            builder.Property(nameof(Perfil.Nome)).IsRequired();
        }
    }
}
