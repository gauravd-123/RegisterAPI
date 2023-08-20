using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

		[HttpGet]
		public async Task<ActionResult<List<User>>> GetUser()
		{
			return Ok(await _context.Users.ToListAsync());

		}

		[HttpPost]
		public async Task<ActionResult<List<User>>> CreateUser(User user)
		{
			if (_context.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null)
			{
				return Ok("User Already Exists");
			}
			user.CreatedOn = DateTime.Now;
			_context.Users.Add(user);
			_context.SaveChanges();
			//return Ok(await _context.Users.ToListAsync());
			return Ok(await _context.Users.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<User>>> UpdateUser(User user)
		{
			var dbInsurance = await _context.Users.FindAsync(user.UserID);
			if (dbInsurance == null)
			{
				return BadRequest("User Not found");
			}

			dbInsurance.UserName = user.UserName;
			dbInsurance.FirstName = user.FirstName;
			dbInsurance.LastName = user.LastName;
			dbInsurance.DateOfBirth = user.DateOfBirth;
			dbInsurance.Pwd = user.Pwd;
			dbInsurance.Contact = user.Contact;
			dbInsurance.Email = user.Email;
			//dbInsurance.Contact = user.Contact;


			await _context.SaveChangesAsync();

			return Ok(await _context.Users.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<User>>> DeleteUser(int id)
		{
			var dbInsurance = await _context.Users.FindAsync(id);
			if (dbInsurance == null)
			{
				return BadRequest("User Not found");
			}
			_context.Users.Remove(dbInsurance);
			await _context.SaveChangesAsync();

			return Ok(await _context.Users.ToListAsync());
		}

		//[HttpPost]
		//public IActionResult Create(User user)
		//{
		//	if(_context.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null) 
		//	{
		//		return Ok("User Already Exists");
		//	}
		//	user.CreatedOn = DateTime.Now;
		//	_context.Users.Add(user);
		//	_context.SaveChanges();
		//	//return Ok(await _context.Users.ToListAsync());
		//	return Ok("Create Method Running");
		//}
	}
}
