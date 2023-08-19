using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterAPI.Models;

namespace RegisterAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IConfiguration _config;
		public readonly UserContext _context;
        public UserController(IConfiguration config, UserContext context)
        {
            _config = config;
			_context = context;
        }

		[HttpPost]
		public IActionResult Create(User user)
		{
			if(_context.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null) 
			{
				return Ok("User Already Exists");
			}
			user.CreatedOn = DateTime.Now;
			_context.Users.Add(user);
			_context.SaveChanges();
			return Ok("Create Method Running");
		}
    }
}
