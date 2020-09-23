namespace FinantialCalculator.Api
{
    using FinantialCalculator.Domain.Contracts.ServiceContracts;
    using FinantialCalculator.Domain.Implementations;
    using FinantialCalculator.Services.Services.AmortizationSchedule;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Swashbuckle.AspNetCore.Swagger;
    using Microsoft.OpenApi.Models;

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
            #region Json Config
            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
            #endregion Json Config

            services.AddControllers();

            #region Swagger Config
            services.AddSwaggerGen(config => config.SwaggerDoc("v1", new OpenApiInfo 
            {
                Version = "v1",
                Title = "FinantialCalculatorApi",
                Description = "Finantial Calculator Api",
                Contact = new OpenApiContact 
                {
                    Name = "Alejandro Vargas",
                    Email = "megatras08@gmail.com"
                }
            }));
            #endregion Swagger Config

            #region Dependency Injection
            services.AddScoped<IAmortizationScheduleService, AmortizationScheduleService>();
            #endregion Dependency Injection
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

            app.UseSwagger();
            app.UseSwaggerUI(config => 
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "API Test Version 1");
            });
        }
    }
}
