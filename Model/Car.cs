namespace learning_asp.Model
{
	public class Car
	{
		[Key]
		[Required]
		public Guid Id { get; set; } = Guid.Empty;

		[Required]
		[StringLength(maximumLength: 100, MinimumLength = 2)]
		public string CarName { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string CarColour { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string CarEngineType { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string CarEngineSize { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string CarSku { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }


        public Car()
		{
		}
	}
}

