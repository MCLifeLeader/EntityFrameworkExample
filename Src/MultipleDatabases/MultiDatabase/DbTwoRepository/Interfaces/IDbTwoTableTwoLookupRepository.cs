using System;
using System.Linq;
using MultiDatabase.DbTwoRepository.Model;
using MultiDatabase.Repository.Interfaces;

namespace MultiDatabase.DbTwoRepository.Interfaces
{
   public interface IDbTwoTableTwoLookupRepository : ILookupRepository<DbTwoTableTwoLookup, short>, IDisposable
   {
      new IQueryable<DbTwoTableTwoLookup> GetAsQueryable();
   }
}