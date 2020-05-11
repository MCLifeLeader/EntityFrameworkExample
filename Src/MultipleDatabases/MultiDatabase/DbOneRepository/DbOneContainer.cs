using Microsoft.EntityFrameworkCore;
using MultiDatabase.DbOneRepository.Model;

namespace MultiDatabase.DbOneRepository
{
   public class DbOneContainer : DbContext
   {
      public DbOneContainer(DbContextOptions dbContextOptions)
         : base(dbContextOptions)
      { }

      public DbOneContainer(DbContextOptions<DbOneContainer> dbContextOptions)
         : base(dbContextOptions)
      { }

      public virtual DbSet<DbOneTableOne> OneTableOne { get; set; }
      public virtual DbSet<DbOneTableTwoLookup> OneTableTwoLookUp { get; set; }
   }
}