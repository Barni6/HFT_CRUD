using KJWTMR_HFT_2022231.Repository;
using KJWTMR_HTF_2022231.Logic;
using KJWTMR_HTF_2022231.Logic.Interfaces;
using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Data;
using KJWTMR_HTF_2022231.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KJWTMR_HFT_2022231.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KJWTMR_HFT_2022231.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
