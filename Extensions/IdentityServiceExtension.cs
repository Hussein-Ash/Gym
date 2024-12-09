<<<<<<< HEAD
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
=======
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
>>>>>>> 6c75216 (Initial commit)
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EvaluationBackend.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration config)
        {


            services.AddSwaggerGen(option =>
            {
<<<<<<< HEAD
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Models API", Version = "v1" });
=======
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Gym", Version = "v1" });
>>>>>>> 6c75216 (Initial commit)
                // option.SwaggerDoc("v2", new OpenApiInfo { Title = "Structure API v2", Version = "v2" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
<<<<<<< HEAD
=======
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);
>>>>>>> 6c75216 (Initial commit)
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RoleClaimType = "Role", // Custom claim type for roles
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
                // Enable JWT for SignalR
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // Get the token from the query string for SignalR
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for the SignalR hub
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chathub"))
                        {
                            // Read the token from the query string
<<<<<<< HEAD
                            
                            context.Token =accessToken;
=======

                            context.Token = accessToken;
>>>>>>> 6c75216 (Initial commit)
                        }


                        return Task.CompletedTask;
                    }
                };

            });



            return services;
        }
    }
}