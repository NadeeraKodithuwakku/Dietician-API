using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Dietician.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseException();
            application.UseCorsAllowAny();
            application.UseHttps();
            application.UseRouting();
            application.UseResponseCompression();
            application.UseResponseCaching();
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseEndpoints();
            application.UseSwagger();
            application.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSecurity();
            services.AddResponseCompression();
            services.AddResponseCaching();
            services.AddControllersDefault();
            services.AddContext();
            services.AddServices();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dietician API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
