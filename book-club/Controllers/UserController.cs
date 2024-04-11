using AutoMapper;
using book_club.Database.Context;
using book_club.Database.Entity;
using book_club.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace book_club.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {

        private readonly BookClubContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(
            ILogger<UserController> logger,
            BookClubContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
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

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginInfo)
        {
            
            var user = await _userManager.FindByEmailAsync(loginInfo.Email);

            var loginResult = await _signInManager.CheckPasswordSignInAsync(user, loginInfo.Password, false);

            if (loginResult.Succeeded)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);
            }
            else
            {
                return StatusCode(401, "Unauthorized Login");
            }
        }

    }
}