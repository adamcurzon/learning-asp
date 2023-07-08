using System;
namespace learning_asp.Model
{
	public class DealershipRepository
	{
        public static List<Car> Cars { get; set; } = new List<Car>(){
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