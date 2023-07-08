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

		[HttpGet]
		public IEnumerable<Car> GetCars() {
			return DealershipRepository.Cars;
		}

		[HttpGet("{id:int}")]
		public Car GetCar(int id) {
			return DealershipRepository.Cars.Where(n => n.CarId == id).FirstOrDefault();
		}
	}
}

