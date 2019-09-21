﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace MvcSalesApp.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddScoped<IHeroesRepository, HeroRepository>();
            // services.AddScoped<MySQLContexts, MySQLContexts>();
            // services.AddScoped<HeroesHandler, HeroesHandler>();
            // services.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            // services.AddScoped<IMapper>(sp => 
            // new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddMvc();

             services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("V1", new Info { Title = "Projeto API com Dapper", Version = "V1" });
            });
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
             if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Test.Web.Api");
            }); 
        }
    }
}
