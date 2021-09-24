using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiDatabase.Repository.Interfaces
{
    /// <summary>
    /// Common Lookup tables Repository Interface
    /// Read
    /// </summary>
    /// <typeparam name="TEntityType">The type of the entity type.</typeparam>
    /// <typeparam name="TKeyType">The type of the key type.</typeparam>
    public interface ILookupRepository<TEntityType, in TKeyType> where TKeyType : struct
    {
        /// <summary>
        ///     Reads the specified record by the <paramref name="key" />.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The <typeparamref name="TEntityType" /> Record.</returns>
        TEntityType GetEntityById(TKeyType key);

        /// <summary>
        ///     Gets all records.
        /// </summary>
        /// <returns>A collection of all <typeparamref name="TEntityType" /> records.</returns>
        IList<TEntityType> GetAll();

        /// <summary>
        /// Gets all records async
        /// </summary>
        /// <returns>A collection of all <typeparamref name="TEntityType" /> records.</returns>
        Task<IList<TEntityType>> GetAllAsync();

        /// <summary>
        ///     Gets a queryable collection of records based on the
        ///     <param name="filter" />
        ///     provided.
        /// </summary>
        /// <returns>A filtered collection of <typeparamref name="TEntityType" /> records.</returns>
        IQueryable<TEntityType> Query(Expression<Func<TEntityType, bool>> filter);

        /// <summary>
        ///     Returns a query object.
        /// </summary>
        /// <returns>IQueryable<TEntityType /></returns>
        IQueryable<TEntityType> GetAsQueryable();
    }
}