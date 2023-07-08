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
			return new List<Car>(){
				new Car {
					CarId = 1,
					CarName = "Ford Fiesa",
					CarColour = "Silver",
				},
                new Car {
                    CarId = 2,
                    CarName = "BMW M140",
                    CarColour = "Grey",
                },
            };
		}
	}
}

