using System;
using System.Collections.Generic;
using Moq.Domain.Interfaces.Repositories;
using Moq.Domain.Models;
using System.Linq;

namespace Moq.Tests.UserSpec.Fakes
{
    public class UserRepositoryFake : IUserRepository
    {
        private List<User> users;

        public UserRepositoryFake()
        {
            users = new List<User>()
            {
                new User(new Guid(), "User 1", "Last 1"),
                new User(new Guid(), "User 2", "Last 2"),
                new User(new Guid(), "User 3", "Last 3")
            };
        }

        public void Add(User entity)
        {
            users.Add(entity);
        }

        public void Dispose()
        {          
        }

        public User Get(Guid id)
        {
            return users
                    .Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public void Remove(User entity)
        {
            var user = Get(entity.Id);
            if (user != null)
                users.Remove(user);                           
        }

        public void Update(User entity)
        {
            Remove(entity);
            Add(entity);
        }
    }
}
