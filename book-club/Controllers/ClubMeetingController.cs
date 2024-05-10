using AutoMapper;
using book_club.Database.Context;
using book_club.Database.Entity;
using book_club.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace book_club.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class ClubMeetingController : ControllerBase
    {

        private readonly BookClubContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public ClubMeetingController(
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

        [Route("user-info")]
        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            try
            {

                var userEmail = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

                // TODO: Set up a service layer for any database operations and move this there
                var sessionUser = _context.Users.Where(x => x.Email == userEmail).FirstOrDefault();
                var bookClubs = _context.BookClubMembers
                    .Include(m => m.Club)
                    .Where(m => m.UserId == sessionUser.Id)
                    .Select(m => m.Club)
                    .ToArray();

                var bookClubsDTO = _mapper.Map<BookClub[], BookClubDTO[]>(bookClubs, opts => opts.AfterMap((src, dest) =>
                {
                    foreach (var club in dest)
                    {
                        club.IsOwner = sessionUser.Id == club.ClubId;
                    }

                }));
                var result = new UserInfoDTO() { Email = sessionUser.Email, UserName = sessionUser.UserName, BookClubs = bookClubsDTO };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(401, ex);
            }
        }

        //identify user
        //snag specified club
        //pull next meeting

        [Route("get-meeting")]
        [HttpGet]
        public async Task<IActionResult> GetCurrentMeeting()
        {
            try
            {
                var userEmail = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

                var sessionUser = _context.Users.Where(x => x.Email == userEmail).FirstOrDefault();
                var bookClubs = _context.BookClubMembers
                    .Include(m => m.Club)
                    .Where(m => m.UserId == sessionUser.Id)
                    .Select(m => m.Club)
                    .ToArray();

                //clubs come back in an array
                //find most recent


                //build a DTO to serve it up
            }
            catch (Exception ex)
            {
                return StatusCode(401, ex);
            }
        }
    }
}