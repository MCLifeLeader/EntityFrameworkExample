using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return _context.TwoTableTwoLookup.SingleOrDefault(e => e.Id == key);
        }

        public async Task<DbTwoTableTwoLookup> GetEntityByIdAsync(short key)
        {
            return await _context.TwoTableTwoLookup.SingleOrDefaultAsync(e => e.Id == key);
        }

        public IList<DbTwoTableTwoLookup> GetAll()
        {
            return _context.TwoTableTwoLookup.ToList();
        }

        public async Task<IList<DbTwoTableTwoLookup>> GetAllAsync()
        {
            return await _context.TwoTableTwoLookup.ToListAsync();
        }

        public IQueryable<DbTwoTableTwoLookup> Query(Expression<Func<DbTwoTableTwoLookup, bool>> filter)
        {
            return _context.TwoTableTwoLookup.Where(filter);
        }

        IQueryable<DbTwoTableTwoLookup> IDbTwoTableTwoLookupRepository.GetAsQueryable()
        {
            return _context.TwoTableTwoLookup.AsQueryable();
        }

        IQueryable<DbTwoTableTwoLookup> ILookupRepository<DbTwoTableTwoLookup, short>.GetAsQueryable()
        {
            return _context.TwoTableTwoLookup.AsQueryable();
        }
    }
}