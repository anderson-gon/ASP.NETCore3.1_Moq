using Moq.Domain.Models;
using System;

namespace Moq.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
