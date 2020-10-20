using System.Threading.Tasks;
using JWTApi.Data;
using JWTApi.Dtos;
using JWTApi.Helpers;
using JWTApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserservice _userService;
        // private readonly IMapper _mapper;
         private readonly DataContext _context;

        public UsersController(IUserservice userService,DataContext context) 
        {
            _userService = userService;
            _context = context;

        }
        
       
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if(user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            string access_Level = user.Access_Level;

            return Ok(user);

        }

        [AllowAnonymous]
        [HttpPost("{register}/{Stu}")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _userService.UserExist(userForRegisterDto.Username))
                ModelState.AddModelError("Username", "Username already exist");


            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var userToCreate = new Staff
            {
                Username = userForRegisterDto.Username,
                Email = userForRegisterDto.Email,
                Phone = userForRegisterDto.Phone,
                Access_Level = userForRegisterDto.Access
            };

            var createUser = await _userService.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
        

        //[HttpGet]
        // public IActionResult GetAll()
        // {
        //     var users = _userService.GetAll();
        //     return Ok(users);
        // }
    }
}