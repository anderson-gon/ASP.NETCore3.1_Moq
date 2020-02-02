using Moq.Application.Contracts.V1;
using Moq.Application.Services;
using Moq.Domain.Exceptions;
using Moq.Domain.Interfaces.Repositories;
using Xunit;

namespace Moq.Tests.UserSpec
{
    public class UserSpecWithMoq
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly UserAppService _userAppService;

        public UserSpecWithMoq() 
        {
            _userRepository = new Mock<IUserRepository>();
            _uow = new Mock<IUnitOfWork>();
            _userAppService = new UserAppService(_userRepository.Object, _uow.Object);
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
        public async void Add_User_InValid()
        {
            UserDTO userDTO = new UserDTO()
            {
                LastName = "Else"
            };

            
            await Assert.ThrowsAsync<InvalidEntityStateException>(async () => {
                var user = await _userAppService.AddUserAsync(userDTO);
            });
        }
    }
}
