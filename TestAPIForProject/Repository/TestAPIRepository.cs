using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPIForProject.Models;

namespace TestAPIForProject.Repository
{
    public class TestAPIRepository : ITestAPIRepository
    {
        TestAPIForProject20191024081403_dbContext db;

        public TestAPIRepository(TestAPIForProject20191024081403_dbContext _db)
        {
            db = _db;
        }

        public async Task<List<TestTable>> GetTestTables()
        {
            if (db != null)
                return await db.TestTable.ToListAsync();
            return null;
        }

        public async Task<List<Test2>> GetTest2s()
        {
            if (db != null)
                return await db.Test2.ToListAsync();
            return null;
        }

        public async Task<TestTable> GetTestTable(int id)
        {
            if (db != null)
            {
                return await (from p in db.TestTable
                              where p.Id == id
                              select new TestTable
                              {
                                  Id = p.Id,
                                  Fname = p.Fname,
                                  Lname = p.Lname
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
    }
}
