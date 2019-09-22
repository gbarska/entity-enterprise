using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using SharedKernel;
using Maintenance.Domain;
using Maintenance.Data;
using ShoppingCart.Data;
using ShoppingCart.Services;
using ShoppingCart.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MvcSalesApp.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Customer>, CustomerRepository>();
            services.AddScoped<IOrderingService, WebSiteOrderingService>();
            services.AddScoped<IOrderData, WebSiteOrderData>();
            services.AddDbContext<MaintenanceContext>(o => o.UseMySql("Server=localhost;Port=3306;Database=salesrefac;Uid=gbarska;Pwd=password;"));
            services.AddDbContext<ShoppingCartContext>(o => o.UseMySql("Server=localhost;Port=3306;Database=salesrefac;Uid=gbarska;Pwd=password;"));
            services.AddDbContext<ReferenceContext>(o => o.UseMySql("Server=localhost;Port=3306;Database=salesrefac;Uid=gbarska;Pwd=password;"));

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
