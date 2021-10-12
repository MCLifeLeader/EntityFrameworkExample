using System;
using System.Collections.Generic;
using MultiDatabase.DbOneRepository;
using MultiDatabase.DbOneRepository.Interfaces;
using MultiDatabase.DbOneRepository.Model;
using MultiDatabase.DbOneRepository.Model.Enum;
using MultiDatabase.DbTwoRepository;
using MultiDatabase.DbTwoRepository.Interfaces;
using MultiDatabase.DbTwoRepository.Model;
using MultiDatabase.DbTwoRepository.Model.Enum;
// ReSharper disable InconsistentNaming
// ReSharper disable ConstantNullCoalescingCondition

namespace MultipleDatabases
{
    // ReSharper disable once InconsistentNaming
    public class BusinessLogic
    {
        protected IDbOneUnitOfWork UnitOfWorkDbOne;
        protected IDbTwoUnitOfWork UnitOfWorkDbTwo;

        protected IDbOneTableOneRepository DbOneTableOneRepository;
        protected IDbTwoTableOneRepository DbTwoTableOneRepository;

        protected IDbOneTableTwoLookupRepository DbOneTableTwoLookupRepository;
        protected IDbTwoTableTwoLookupRepository DbTwoTableTwoLookupRepository;

        public BusinessLogic(string sqlConnOne, string sqlConnTwo)
        {
            UnitOfWorkDbOne ??= new DbOneContext(sqlConnOne);
            UnitOfWorkDbTwo ??= new DbTwoContext(sqlConnTwo);

            DbOneTableOneRepository ??= new DbOneTableOneRepository(UnitOfWorkDbOne);
            DbTwoTableOneRepository ??= new DbTwoTableOneRepository(UnitOfWorkDbTwo);

            DbOneTableTwoLookupRepository ??= new DbOneTableTwoLookupRepository(UnitOfWorkDbOne);
            DbTwoTableTwoLookupRepository ??= new DbTwoTableTwoLookupRepository(UnitOfWorkDbTwo);
        }

        public void ReadDbOne()
        {
            Console.WriteLine("Database One Table One data:");

            try
            {
                IList<DbOneTableOne> tableData = DbOneTableOneRepository.GetAll();
                if (tableData != null)
                {
                    foreach (DbOneTableOne item in tableData)
                    {
                        Console.WriteLine(item.Data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ReadDbTwo()
        {
            Console.WriteLine("Database Two Table One data:");

            try
            {
                IList<DbTwoTableOne> tableData = DbTwoTableOneRepository.GetAll();
                if (tableData != null)
                {
                    foreach (DbTwoTableOne item in tableData)
                    {
                        Console.WriteLine(item.Data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void WriteDbOne(string dbInput)
        {
            DbOneTableOne newData = new()
            {
                Data = dbInput,
                DateCreated = DateTime.UtcNow,
                DbOneTableTwoLookupId = (short)DbOneTableTwoLookups.Step
            };

            try
            {
                DbOneTableOneRepository.Add(newData);
                UnitOfWorkDbOne.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void WriteDbTwo(string dbInput)
        {
            DbTwoTableOne newData = new()
            {
                Data = dbInput,
                DateCreated = DateTime.UtcNow,
                DbTwoTableTwoLookupId = (short)DbTwoTableTwoLookups.Step
            };

            try
            {
                DbTwoTableOneRepository.Add(newData);
                UnitOfWorkDbTwo.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ReadDbOneLookups()
        {
            Console.WriteLine("Database One Table Two data:");

            try
            {
                IList<DbOneTableTwoLookup> tableData = DbOneTableTwoLookupRepository.GetAll();
                if (tableData != null)
                {
                    foreach (DbOneTableTwoLookup item in tableData)
                    {
                        Console.WriteLine($"Id={item.Id} | Description={item.Description}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ReadDbTwoLookups()
        {
            Console.WriteLine("Database Two Table Two data:");

            try
            {
                IList<DbTwoTableTwoLookup> tableData = DbTwoTableTwoLookupRepository.GetAll();
                if (tableData != null)
                {
                    foreach (DbTwoTableTwoLookup item in tableData)
                    {
                        Console.WriteLine($"Id={item.Id} | Description={item.Description}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
