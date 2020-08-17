using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boticario_api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Boticario_api.Data;
using System.Reflection;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace Boticario_api
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
            var connection = Configuration["MySql:MySqlConnectionString"];
            services.AddDbContext<Context>(options =>
                options.UseMySql(connection)
            );
            // Add framework services.
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Boticario CashBack API - POC",
                    Version = "v1",
                    Description = "O Boticário tem várias soluções para ajudar seus revendedores(as) a gerir suas finanças e alavancar suas vendas. Também existem iniciativas para impulsionar as operações de vendas como metas gameficadas e desconto em grandes quantidades de compras. /n A oportunidade proposta é criar um sistema de Cashback, onde o valor será disponibilizado como crédito para a próxima compra da revendedora no Boticário."
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/docs/{documentName}/boticario.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/docs/v1/boticario.json", "Boticário Cashback API - POC");
                c.RoutePrefix = "docs";


                //c.InjectStylesheet("/swagger-ui/custom.css");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

         
            
           
            InicializaDB.Initialize(context);
        }
    }
}
