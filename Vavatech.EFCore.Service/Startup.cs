using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vavatech.EFCore.DbServices;
using Vavatech.EFCore.FakeServices;
using Vavatech.EFCore.IServices;

namespace Vavatech.EFCore.Service
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
            // Rejestracja usługi
            //  services.AddScoped<IProductsService, FakeProductsService>();

            // PM: Install-Package Microsoft.EntityFrameworkCore.SqlServer -v 2.1.4

            // string connectionString = "Server=(local)\\SQLEXPRESS;Database=mydb;Integrated Security=true"; ;

            string connectionString = Configuration.GetConnectionString("ShopConnectionString");

            services.AddDbContext<ShopContext>(
                options => options.UseSqlServer(connectionString));

             services.AddScoped<IProductsService, DbProductsService>();

            // services.AddSingleton<IProductsService, FakeProductsService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
