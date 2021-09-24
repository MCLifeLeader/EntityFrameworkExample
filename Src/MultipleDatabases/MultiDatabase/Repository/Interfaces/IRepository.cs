using System.Threading.Tasks;

namespace MultiDatabase.Repository.Interfaces
{
    /// <summary>
    /// Common Repository Interface
    /// Add, Delete, Update
    /// </summary>
    /// <typeparam name="TEntityType">The type of the entity type.</typeparam>
    /// <typeparam name="TKeyType">The type of the key type.</typeparam>
    public interface IRepository<TEntityType, in TKeyType> : ILookupRepository<TEntityType, TKeyType> where TKeyType : struct
    {
        /// <summary>
        ///     Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntityType entity);

        /// <summary>
        ///     Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task AddAsync(TEntityType entity);

        /// <summary>
        ///     Deletes the specified key.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntityType entity);

        /// <summary>
        ///     Addors the update.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntityType entity);
    }
}