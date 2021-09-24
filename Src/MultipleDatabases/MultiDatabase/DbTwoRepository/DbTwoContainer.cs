using Microsoft.EntityFrameworkCore;
using MultiDatabase.DbTwoRepository.Model;

namespace MultiDatabase.DbTwoRepository
{
    public class DbTwoContainer : DbContext
    {
        public DbTwoContainer(DbContextOptions dbContextOptions)
           : base(dbContextOptions)
        { }

        public DbTwoContainer(DbContextOptions<DbTwoContainer> dbContextOptions)
           : base(dbContextOptions)
        { }

        public virtual DbSet<DbTwoTableOne> TwoTableOne { get; set; }
        public virtual DbSet<DbTwoTableTwoLookup> TwoTableTwoLookup { get; set; }
    }
}