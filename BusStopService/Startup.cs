using AutoMapper;
using BusStopService.Repositories;
using BusStopService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusStopService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBusStopRepository, BusStopRepository>();
            services.AddTransient<IBusStopService, Services.BusStopService>();

            services.AddCors();
            services.AddAutoMapper();
            services.AddMvcCore().AddJsonFormatters();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => { builder.AllowAnyOrigin(); });
            app.UseMvc();
        }
    }
}
