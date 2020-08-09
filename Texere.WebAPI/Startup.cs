using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Texere.DataAccess;
using Texere.Service;
using Texere.Service.Interfaces;

namespace Texere.WebAPI
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
            services.AddControllers();
            var connection = Configuration.GetConnectionString("myconn");
            services.AddDbContext<TexereDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IClientesService, ClientesService>(); 
           
            services.AddTransient<ITallesService, TallesService>();
            
            services.AddTransient<IAccesoriosService, AccesoriosService>();
            
            services.AddTransient<IModelosService, ModelosService>();
            
            services.AddTransient<IPedidosService, PedidosService>();
            
            services.AddTransient<IMaterialesService, MaterialesService>();
            
            services.AddTransient<ILineasPedidoService, LineasPedidoService>();
            
            services.AddTransient<IPrecioAccesorioService, PrecioAccesorioService>();       
            
            services.AddTransient<IColoresService, ColoresService>();
            
            services.AddTransient<IInstitucionesService, InstitucionesService>();

            services.AddCors(options =>
                {
                    options.AddPolicy("AllowSpecificOrigin", builder =>
                        builder.AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowAnyOrigin()
                    );
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
