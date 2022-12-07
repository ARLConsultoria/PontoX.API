using Microsoft.EntityFrameworkCore;
using PontoX.Domain.Entities;
using PontoX.Infrastucture.Infrastructure.Data.Configurations;

namespace PontoX.Infrastucture
{
    public class PontoXContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public PontoXContext() { }

        public PontoXContext(DbContextOptions<PontoXContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var strConnection = "server=localhost;database=trabalho;user id=root;password=WWEpuiou12@; port=3306 ";
            optionsBuilder.UseMySql(strConnection, ServerVersion.Parse("8.0.31-mysql"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}