using System;

namespace Moq.Domain.Models
{
    public class User : Entity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName() => $"{this.FirstName} {this.LastName}";

        public User(Guid Id, string FirstName, string LastName)
        {
            this.Id = Id == Guid.Empty ? Guid.NewGuid() : Id;
            this.FirstName = FirstName;
            this.LastName = LastName;

            Validate(this, new UserValidator());
        }
    }
}
