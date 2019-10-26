using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPIForProject.Models;

namespace TestAPIForProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTablesController : ControllerBase
    {
        private readonly TestAPIForProject20191024081403_dbContext _context;

        public TestTablesController(TestAPIForProject20191024081403_dbContext context)
        {
            _context = context;
        }

        // GET: api/TestTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestTable>>> GetTestTable()
        {
            return await _context.TestTable.ToListAsync();
        }

        // GET: api/TestTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestTable>> GetTestTable(int id)
        {
            var testTable = await _context.TestTable.FindAsync(id);

            if (testTable == null)
            {
                return NotFound();
            }

            return testTable;
        }

        // PUT: api/TestTables/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestTable(int id, TestTable testTable)
        {
            if (id != testTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(testTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TestTables
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TestTable>> PostTestTable(TestTable testTable)
        {
            _context.TestTable.Add(testTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TestTableExists(testTable.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTestTable", new { id = testTable.Id }, testTable);
        }

        // DELETE: api/TestTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestTable>> DeleteTestTable(int id)
        {
            var testTable = await _context.TestTable.FindAsync(id);
            if (testTable == null)
            {
                return NotFound();
            }

            _context.TestTable.Remove(testTable);
            await _context.SaveChangesAsync();

            return testTable;
        }

        private bool TestTableExists(int id)
        {
            return _context.TestTable.Any(e => e.Id == id);
        }
    }
}
