using System;
using System.Linq;
using MultiDatabase.DbOneRepository.Model;
using MultiDatabase.Repository.Interfaces;

namespace MultiDatabase.DbOneRepository.Interfaces
{
    public interface IDbOneTableTwoLookupRepository : ILookupRepository<DbOneTableTwoLookup, short>, IDisposable
    {
        new IQueryable<DbOneTableTwoLookup> GetAsQueryable();
    }
}