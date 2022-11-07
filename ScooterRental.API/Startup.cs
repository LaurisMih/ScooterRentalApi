using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ScooterRental.Services.Interfaces;
using ScooterRental.Main.Calculations;
using ScooterRental.Data;
using ScooterRental.Services;
using ScooterRental.Main.Models;
using ScooterRental.Main.Interfaces;
using ScooterRental.Services.Services;

namespace ScooterRental.Main
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScooterRentalAPI", Version = "v1" });
            });
           
            services.AddDbContext<ScooterRentalDbContext>(options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                ));
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IEntityService<Scooter>, EntityService<Scooter>>();
            services.AddScoped<IEntityService<RentedScooters>, EntityService<RentedScooters>>();
            services.AddScoped<IScooterService, ScooterService>();
            services.AddScoped<IRentalCompany, RentalCompany>();
            services.AddScoped<IScooterRentalDbContext, ScooterRentalDbContext>();
            services.AddScoped<IRentCalculator, RentCalculator>();

        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScooterRentalAPI v1"));
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
