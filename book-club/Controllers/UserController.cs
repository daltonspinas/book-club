using book_club.Database.Context;
using book_club.Database.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace book_club.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {

        private readonly BookClubContext _context;

        private UserManager<User> _userManager;

        private readonly ILogger<UserController> _logger;

        public UserController(
            ILogger<UserController> logger,
            BookClubContext context,
            UserManager<User> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _userManager.Users.ToList();

            return users
            .ToArray();
        }

        [HttpGet]
        public Task<User> GetSingleUser ([FromBody] User user)
        {
          //  _userManager.CreateAsync(user, user.Password);

            var createdUser =_userManager.FindByEmailAsync(user.Email);

            return createdUser;
        }
    }
}