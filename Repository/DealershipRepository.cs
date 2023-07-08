using System;
namespace learning_asp.Model
{
	public class DealershipRepository
	{
        public static List<Car> Cars { get; set; } = new List<Car>(){
            new Car {
                Id = 1,
                CarName = "Ford Fiesa",
                CarSku = "fordfiesta",
                CarColour = "Silver",
            },
            new Car {
                Id = 2,
                CarName = "BMW M140",
                CarSku = "bmwm140",
                CarColour = "Grey",
            },
        };
	}
}