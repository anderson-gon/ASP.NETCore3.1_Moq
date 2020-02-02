namespace Moq.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
