using Autofac;
using Email_Campain_Service.Core.Contexts;
using Email_Campain_Service.Core.Repositories;
using Email_Campain_Service.Core.Services;
using Email_Campain_Service.Core.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core
{
    public class CoreModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public CoreModule(IConfiguration configuration, string connectionStringName, string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(connectionStringName);
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CampaignDbContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<CampaignDbContext>().As<CampaignDbContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<CampignUnitOfWork>().As<ICampignUnitOfWork>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>()
              .InstancePerLifetimeScope();
            builder.RegisterType<EventRepository>().As<IEventRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EventService>().As<EventService>()
              .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
