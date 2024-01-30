using AutoMapper;
using book_club.Database.Context;
using book_club.Database.Entity;
using book_club.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace book_club.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {

        private readonly BookClubContext _context;

        private UserManager<User> _userManager;

        private readonly ILogger<UserController> _logger;

        private readonly IMapper _mapper;

        public UserController(
            ILogger<UserController> logger,
            BookClubContext context,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
    }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _userManager.Users.ToList();

            return users
            .ToArray();
        }

        [Route("create-user")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO userInfo)
        {

            var result = await _userManager.CreateAsync(_mapper.Map<User>(userInfo), userInfo.Password);

            if(result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                string errors = "";

                foreach (var error in result.Errors)
                {
                    errors += error.Description;
                }

                return StatusCode(500, errors);
            }
        }

    }
}