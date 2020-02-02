using Moq.Domain.Interfaces.Repositories;

namespace Moq.Tests.UserSpec.Fakes
{
    public class UnitOfWorkFake : IUnitOfWork
    {
        public bool Commit()
        {
            return true;
        }
    }
}
