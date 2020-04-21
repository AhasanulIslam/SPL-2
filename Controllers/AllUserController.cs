using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace JWTApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AllUserController : Controller
    {

        private IUserService _userService;

        public AllUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}