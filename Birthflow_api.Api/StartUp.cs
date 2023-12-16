using Birthflow_api.Infrastructure;
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
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionIntranetSQL"));
            });
         
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Birthflow_api.Api", Version = "Free", Description = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") });

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Birthflow_api.Api v1");
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
          

        }
    }

}
