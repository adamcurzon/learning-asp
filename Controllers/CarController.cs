using System;
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
		public IEnumerable<Car> GetCars() {
			return DealershipRepository.Cars;
		}

		[HttpGet("{id:int}", Name = "GetCarById")]
		public Car GetCarById(int id)
		{
            return DealershipRepository.Cars.FirstOrDefault(n => n.CarId == id);
		}

		[HttpGet("{sku:alpha}", Name = "GetCarBySku")]
		public Car GetCarBySku(string sku)
		{
            return DealershipRepository.Cars.FirstOrDefault(n => n.CarSku == sku);
		}

		[HttpDelete("{id:int}", Name = "DeleteCarById")]
        public bool DeleteCarById(int id)
        {
            Car car = DealershipRepository.Cars.FirstOrDefault(n => n.CarId == id);
			DealershipRepository.Cars.Remove(car);

			return true; 
		}

    }
}

