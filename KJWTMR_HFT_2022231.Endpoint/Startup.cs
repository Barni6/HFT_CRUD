using Castle.Core.Configuration;
using KJWTMR_HFT_2022231.Repository;
using KJWTMR_HTF_2022231.Logic;
using KJWTMR_HTF_2022231.Logic.Interfaces;
using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Data;
using KJWTMR_HTF_2022231.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = KJWTMR_HTF_2022231.Models.Type;

namespace KJWTMR_HFT_2022231.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<BeerShopDBContext>();

            services.AddTransient<IRepository<Beer>, BeerRepository>();
            services.AddTransient<IRepository<Brand>, BrandRepository>();
            services.AddTransient<IRepository<Type>, TypeRepository>();

            services.AddTransient<IBeerLogic,BeerLogic>();
            services.AddTransient<IBeerShopLogic<Brand>,BrandLogic>();
            services.AddTransient<IBeerShopLogic<Type>,TypeLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BeerShop.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
