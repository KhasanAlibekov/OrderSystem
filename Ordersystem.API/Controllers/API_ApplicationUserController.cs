using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.API.Helper;
using Ordersystem.DataObjects;

namespace Ordersystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_ApplicationUserController : ControllerBase
    {
        #region API UsersController
        /// <summary>
        /// This controller provides a RESTful API for managing users, including retrieving user
        /// information from database, creating new users, updating existing users and deleting users.
        /// </summary>
        ///
        #endregion

        [Route("api/[controller]")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly JwtHelper _jwtHelper;


            public UsersController(UserManager<ApplicationUser> userManager, JwtHelper jwtHelper)
            {
                _userManager = userManager;
                _jwtHelper = jwtHelper;
            }

            [HttpPost("create")]
            public async Task<ActionResult<ApplicationUserDto>> PostUser(ApplicationUserDto user)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var result = await _userManager.CreateAsync(
                    new ApplicationUser() { UserName = user.UserName, Email = user.Email },
                    user.Password
                );


                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }


                user.Password = null;
                // Created("", user);
                //this will include location header where we can find newly created user.
                return CreatedAtAction("GetUser", new { username = user.UserName }, user);
            }

            // GET: api/Users/username
            [HttpGet("{username}")]
            public async Task<ActionResult<ApplicationUserDto>> GetUser(string username)
            {
                IdentityUser user = await _userManager.FindByNameAsync(username);


                if (user == null)
                {
                    return NotFound();
                }


                return new ApplicationUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email
                };
            }

            // POST: api/Users/BearerToken
            [HttpPost("authenticate")]
            public async Task<ActionResult<AuthorizationDto>> CreateBearerToken(AuthenticationDto request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Bad credentials");
                }

                var user = await _userManager.FindByNameAsync(request.UserName);


                if (user == null)
                {
                    return BadRequest("Bad credentials");
                }

                var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

                if (!isPasswordValid)
                {
                    return BadRequest("Bad credentials");
                }

                var token = _jwtHelper.CreateToken(user);

                return Ok(token);
            }
        }
    }
}
