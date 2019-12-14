using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for a User.
	/// </summary>
    public class User
    {
		/// <summary>
		/// Unique identifier for a User.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name of the User.
		/// </summary>
        public string Name { get; set; }

		/// <summary>
		/// User's e-mail.
		/// </summary>
        public string Email { get; set; }

		/// <summary>
		/// Password of a User.
		/// </summary>
        public string Password { get; set; }

		/// <summary>
		/// Unique token for a User's Session.
		/// </summary>        
        public string Token { get; set; }
      
        public virtual ICollection<ErrorOccurrence> ErrorOccurrences { get; set; }

    }

}

