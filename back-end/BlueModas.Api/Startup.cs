using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueModas.Domain.Interfaces;
using BlueModas.Infra.Data.Context;
using BlueModas.Infra.Data.Repository;
using BlueModas.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace BlueModas.Api
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
            services.AddControllers().AddNewtonsoftJson(options => {options.SerializerSettings.ContractResolver = new DefaultContractResolver();});

            services.AddTransient<IServiceCliente, ClienteService>();
            services.AddTransient<IServiceProduto, ProdutoService>();
            services.AddTransient<IServiceCesta, CestaService>();
            services.AddTransient<IServicePedido, PedidoService>();

            services.AddTransient<IRepositoryCliente, ClienteRepository>();
            services.AddTransient<IRepositoryProduto, ProdutoRepository>();
            services.AddTransient<IRepositoryCesta, CestaRepository>();
            services.AddTransient<IRepositoryPedido, PedidoRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
            services.AddDbContext<BlueModasContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("EnableCORS");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
