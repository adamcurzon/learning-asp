using System;
namespace learning_asp.Model
{
	public class User
	{
        [Key]
        [Required]
        public Guid? Id { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public User()
		{
		}
	}
}

