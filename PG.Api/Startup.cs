using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PG.Application.Handlers.QueryHandlers.Clips;
using PG.Application.Requests.Clips;
using PG.Application.Responses.Clips;
using PG.Models;
using PG.Services;
using PG.Services.Contracts;

namespace PG.Api
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
            services.AddSingleton(new ConnectionString(Configuration.GetConnectionString("DefaultConnection")));

            var assembly = System.AppDomain.CurrentDomain.Load("PG.Application");
            services.AddMediatR(assembly);
            
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IClipService, ClipService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
