using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.API.Helper;
using Ordersystem.DataObjects;

namespace Ordersystem.API.Controllers
{
    #region ApplicationUser API Controller Overview
    /// <summary>
    /// 1. **Dependencies:**
    /// The controller has dependencies on the `UserManager<ApplicationUser>` and `JwtHelper` which are injected through the constructor.
    ///
    /// 2. **Routing and Attributes:** 
    /// The class is decorated with the `[Route]` and `[ApiController]` attributes, which define the base route for the controller and
    /// indicate that it is an API controller.
    ///
    /// 3. **Action Methods:**
    /// - `PostUser`: 
    ///     Handles the HTTP POST request to create a new user. It receives an `ApplicationUserDto` object containing the user's
    ///     information. It validates the model, creates a new `ApplicationUser` using the received information, and calls the `CreateAsync`
    ///     method of the `_userManager` to create the user. If the creation is successful, it returns the created user as an
    ///     `ApplicationUserDto` object with the password field set to null.
    ///
    /// - `GetUser`:
    ///     Handles the HTTP GET request to retrieve a user by their username. It receives the username as a route parameter, calls the
    ///     `FindByNameAsync` method of the `_userManager` to find the user by their username, and returns the user as an
    ///     `ApplicationUserDto` object.
    ///
    /// - `CreateBearerToken`:
    ///     Handles the HTTP POST request to authenticate a user and generate a bearer token. It receives an `AuthenticationDto` object
    ///     containing the user's credentials. It validates the model, finds the user by their username using the `_userManager`, checks if
    ///     the password is valid using the `_userManager`, and if authentication is successful, it generates a bearer token using the
    ///     `_jwtHelper` and returns it as an `AuthorizationDto` object.
    /// </summary>
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtHelper _jwtHelper;

        public ApplicationUsersController(UserManager<ApplicationUser> userManager, JwtHelper jwtHelper)
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