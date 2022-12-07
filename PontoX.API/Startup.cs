using Microsoft.OpenApi.Models;
using PontoX.CrossCutting;
using PontoX.Infrastucture;

namespace PontoX
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PontoXContext>();
            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PontoX", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("PontoXPolicy", builder => builder.AllowAnyMethod()
                                                                            .AllowAnyOrigin()
                                                                            .SetIsOriginAllowed(_ => true)
                                                                            .Build());
            });

            ConfigurationIOC.LoadServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PontoX v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("PontoXPolicy");
        }
    }
}
