using Infra.Models;
using Infra.Repositories.Classes;
using Infra.Repositories.Interfaces;
using Infra.Services.Classes;
using Infra.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Bootstrapper
{
    public static class ConfigurationExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {

            // opposer data
            services.AddScoped<IMongoRepository<Opposer>>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<MongoServicePoptions>>().Value;
                return new MongoRepository<Opposer>(options.MongoDatabase, options.CollectionName, options.Opposer);
            });

            // issuer data
            services.AddScoped<IMongoRepository<Issuer>>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<MongoServicePoptions>>().Value;
                return new MongoRepository<Issuer>(options.MongoDatabase, options.CollectionName, options.Issuer);
            });

            //response data
            services.AddScoped<IMongoRepository<Response>>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<MongoServicePoptions>>().Value;
                return new MongoRepository<Response>(options.MongoDatabase, options.CollectionName, options.Response);
            });

            // pdf data
            services.AddScoped<IMongoRepository<Pdf>>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<MongoServicePoptions>>().Value;
                return new MongoRepository<Pdf>(options.MongoDatabase, options.CollectionName, options.Pdf);
            });
            // user data
            services.AddScoped<IMongoRepository<User>>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<MongoServicePoptions>>().Value;
                return new MongoRepository<User>(options.MongoDatabase, options.CollectionName, options.User);
            });
            //responseBody data
            services.AddScoped<IMongoRepository<ResponseBodyEntity>>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<MongoServicePoptions>>().Value;
                return new MongoRepository<ResponseBodyEntity>(options.MongoDatabase, options.CollectionName, options.ResponseBody);
            });

            services.AddScoped<IPdfService, PdfService>();
        }

        public static void AddJWTAuthentication(this WebApplicationBuilder? builder)
        {
            builder.Services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                        System.Text.Encoding.UTF8
                        .GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"])
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                };
            });
        }
    }
}
