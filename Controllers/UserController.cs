using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_asp.Interface;
using learning_asp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace learning_asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IJwtProvider _jwtProvider;
        public UserRepository _userRepository;

        public UserController(IJwtProvider jwtProvider, UserRepository userRepository) {
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }

        [HttpPost(Name = "Login")] 
        public ActionResult<string> Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user == null)
                return NotFound();

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                return BadRequest();

            string token = _jwtProvider.Generate(email);

            return token;
        }
    }
}

