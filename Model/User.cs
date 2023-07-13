using System;
namespace learning_asp.Model
{
	public class User
	{
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public User()
		{
		}
	}
}

