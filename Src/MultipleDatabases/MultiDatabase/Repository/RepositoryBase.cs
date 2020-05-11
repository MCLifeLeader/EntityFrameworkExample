using System;
using MultiDatabase.Repository.Interfaces;

namespace MultiDatabase.Repository
{
   /// <summary>
   /// Base abstract class used as a foundation for all of the other repository classes
   /// </summary>
   public abstract class RepositoryBase<TDbContext> : IDisposable
   {
      // ReSharper disable once InconsistentNaming
      protected readonly TDbContext _context;

      /// <summary>
      /// Initializes a new instance of the <see cref="RepositoryBase" /> class.
      /// </summary>
      /// <param name="unitOfWork">The unit of work.</param>
      /// <exception cref="System.ArgumentNullException"></exception>
      /// <exception cref="System.InvalidCastException">Could not cast unitOfWork to MlmLinkupContext</exception>
      protected RepositoryBase(IUnitOfWork unitOfWork)
      {
         // ReSharper disable once JoinNullCheckWithUsage
         if (unitOfWork == null)
         {
            throw new ArgumentNullException(nameof(unitOfWork));
         }

         _context = (TDbContext) unitOfWork;

         if (_context == null)
         {
            throw new InvalidCastException("Could not cast unitOfWork to MlmLinkupContext");
         }
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      // NOTE: Leave out the finalizer altogether if this class doesn't   
      // own unmanaged resources itself, but leave the other methods  
      // exactly as they are.   
      ~RepositoryBase()
      {
         // Finalizer calls Dispose(false)  
         Dispose(false);
      }

      // The bulk of the clean-up code is implemented in Dispose(bool)  
      protected virtual void Dispose(bool disposing)
      {
         if (disposing)
         {
            //// free managed resources  
            //if( managedResource != null )
            //{
            //	managedResource.Dispose();
            //	managedResource = null;
            //}
         }

         // free native resources if there are any.  
         //if( nativeResource != IntPtr.Zero )
         //{
         //	Marshal.FreeHGlobal( nativeResource );
         //	nativeResource = IntPtr.Zero;
         //}
      }
   }
}
