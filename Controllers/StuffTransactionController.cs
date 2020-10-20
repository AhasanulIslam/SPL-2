using System.Threading.Tasks;
using JWTApi.Data;
using JWTApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTApi.Controllers
{
     [ApiController]
    [Route("[controller]")]

    public class StuffTransactionController : ControllerBase
    {
        
        private readonly DataContext _context;
        public StuffTransactionController(DataContext context)
        {
            _context = context;
            

        }

        [AllowAnonymous]
        [HttpGet("{new}/{id}")]
        public async Task<IActionResult> GetTransactionsn(int id)
        {
              var transaction = await _context.Transactions.
             FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

            return Ok(transaction);

        }

         [AllowAnonymous]
        [HttpGet("{staff}/{all}/{div}/{id}")]
        public async Task<IActionResult> GetStaffs(int id)
        {
              var staffs = await _context.Staff.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT Username,Phone from Staffs where StaffId={0}",id).ToListAsync();

            return Ok(staffs);

        }
[AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostTransactionsn([FromBody]Transaction transaction)
        {
              var transactions = await _context.Transactions.
             FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            _context.SaveChanges();
            return Ok(transaction);
        }

    }
}