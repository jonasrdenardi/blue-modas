using BlueModas.Domain.Interfaces;
using BlueModas.Infra.CrossCutting.Authentication;
using BlueModas.Infra.Data.Context;
using BlueModas.Infra.Data.Repository;
using BlueModas.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;

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
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options => {options.SerializerSettings.ContractResolver = new DefaultContractResolver();});

            services.AddTransient<IServiceCliente, ClienteService>();
            services.AddTransient<IServiceProduto, ProdutoService>();
            services.AddTransient<IServiceCesta, CestaService>();
            services.AddTransient<IServicePedido, PedidoService>();

            services.AddTransient<IRepositoryCliente, ClienteRepository>();
            services.AddTransient<IRepositoryProduto, ProdutoRepository>();
            services.AddTransient<IRepositoryCesta, CestaRepository>();
            services.AddTransient<IRepositoryPedido, PedidoRepository>();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("EnableCORS", builder =>
            //    {
            //        builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
            //    });
            //});

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            )
            .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
            );

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

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            //app.UseCors("EnableCORS");

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
