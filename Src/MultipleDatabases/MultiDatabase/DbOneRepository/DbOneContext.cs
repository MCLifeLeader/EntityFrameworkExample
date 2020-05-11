using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MultiDatabase.DbOneRepository.Interfaces;

namespace MultiDatabase.DbOneRepository
{
   public class DbOneContext : DbOneContainer, IDbOneUnitOfWork
   {
      public DbOneContext(DbContextOptions dbContextOptions)
         : base(dbContextOptions)
      { }

      public DbOneContext(DbContextOptions<DbOneContainer> dbContextOptions)
         : base(dbContextOptions)
      { }

      public DbOneContext(string connectionString)
         : base(GetOptions(connectionString))
      { }

      #region Public Methods
      public override int SaveChanges()
      {
         IEnumerable<object> entities = from e in ChangeTracker.Entries()
                                        where e.State == EntityState.Added
                                              || e.State == EntityState.Modified
                                        select e.Entity;

         foreach (object entity in entities)
         {
            ValidationContext validationContext = new ValidationContext(entity);
            Validator.ValidateObject(entity, validationContext);
         }

         return base.SaveChanges();
      }

      /// <summary>
      /// Saves this instance.
      /// </summary>
      public void Save()
      {
         //_logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         try
         {
            SaveChanges();
         }
         catch (Exception ex)
         {
            //_logger.Fatal(ex.Message, ex);

            throw;
         }
      }

      /// <summary>
      /// Reloads the specified entity.
      /// </summary>
      /// <typeparam name="TEntity">The type of the entity.</typeparam>
      /// <param name="entity">The entity.</param>
      public void Reload<TEntity>(TEntity entity) where TEntity : class
      {
         //_logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         try
         {
            Entry(entity).Reload();
         }
         catch (Exception ex)
         {
            //_logger.Debug(ex);
         }
      }

      /// <summary>
      /// Clears the state.
      /// </summary>
      /// <typeparam name="TEntity">The type of the entity.</typeparam>
      /// <param name="entity">The entity.</param>
      public void ClearState<TEntity>(TEntity entity) where TEntity : class
      {
         //_logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         try
         {
            Entry(entity).CurrentValues.SetValues(Entry(entity).OriginalValues);
         }
         catch (Exception ex)
         {
            //_logger.Debug(ex);
         }

         try
         {
            Entry(entity).Reload();
         }
         catch (Exception ex)
         {
            //_logger.Debug(ex);
         }

         try
         {
            Entry(entity).State = EntityState.Unchanged;
         }
         catch (Exception ex)
         {
            //_logger.Debug(ex);
         }
      }

      /// <summary>
      /// Sets the database context configuration automatic detect changes.
      /// </summary>
      /// <param name="setAutoDetect">if set to <c>true</c> [set automatic detect].</param>
      public void SetDbContextConfigurationAutoDetectChanges(bool setAutoDetect)
      {
         //_logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         ChangeTracker.AutoDetectChangesEnabled = setAutoDetect;
      }
      #endregion

      #region Private Methods
      private static DbContextOptions GetOptions(string connectionString)
      {
         // ReSharper disable once InvokeAsExtensionMethod
         return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
      }
      #endregion

   }
}