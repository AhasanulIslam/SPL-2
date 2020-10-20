using System.Threading.Tasks;
using JWTApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTApi.Controllers
{
     [ApiController]
    [Route("[controller]")]
    public class StuffProductController : ControllerBase
    {
        private readonly DataContext _context;
        public StuffProductController(DataContext context)
        {
            _context = context;
            

        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoris(int id)
        {
              var inventory = await _context.Inventory.
            // FromSqlRaw("SELECT * from Invertories where InventoryId={0}",id).ToListAsync();
            FromSqlRaw("SELECT Status,Date from Invertories").ToListAsync();

            return Ok(inventory);

// where InventoryId={0}",id


        }

         [AllowAnonymous]
        [HttpGet("{product}/{id}")]
        public async Task<IActionResult> GetProductes(int id)
        {
              var product = await _context.Products.
             FromSqlRaw("SELECT * from Products where ProductId={0}",id).ToListAsync();
            // FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

            return Ok(product);

        }

        
         [AllowAnonymous]
        [HttpGet("{Room}/{new}/{id}")]
        public async Task<IActionResult> GetRoomes(int id)
        {
              var room = await _context.Rooms.
             FromSqlRaw("SELECT * from Rooms where Room_Id={0}",id).ToListAsync();
            // FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

            return Ok(room);

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetStaffs(int id)
        {
            var staffs = await _context.Staffs.
             FromSqlRaw("SELECT * from Staffs").ToListAsync();
            // FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

            return Ok(staffs);

        }

         [AllowAnonymous]
        [HttpGet("{usertype}/{dif}/{all}/{id}")]
        public async Task<IActionResult> GetUsertypies(int id)
        {
              var usertype = await _context.Usertypes.
             FromSqlRaw("SELECT * from Usertypes where UserId={0}",id).ToListAsync();
            //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

            return Ok(usertype);

        }

    }
}