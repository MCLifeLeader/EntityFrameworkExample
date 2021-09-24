using System.Collections.Generic;
using System.Linq;

namespace MultiDatabase.Repository.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntityType">The type of the entity type.</typeparam>
    /// <typeparam name="TKeyType">The type of the key type.</typeparam>
    public interface ILookupNonStructRepository<TEntityType, in TKeyType>
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
        ///     Returns a query object.
        /// </summary>
        /// <returns>IQueryable<TEntityType /></returns>
        IQueryable<TEntityType> GetAsQueryable();
    }
}