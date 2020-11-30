using CompanyEmployees.Mediator;
using CompanyEmployess.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Core
{
    public class AppInstaller
    {
        private IConfiguration configuration;

        public AppInstaller(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Install(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<CompanyContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("CompanyContext")));

            services.AddTransient<IMediator, Mediator.Mediator>();

            services.Scan(scan => scan
                .FromApplicationDependencies()
                    .AddClasses(classes => classes
                        .InNamespaces("CompanyEmployess.Infrastructure.Repositories")
                        .Where(type => type.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            services.Scan(scan => scan
                .FromApplicationDependencies()
                    .AddClasses(classes => classes
                        .InNamespaces("CompanyEmployess.Infrastructure.Factories")
                        .Where(type => type.Name.EndsWith("Factory")))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            services.Scan(scan => scan
                .FromApplicationDependencies()
                    .AddClasses(classes => classes
                        .InNamespaces("CompanyEmployees.Dtos")
                        .Where(type => type.Name.EndsWith("DtoBuilder")))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            services.Scan(scan => scan
                .FromApplicationDependencies()
                    .AddClasses(classes => classes
                        .InNamespaces("CompanyEmployees.Handlers")
                        .Where(type => type.Name.EndsWith("Handler")))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
        }
    }
}
