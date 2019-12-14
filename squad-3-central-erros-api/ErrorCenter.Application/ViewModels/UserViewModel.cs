using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
	/// <summary>
	/// Basic parameters for a User.
	/// </summary>
    public class UserViewModel
    {
		/// <summary>
		/// Unique identifier for a User.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name of the User.
		/// </summary>
        [Required]
        public string Name { get; set; }

		/// <summary>
		/// User's e-mail.
		/// </summary>
        [Required]
        public string Email { get; set; }

		/// <summary>
		/// Password of a User.
		/// </summary>
        [Required]
        public string Password { get; set; }

		/// <summary>
		/// Unique token for a User's Session.
		/// </summary>
        [Required]
        public string Token { get; set; }
    }
}
