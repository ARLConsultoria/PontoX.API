using Microsoft.EntityFrameworkCore;
using PontoX.Domain.Entities;
using PontoX.Infrastucture.Infrastructure.Data.Configurations;

namespace PontoX.Infrastucture
{
    public class PontoXContext : DbContext
    {
        public DbSet<LancamentoHoras> LancamentosHoras { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        public PontoXContext() { }

        public PontoXContext(DbContextOptions<PontoXContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var strConnection = "server=127.0.0.1;database=trabalho;user id=root;password=Gabriel123; port=3306 ";
            optionsBuilder.UseMySql(strConnection, ServerVersion.Parse("8.0.31-mysql"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LancamentoHorasConfiguration());
            modelBuilder.ApplyConfiguration(new PerfilConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}