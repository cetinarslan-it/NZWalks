using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;
        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Models.DTOs.LoginRequest loginRequest)
        {
            //Validate the incoming request

            //For validation we use fluent validator. So we create validator class in validator folder for login request DTO

            //Check if user is authenticated

            //Check username and password
            var user = await _userRepository.UserAuthenticateAsync(loginRequest.Username, loginRequest.Password);

            if (user != null)
            {
                //generate a JWT

                var token = await _tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }
            return BadRequest("Username or password is incorrect.");



        }
    }
}
