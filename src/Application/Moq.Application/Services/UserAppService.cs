using Moq.Application.Contracts.V1;
using Moq.Application.Interfaces;
using Moq.Domain.Exceptions;
using Moq.Domain.Interfaces.Repositories;
using Moq.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moq.Application.Services
{
    public class UserAppService : IUserAppService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;

        public UserAppService(IUserRepository userRepository,
                              IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        public Task<User> AddUserAsync(UserDTO userDTO)
        {
            return Task.Run(() =>
            {
                User user = new User(new Guid(), userDTO.FirstName, userDTO.LastName);
                if (!user.ValidationResult.IsValid)
                {
                    throw new InvalidEntityStateException(user.ValidationResult.ToString());
                }
                _userRepository.Add(user);
                _uow.Commit();
                return user;
            });
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            return Task.Run(() =>
            {                
                return _userRepository.GetAll();                                
            });
        }
    }
}
