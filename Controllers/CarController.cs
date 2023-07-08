using System;
using System.Runtime.ConstrainedExecution;
using learning_asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace learning_asp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		public CarController()
		{
		}

		[HttpGet("All", Name = "GetCars")]
		public ActionResult<IEnumerable<Car>> GetCars()
		{
			return Ok(DealershipRepository.Cars);
		}

		[HttpGet("{id:int}", Name = "GetCarById")]
		public ActionResult<Car> GetCarById(int id)
		{
			if (id <= 0) 
				return BadRequest();

			Car? car = DealershipRepository.Cars.FirstOrDefault(n => n.CarId == id);

			if (car == null)
				return NotFound($"Car {id} couldn't be found");

            return Ok(car);
		}

		[HttpGet("{sku:alpha}", Name = "GetCarBySku")]
		public ActionResult<Car> GetCarBySku(string sku)
		{
			if (string.IsNullOrEmpty(sku))
				return BadRequest();

            Car? car = DealershipRepository.Cars.FirstOrDefault(n => n.CarSku == sku);

            if (car == null)
                return NotFound($"Car {sku} couldn't be found");

			return Ok(car);

		}

		[HttpDelete("{id:int}", Name = "DeleteCarById")]
        public ActionResult<bool> DeleteCarById(int id)
        {
            if (id <= 0)
                return BadRequest();

            Car? car = DealershipRepository.Cars.FirstOrDefault(n => n.CarId == id);

            if (car == null)
                return NotFound($"Car {id} couldn't be found");

            DealershipRepository.Cars.Remove(car);

			return Ok(true); 
		}

    }
}

