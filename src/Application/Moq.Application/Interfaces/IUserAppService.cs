using Moq.Application.Contracts.V1;
using Moq.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moq.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<User> AddUserAsync(UserDTO user);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
