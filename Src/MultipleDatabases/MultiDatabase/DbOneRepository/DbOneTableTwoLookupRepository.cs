using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return _context.OneTableTwoLookUp.SingleOrDefault(e => e.Id == key);
        }

        public async Task<DbOneTableTwoLookup> GetEntityByIdAsync(short key)
        {
            return await _context.OneTableTwoLookUp.SingleOrDefaultAsync(e => e.Id == key);
        }

        public IList<DbOneTableTwoLookup> GetAll()
        {
            return _context.OneTableTwoLookUp.ToList();
        }

        public async Task<IList<DbOneTableTwoLookup>> GetAllAsync()
        {
            return await _context.OneTableTwoLookUp.ToListAsync();
        }

        public IQueryable<DbOneTableTwoLookup> Query(Expression<Func<DbOneTableTwoLookup, bool>> filter)
        {
            return _context.OneTableTwoLookUp.Where(filter);
        }

        IQueryable<DbOneTableTwoLookup> IDbOneTableTwoLookupRepository.GetAsQueryable()
        {
            return _context.OneTableTwoLookUp.AsQueryable();
        }

        IQueryable<DbOneTableTwoLookup> ILookupRepository<DbOneTableTwoLookup, short>.GetAsQueryable()
        {
            return _context.OneTableTwoLookUp.AsQueryable();
        }
    }
}