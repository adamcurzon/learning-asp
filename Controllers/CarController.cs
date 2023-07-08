using learning_asp.Data;
using learning_asp.Interface;
using learning_asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learning_asp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
        private readonly ILog _logger;
        private readonly DealershipRepository _dealershipRepository;

        public CarController(DealershipRepository dealershipRepository, ILog logger)
		{
            _logger = logger;
            _dealershipRepository = dealershipRepository;
		}

		[HttpGet("All", Name = "GetCars")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
		{
            _logger.Log("GetCars");
            return Ok(await _dealershipRepository.GetCars());
		}

		[HttpGet("{id:int}", Name = "GetCarById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Car> GetCarById(int id)
		{
            _logger.Log("GetCarById");

            if (id <= 0)
                return BadRequest();

            var car = _dealershipRepository.GetCarById(id);

			if (car == null)
				return NotFound($"Car {id} couldn't be found");

            return Ok(car);
		}

		[HttpGet("{sku:alpha}", Name = "GetCarBySku")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Car> GetCarBySku(string sku)
        {
            _logger.Log("GetCarById");

            if (sku == null)
                return BadRequest();

            var car = _dealershipRepository.GetCarBySku(sku);

            if (car == null)
                return NotFound($"Car {sku} couldn't be found");

            return Ok(car);
        }

        [HttpDelete("{id:int}", Name = "DeleteCarById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Car> DeleteCarById(int id)
        {
            _logger.Log("DeleteCarById");

            if (id <= 0)
                return BadRequest();

            var car = _dealershipRepository.GetCarById(id);

            if (car == null)
                return NotFound($"Car {id} couldn't be found");

            _dealershipRepository.DeleteCar(car);

			return Ok(car); 
		}

        [HttpPost("", Name = "CreateCar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Car>>> CreateCar([FromBody]Car model)
        {
            _logger.Log("CreateCar");

            if (model == null)
                return BadRequest();

            int? carId = _dealershipRepository.GetCarLastId();

            if (carId == null)
                return BadRequest();

            int newCarId = carId.Value;
            newCarId++;
 

            Car car = new Car
            {
                Id = newCarId,
                CarName = model.CarName,
                CarColour = model.CarColour,
                CarSku = model.CarSku
            };

            return Ok(await _dealershipRepository.CreateCar(car));
        }

    }
}

