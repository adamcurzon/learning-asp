using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace learning_asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private DealershipRepository _dealershipRepository;

        public StatsController(DealershipRepository dealershipRepository) {
            _dealershipRepository = dealershipRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<int> Stats()
        {
            return Ok(_dealershipRepository.GetTotalCars());
        }
    }
}

