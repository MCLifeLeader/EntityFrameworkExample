using MultiDatabase.Repository.Interfaces;

namespace MultiDatabase.DbOneRepository.Interfaces
{
    /// <summary>
    /// Base interface context used to bind all of the database repositories into a unit of work
    /// </summary>
    public interface IDbOneUnitOfWork : IUnitOfWork
    {
    }
}
