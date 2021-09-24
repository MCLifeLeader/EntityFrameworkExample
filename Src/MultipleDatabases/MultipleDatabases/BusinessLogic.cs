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

        public BusinessLogic(string sqlConnOne, string sqlConnTwo)
        {
            UnitOfWorkDbOne ??= new DbOneContext(sqlConnOne);
            UnitOfWorkDbTwo ??= new DbTwoContext(sqlConnTwo);

            DbOneTableOneRepository ??= new DbOneTableOneRepository(UnitOfWorkDbOne);
            DbTwoTableOneRepository ??= new DbTwoTableOneRepository(UnitOfWorkDbTwo);
        }

        public void ReadDbOne()
        {
            Console.WriteLine("Database One Table One data:");

            try
            {
                IList<DbOneTableOne> tableData = DbOneTableOneRepository.GetAll();
                if (tableData != null)
                {
                    foreach (var item in tableData)
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
                    foreach (var item in tableData)
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
    }
}
