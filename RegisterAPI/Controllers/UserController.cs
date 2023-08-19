using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegisterAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IConfiguration _config;
        public UserController(IConfiguration config)
        {
            _config = config;
        }

		[HttpPost]
		public IActionResult Create()
		{
			return Ok("Create Method Running");
		}
    }
}
