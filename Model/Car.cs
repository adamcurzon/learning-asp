namespace learning_asp.Model
{
	public class Car
	{
		[Key]
        [Required]
        public int? Id { get; set; }

		[Required]
		[StringLength(maximumLength: 100, MinimumLength = 2)]
		public string? CarName { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string? CarColour { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string? CarSku { get; set; }

		public Car()
		{
		}
	}
}

