using Microsoft.Extensions.DependencyInjection;
using Moq.Application.Interfaces;
using Moq.Application.Services;
using Moq.Domain.Interfaces.Repositories;
using Moq.Infra.Data;
using Moq.Infra.Repository;
using Moq.Infra.UnitOfWork;
using Moq.Tests.UserSpec.Fakes;

namespace Moq.IoC
{
    public class ServiceInjectorContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<DataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Application
            services.AddScoped<IUserAppService, UserAppService>();
        }     
    }
}
