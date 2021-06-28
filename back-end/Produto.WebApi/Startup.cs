using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Produto.Application.Interfaces.Services;
using Produto.Application.Services;
using Produto.Domain.Interfaces.Repository;
using Produto.Infra.Configuration;
using Produto.Infra.Repositories;

namespace Produto.WebApi
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();            

            var connectionString = Configuration.GetValue<string>("SQLConnectionString");

            services.AddSingleton(new SQLConfiguration { ConnectionString = connectionString });

            services.AddDbContext<Context>();

            services.AddCors(options => {
                options.AddPolicy("mypolicy", builder => builder
                 .WithOrigins("http://localhost:4200")
                 .SetIsOriginAllowed((host) => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(p => p.Build());
            app.UseMvc();
        }
    }
}
