using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.DAL.DB;
using GroceryStoreAPI.DAL.Repositories;
using GroceryStoreAPI.Services;

namespace GroceryStoreAPI
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
			services.AddScoped<ICustomersRepository, CustomersRepository>();
			services.AddScoped<ICustomersService, CustomersService>();

            var filepath = _env.ContentRootPath + @"\database.json";
			var theData = JsonDataService.LoadDataFromFile(filepath);
            services.AddSingleton(sp => theData);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(
                    
                );
            });
        }
    }
}
