﻿using System;
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
            return _context.TwoTableOne.FirstOrDefault(e => e.Id == key);
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
            return _context.TwoTableOne.Where(e => e.DateCreated >= startDate && e.DateCreated <= endDate).ToList();
        }

        public async Task<IList<DbTwoTableOne>> GetEntityByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.TwoTableOne.Where(e => e.DateCreated >= startDate && e.DateCreated <= endDate).ToListAsync();
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
