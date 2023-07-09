using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_asp.Interface;
using Microsoft.AspNetCore.Mvc;

namespace learning_asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IJwtProvider _jwtProvider;

        public UserController(IJwtProvider jwtProvider) {
            _jwtProvider = jwtProvider;
        }

        [HttpPost(Name = "Login")] 
        public string Login()
        {
            string token = _jwtProvider.Generate("adam");
            return token;
        }
    }
}

