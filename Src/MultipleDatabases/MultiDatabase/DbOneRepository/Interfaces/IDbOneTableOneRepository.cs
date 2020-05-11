using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiDatabase.DbOneRepository.Model;
using MultiDatabase.Repository.Interfaces;

namespace MultiDatabase.DbOneRepository.Interfaces
{
   public interface IDbOneTableOneRepository : IRepository<DbOneTableOne, int>, IDisposable
   {
      new IQueryable<DbOneTableOne> GetAsQueryable();

      IList<DbOneTableOne> GetEntityByMessageSearch(string message);
      Task<IList<DbOneTableOne>> GetEntityByMessageSearchAsync(string message);

      IList<DbOneTableOne> GetEntityByDateRange(DateTime startDate, DateTime endDate);
      Task<IList<DbOneTableOne>> GetEntityByDateRangeAsync(DateTime startDate, DateTime endDate);
   }
}