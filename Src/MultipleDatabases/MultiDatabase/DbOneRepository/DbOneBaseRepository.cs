using MultiDatabase.DbOneRepository.Interfaces;
using MultiDatabase.Repository;

namespace MultiDatabase.DbOneRepository
{
   public abstract class DbOneBaseRepository : RepositoryBase<DbOneContext>
   {
      protected DbOneBaseRepository(IDbOneUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }
   }
}