using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MultiDatabase.DbOneRepository.Interfaces;
using MultiDatabase.DbOneRepository.Model;
using MultiDatabase.Repository.Interfaces;

namespace MultiDatabase.DbOneRepository
{
   public class DbOneTableTwoLookupRepository : DbOneBaseRepository, IDbOneTableTwoLookupRepository
   {
      public DbOneTableTwoLookupRepository(IDbOneUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }

      public DbOneTableTwoLookup GetEntityById(short key)
      {
         throw new NotImplementedException();
      }

      public IList<DbOneTableTwoLookup> GetAll()
      {
         throw new NotImplementedException();
      }

      public Task<IList<DbOneTableTwoLookup>> GetAllAsync()
      {
         throw new NotImplementedException();
      }

      public IQueryable<DbOneTableTwoLookup> Query(Expression<Func<DbOneTableTwoLookup, bool>> filter)
      {
         throw new NotImplementedException();
      }

      IQueryable<DbOneTableTwoLookup> Interfaces.IDbOneTableTwoLookupRepository.GetAsQueryable()
      {
         throw new NotImplementedException();
      }

      IQueryable<DbOneTableTwoLookup> ILookupRepository<DbOneTableTwoLookup, short>.GetAsQueryable()
      {
         throw new NotImplementedException();
      }
   }
}