using System;
using System.Runtime.ConstrainedExecution;
using learning_asp.Interface;
using learning_asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace learning_asp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
        private readonly ILog _logger;

		public CarController(ILog logger)
		{
            _logger = logger;
		}

		[HttpGet("All", Name = "GetCars")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Car>> GetCars()
		{
            _logger.Log("GetCars");

            return Ok(DealershipRepository.Cars);
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

			Car? car = DealershipRepository.Cars.FirstOrDefault(n => n.Id == id);

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
            _logger.Log("GetCarBySku");

            if (string.IsNullOrEmpty(sku))
				return BadRequest();

            Car? car = DealershipRepository.Cars.FirstOrDefault(n => n.CarSku == sku);

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

            Car? car = DealershipRepository.Cars.FirstOrDefault(n => n.Id == id);

            if (car == null)
                return NotFound($"Car {id} couldn't be found");

            DealershipRepository.Cars.Remove(car);

			return Ok(car); 
		}

        [HttpPost("Create", Name = "CreateCar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Car> CreateCar([FromBody]Car model)
        {
            _logger.Log("CreateCar");

            if (model == null)
                return BadRequest();

            int carId = DealershipRepository.Cars.LastOrDefault().Id + 1;

            Car car = new Car
            {
                Id = carId,
                CarName = model.CarName,
                CarColour = model.CarColour,
                CarSku = model.CarSku
            };

            DealershipRepository.Cars.Add(car);

            return Ok(true);
        }

    }
}

