using Birthflow_api.Application.Interfaces;
using Birthflow_api.Application.Services;
using Birthflow_api.Domain.Interfaces;
using Birthflow_api.Infrastructure;
using Birthflow_api.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;


namespace Birthflow_api.Api
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BirthflowDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionLocalSQL"));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BirthFlow.Api", Version = "Free", Description = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor ingrese el token JWT como: 'Bearer {TOKEN}'.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string [] { }
                    }
                });


            });
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });
            services.AddCors(options =>
            {
                options.AddPolicy("newPolicy", app =>
                {
                    app.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            // servicio para la generacion de PDFs
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            RegisterServices(services);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Alfie.Api v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseCors("newPolicy");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void RegisterServices(IServiceCollection services)
        { 
            services.AddScoped<PartographService>();
            services.AddScoped<PartographRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<UserRepository>();
            services.AddScoped<WorkTimeService>();
            services.AddScoped<WorkTimeRepository>();
            services.AddScoped<CervicalDilationService>();
            services.AddScoped<CervicalDilationRepository>();

        }
    }

}
