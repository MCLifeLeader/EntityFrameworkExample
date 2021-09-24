using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MultiDatabase.DbTwoRepository.Interfaces;
using MultiDatabase.DbTwoRepository.Model;
using MultiDatabase.Repository.Interfaces;

namespace MultiDatabase.DbTwoRepository
{
    public class DbTwoTableTwoLookupRepository : DbTwoBaseRepository, IDbTwoTableTwoLookupRepository
    {
        public DbTwoTableTwoLookupRepository(IDbTwoUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DbTwoTableTwoLookup GetEntityById(short key)
        {
            throw new NotImplementedException();
        }

        public IList<DbTwoTableTwoLookup> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<DbTwoTableTwoLookup>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<DbTwoTableTwoLookup> Query(Expression<Func<DbTwoTableTwoLookup, bool>> filter)
        {
            throw new NotImplementedException();
        }

        IQueryable<DbTwoTableTwoLookup> Interfaces.IDbTwoTableTwoLookupRepository.GetAsQueryable()
        {
            throw new NotImplementedException();
        }

        IQueryable<DbTwoTableTwoLookup> ILookupRepository<DbTwoTableTwoLookup, short>.GetAsQueryable()
        {
            throw new NotImplementedException();
        }
    }
}