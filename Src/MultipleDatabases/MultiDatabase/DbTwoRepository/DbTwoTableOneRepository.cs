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
    public class DbTwoTableOneRepository : DbTwoBaseRepository, IDbTwoTableOneRepository
    {
        public DbTwoTableOneRepository(IDbTwoUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DbTwoTableOne GetEntityById(int key)
        {
            return _context.TwoTableOne.SingleOrDefault(e => e.Id == key);
        }

        public async Task<DbTwoTableOne> GetEntityByIdAsync(int key)
        {
            return await _context.TwoTableOne.SingleOrDefaultAsync(e => e.Id == key);
        }

        public IList<DbTwoTableOne> GetAll()
        {
            return _context.TwoTableOne.ToList();
        }

        public async Task<IList<DbTwoTableOne>> GetAllAsync()
        {
            return await _context.TwoTableOne.ToListAsync();
        }

        public IQueryable<DbTwoTableOne> Query(Expression<Func<DbTwoTableOne, bool>> filter)
        {
            return _context.TwoTableOne.Where(filter);
        }

        IQueryable<DbTwoTableOne> IDbTwoTableOneRepository.GetAsQueryable()
        {
            return _context.TwoTableOne.AsQueryable();
        }

        public IList<DbTwoTableOne> GetEntityByMessageSearch(string message)
        {
            return _context.TwoTableOne.Where(e => e.Data.Contains(message)).ToList();
        }

        public async Task<IList<DbTwoTableOne>> GetEntityByMessageSearchAsync(string message)
        {
            return await _context.TwoTableOne.Where(e => e.Data.Contains(message)).ToListAsync();
        }

        public IList<DbTwoTableOne> GetEntityByDateRange(DateTime startDate, DateTime endDate)
        {
            // LINQ to SQL example
            IQueryable<DbTwoTableOne> query =
                from table in _context.TwoTableOne
                where table.DateCreated >= startDate && table.DateCreated <= endDate
                orderby table.DateCreated descending
                select table;

            return query.ToList();
        }

        public async Task<IList<DbTwoTableOne>> GetEntityByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // LINQ to SQL example
            IQueryable<DbTwoTableOne> query =
                from table in _context.TwoTableOne
                where table.DateCreated >= startDate && table.DateCreated <= endDate
                orderby table.DateCreated descending
                select table;

            return await query.ToListAsync();
        }

        IQueryable<DbTwoTableOne> ILookupRepository<DbTwoTableOne, int>.GetAsQueryable()
        {
            return _context.TwoTableOne.AsQueryable();
        }

        public void Add(DbTwoTableOne entity)
        {
            _context.Add(entity);
        }

        public async Task AddAsync(DbTwoTableOne entity)
        {
            await _context.AddAsync(entity);
        }

        public void AddRange(IEnumerable<DbTwoTableOne> entities)
        {
            _context.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<DbTwoTableOne> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public void Delete(DbTwoTableOne entity)
        {
            _context.Remove(entity);
        }

        public void Update(DbTwoTableOne entity)
        {
            _context.Update(entity);
        }
    }
}
