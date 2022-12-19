using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoX.Domain.Entities;

namespace PontoX.Infrastucture.Infrastructure.Data.Configurations
{
    public class LancamentoHorasConfiguration : IEntityTypeConfiguration<LancamentoHoras>
    {
        public void Configure(EntityTypeBuilder<LancamentoHoras> builder)
        {
            builder.ToTable("LancamentoHoras").HasKey(x => x.Id);
                
            builder.Property(nameof(LancamentoHoras.Id)).ValueGeneratedOnAdd();
            builder.Property(nameof(LancamentoHoras.UsuarioId)).IsRequired();
            builder.Property(nameof(LancamentoHoras.HoraInicio)).IsRequired();
            builder.Property(nameof(LancamentoHoras.HoraFim)).IsRequired();
            builder.Property(nameof(LancamentoHoras.DataCriacao)).IsRequired();
            builder.Property(nameof(LancamentoHoras.DataModificacao)).IsRequired();
            builder.Property(nameof(LancamentoHoras.Aprovacao));
            builder.Property(nameof(LancamentoHoras.MensagemAprovacao));
        }
    }
}
 