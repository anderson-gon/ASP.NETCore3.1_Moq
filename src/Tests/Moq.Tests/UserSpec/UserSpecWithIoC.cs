using Microsoft.Extensions.DependencyInjection;
using Moq.Application.Contracts.V1;
using Moq.Application.Interfaces;
using Moq.Domain.Interfaces.Repositories;
using Moq.Tests.UserSpec.IoC;
using Xunit;
using System.Linq;

namespace Moq.Tests.UserSpec
{
    public class UserSpecWithIoC
    {
        
        private readonly IUserAppService _userAppService;        

        public UserSpecWithIoC()
        {
            var services = new ServiceCollection();

            FakeServiceInjectorContainer.RegisterServices(services);

            var serviceProvider = services.BuildServiceProvider();

            _userAppService = serviceProvider.GetService<IUserAppService>();            
        }

        [Fact]
        public async void Add_User_Valid()
        {
            UserDTO userDTO = new UserDTO()
            {
                FirstName = "Someone",
                LastName = "Else"
            };

            var user = await _userAppService.AddUserAsync(userDTO);
            Assert.True(user.ValidationResult.IsValid);

        }

        [Fact]
        public async void Get_List_Users()
        {
            var users = await _userAppService.GetUsersAsync();
            Assert.Equal(3, users.Count());
        }
    }
}
