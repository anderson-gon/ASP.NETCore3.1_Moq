using Microsoft.Extensions.DependencyInjection;
using Moq.Application.Interfaces;
using Moq.Application.Services;
using Moq.Domain.Interfaces.Repositories;
using Moq.Tests.UserSpec.Fakes;

namespace Moq.Tests.UserSpec.IoC
{
    public class FakeServiceInjectorContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<IUserRepository, UserRepositoryFake>();           
            services.AddScoped<IUnitOfWork, UnitOfWorkFake>();

            // Application
            services.AddScoped<IUserAppService, UserAppService>();
        }
    }
}
