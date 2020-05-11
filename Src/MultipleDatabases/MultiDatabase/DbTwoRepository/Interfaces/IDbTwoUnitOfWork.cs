using MultiDatabase.Repository.Interfaces;

namespace MultiDatabase.DbTwoRepository.Interfaces
{
   /// <summary>
   /// Base interface context used to bind all of the database repositories into a unit of work
   /// </summary>
   public interface IDbTwoUnitOfWork : IUnitOfWork
   {
   }
}
