using Moq.Domain.Interfaces.Repositories;
using Moq.Domain.Models;
using Moq.Infra.Data;
using System;

namespace Moq.Infra.Repository
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }
    }
}
