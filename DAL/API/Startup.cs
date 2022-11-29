using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL;
using Microsoft.OpenApi.Models;

namespace API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            //ADD Cors
            services.AddCors(p => p.AddPolicy("AlowAll", option =>
            {
                option.AllowAnyMethod();
                option.AllowAnyHeader();
                option.AllowAnyOrigin();
            }));

            //ADD Scoped
            services.AddScoped(typeof(IDalAdditive), typeof(DalAdditive));
            services.AddScoped(typeof(IBllAdditive), typeof(BllAdditive));

            services.AddScoped(typeof(IDalHirer), typeof(DalHirer));
            services.AddScoped(typeof(IBllHirer), typeof(BllHirer));

            services.AddScoped(typeof(IDalManager), typeof(DalManager));
            services.AddScoped(typeof(IBllManager), typeof(BllManager));

            services.AddScoped(typeof(IDalOffice), typeof(DalOffice));
            services.AddScoped(typeof(IBllOffice), typeof(BllOffice));

            services.AddScoped(typeof(IDalRenter), typeof(DalRenter));
            services.AddScoped(typeof(IBllRenter), typeof(BllRenter));
            services.AddScoped(typeof(IBllMatch), typeof(BllMatch));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors("AlowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
