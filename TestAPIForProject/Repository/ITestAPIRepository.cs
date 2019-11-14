using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPIForProject.Models;

namespace TestAPIForProject.Repository
{
    public interface ITestAPIRepository
    {
        Task<List<Test2>> GetTest2s();
        Task<TestTable> GetTestTable(int id);
        Task<List<TestTable>> GetTestTables();
    }
}