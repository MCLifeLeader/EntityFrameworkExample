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
    public class DbOneTableOneRepository : DbOneBaseRepository, IDbOneTableOneRepository
    {
        public DbOneTableOneRepository(IDbOneUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DbOneTableOne GetEntityById(int key)
        {
            return _context.OneTableOne.SingleOrDefault(e => e.Id == key);
        }

        public async Task<DbOneTableOne> GetEntityByIdAsync(int key)
        {
            return await _context.OneTableOne.SingleOrDefaultAsync(e => e.Id == key);
        }

        public IList<DbOneTableOne> GetAll()
        {
            return _context.OneTableOne.ToList();
        }

        public async Task<IList<DbOneTableOne>> GetAllAsync()
        {
            return await _context.OneTableOne.ToListAsync();
        }

        public IQueryable<DbOneTableOne> Query(Expression<Func<DbOneTableOne, bool>> filter)
        {
            return _context.OneTableOne.Where(filter);
        }

        public IQueryable<DbOneTableOne> GetAsQueryable()
        {
            return _context.OneTableOne.AsQueryable();
        }

        public IList<DbOneTableOne> GetEntityByMessageSearch(string message)
        {
            return _context.OneTableOne.Where(e => e.Data.Contains(message)).ToList();
        }

        public async Task<IList<DbOneTableOne>> GetEntityByMessageSearchAsync(string message)
        {
            return await _context.OneTableOne.Where(e => e.Data.Contains(message)).ToListAsync();
        }

        public IList<DbOneTableOne> GetEntityByDateRange(DateTime startDate, DateTime endDate)
        {
            // LINQ to SQL example
            IQueryable<DbOneTableOne> query =
                from table in _context.OneTableOne
                where table.DateCreated >= startDate && table.DateCreated <= endDate
                orderby table.DateCreated descending
                select table;

            return query.ToList();
        }

        public async Task<IList<DbOneTableOne>> GetEntityByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // LINQ to SQL example
            IQueryable<DbOneTableOne> query =
                from table in _context.OneTableOne
                where table.DateCreated >= startDate && table.DateCreated <= endDate
                orderby table.DateCreated descending
                select table;

            return await query.ToListAsync();
        }

        IQueryable<DbOneTableOne> ILookupRepository<DbOneTableOne, int>.GetAsQueryable()
        {
            return _context.OneTableOne.AsQueryable();
        }

        public void Add(DbOneTableOne entity)
        {
            _context.Add(entity);
        }

        public async Task AddAsync(DbOneTableOne entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(DbOneTableOne entity)
        {
            _context.Remove(entity);
        }

        public void Update(DbOneTableOne entity)
        {
            _context.Update(entity);
        }
    }
}
