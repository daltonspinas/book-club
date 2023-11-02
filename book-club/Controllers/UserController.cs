using book_club.Database.Context;
using book_club.Database.Entity;
using Microsoft.AspNetCore.Mvc;

namespace book_club.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {

        private readonly BookClubContext _context;

        private readonly ILogger<UserController> _logger;

        public UserController(
            ILogger<UserController> logger,
            BookClubContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _context.Users;

            return users
            .ToArray();
        }
    }
}