using Infra.Models;
using Infra.Repositories.Classes;
using Infra.Repositories.Interfaces;
using Infra.Services.Classes;
using Infra.Services.Interfaces;
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


            //responseBody data
            services.AddScoped<IMongoRepository<ResponseBodyEntity>>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<MongoServicePoptions>>().Value;
                return new MongoRepository<ResponseBodyEntity>(options.MongoDatabase, options.CollectionName, options.ResponseBody);
            });

            services.AddScoped<IPdfService, PdfService>();
        }
    }
}
