using api_video_locadora.Application;
using api_video_locadora.Application.Interfaces;
using api_video_locadora.Dados.Repositorio;
using api_video_locadora.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_video_locadora.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static IServiceCollection AddBootStrapperIoC(
            this IServiceCollection services
            )
        {
            //services
            services.AddSingleton<IClienteAppService, ClienteAppService>();
            services.AddSingleton<IFilmeAppService, FilmeAppService>();
            services.AddSingleton<ILocacaoAppService, LocacaoAppService>();

            //repositorio
            services.AddSingleton<IClienteRepositorio, ClienteRepositorio>();
            services.AddSingleton<IFilmeRepositorio, FilmeRepositorio>();
            services.AddSingleton<ILocacaoRepositorio, LocacaoRepositorio>();

            return services;
        }
    }
}
