using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiDatabase.DbTwoRepository.Model;
using MultiDatabase.Repository.Interfaces;

namespace MultiDatabase.DbTwoRepository.Interfaces
{
    public interface IDbTwoTableOneRepository : IRepository<DbTwoTableOne, int>, IDisposable
    {
        new IQueryable<DbTwoTableOne> GetAsQueryable();

        IList<DbTwoTableOne> GetEntityByMessageSearch(string message);
        Task<IList<DbTwoTableOne>> GetEntityByMessageSearchAsync(string message);

        IList<DbTwoTableOne> GetEntityByDateRange(DateTime startDate, DateTime endDate);
        Task<IList<DbTwoTableOne>> GetEntityByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}