using Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _context.Users.ToListAsync();

                if (users.Count == 0)
                {
                    return NotFound("No users found.");
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                // TODO: Log the error with a proper logger
                // _logger.LogError(ex, "An error occurred while retrieving users.");

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




    }
}
