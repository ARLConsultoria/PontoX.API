using Microsoft.Extensions.DependencyInjection;
using PontoX.Application;
using PontoX.Application.Interfaces;
using PontoX.Domain.Core.Interfaces.Repositories;
using PontoX.Domain.Entities;
using PontoX.Domain.Service.ServiceLancamentoHoras;
using PontoX.Domain.Service.ServiceUsuario;
using PontoX.Infrastructure.Data.Repositories;
using PontoX.Infrastucture.Infrastructure.Data.Repositories;
using ServiceBlackDomain.Core.Interfaces.Services;
using ServiceBlackDomain.Services;

namespace PontoX.CrossCutting
{
    public class ConfigurationIOC
    {
        public static void LoadServices(IServiceCollection services)
        {
            services.AddScoped<IApplicationServiceUsuario, ApplicationServiceUsuario>();
            services.AddScoped<IRepositoryUsuario, UsuarioRepository>();
            services.AddScoped<IServiceUsuario, ServiceUsuario>();
            services.AddScoped<IServiceBase<Usuario>, ServiceBase<Usuario>>();
            services.AddScoped<IRepositoryBase<Usuario>, BaseRepository<Usuario>>();


            services.AddScoped<IApplicationServicePerfil, ApplicationServicePerfil>();
            services.AddScoped<IRepositoryPerfil, PerfilRepository>();
            services.AddScoped<IServicePerfil, ServicePerfil>();
            services.AddScoped<IServiceBase<Perfil>, ServiceBase<Perfil>>();
            services.AddScoped<IRepositoryBase<Perfil>, BaseRepository<Perfil>>();


            services.AddScoped<IApplicationServiceLancamentoHoras, ApplicationServiceLancamentoHoras>();
            services.AddScoped<IRepositoryLancamentoHoras, LancamentoHorasRepository>();
            services.AddScoped<IServiceLancamentoHoras, ServiceLancamentoHoras>();
            services.AddScoped<IServiceBase<LancamentoHoras>, ServiceBase<LancamentoHoras>>();
            services.AddScoped<IRepositoryBase<LancamentoHoras>, BaseRepository<LancamentoHoras>>();
        }
    }
}