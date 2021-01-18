using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace SmartSchool.API
{
    public class Startup{

        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services){
            
            services.AddDbContext<SmartContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            //Tratar looping json
            services.AddControllers()
                 .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Informa quais classes herdam de profile (busca das dlls) para realizar o mapeamento
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // services.AddSingleton<IRepository, Repository>();
            // services.AddTransient<IRepository, Repository>();
            services.AddScoped<IRepository, Repository>();

            services.AddVersionedApiExplorer(options =>{
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            }
                )
                .AddApiVersioning(options =>{
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.ReportApiVersions = true;
                });

            var apiProviderDescription = services.BuildServiceProvider()
                .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options =>{

                foreach(var description in apiProviderDescription.ApiVersionDescriptions){
                    options.SwaggerDoc(
                        description.GroupName,
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "SmartSchool API",
                            Version = "1.0",
                            TermsOfService = new Uri("http://meustermosdeuso.com"),
                            Description = "Descrição da WEB API SmartSchool",
                            License = new Microsoft.OpenApi.Models.OpenApiLicense
                                {
                                    Name = "Smart School License",
                                    Url = new Uri("http://mit.com")
                                },
                                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                                {
                                    Name = "Luiz Fernando",
                                    Email = "lfernando488@gmail.com",
                                    Url = new Uri("https://github.com/lfernando488/")
                                }
                        }
                    );
                }

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                options.IncludeXmlComments(xmlCommentsFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                                IApiVersionDescriptionProvider apiVersionDescriptionProvider){
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger()
               .UseSwaggerUI( options =>
               {
                   foreach(var description in apiVersionDescriptionProvider.ApiVersionDescriptions){
                       options.SwaggerEndpoint(
                           $"/swagger/{description.GroupName}/swagger.json", 
                           description.GroupName.ToUpperInvariant()
                       );
                   }

                   options.RoutePrefix = "";
               }
                );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
