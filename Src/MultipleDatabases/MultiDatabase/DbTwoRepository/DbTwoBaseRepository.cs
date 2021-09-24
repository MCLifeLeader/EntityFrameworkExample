using MultiDatabase.DbTwoRepository.Interfaces;
using MultiDatabase.Repository;

namespace MultiDatabase.DbTwoRepository
{
    public abstract class DbTwoBaseRepository : RepositoryBase<DbTwoContext>
    {
        protected DbTwoBaseRepository(IDbTwoUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}