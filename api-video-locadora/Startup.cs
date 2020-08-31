using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_video_locadora.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace api_video_locadora
{
    public class Startup

    {
        public IConfiguration Conf { get; }
        public Startup(IConfiguration conf)
        {
            Conf = conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddBootStrapperIoC();
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Video Locadora",
                    Description = "API REST Video Locadora",
                    Contact = new OpenApiContact()
                    {
                        Name = "Ana Carolina Dias",
                        Email = "carolinadiasdc@gmail.com",
                        Url = new Uri("https://github.com/carolinadiasdc")
                    },
                });

                c.EnableAnnotations();

            });

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Video Locadora v1");
            });
        }
    }
}
