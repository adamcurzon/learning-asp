using System;
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

		[HttpGet ]
		public string GetCarName() {
			return "Ford Fiesta";
		}
	}
}

