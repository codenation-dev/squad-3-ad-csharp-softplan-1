using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErrorCenter.Application.ViewModels
{
	/// <summary>
	/// Basic parameters for a Login.
	/// </summary>
	public class LoginViewModel
	{
		/// <summary>
		/// User Login.
		/// </summary>
        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

		/// <summary>
		/// User Password.
		/// </summary>
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
