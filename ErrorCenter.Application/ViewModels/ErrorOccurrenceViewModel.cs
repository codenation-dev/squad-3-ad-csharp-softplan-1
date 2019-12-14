using ErrorCenter.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
	/// <summary>
	/// Basic parameters for a ErrorOccurrence.
	/// </summary>
    public class ErrorOccurrenceViewModel
    {
		/// <summary>
		/// Unique identifier for the ErrorOccurrence.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Origin of the Error.
		/// </summary>
        [Required]
        public string Origin { get; set; }

		/// <summary>
		/// Details of the Error.
		/// </summary>
        [Required]
        public string Details { get; set; }

		/// <summary>
		/// Date of the Error.
		/// </summary>
        [Required]
        public DateTime DateTime { get; set; }

		/// <summary>
		/// Id of the User that registered the Error.
		/// </summary>
        [Required]
        public int UserId { get; set; }

		/// <summary>
		/// User that registered the Error.
		/// </summary>
        public virtual UserViewModel User { get; set; }

		/// <summary>
		/// Unique identifier of the Error.
		/// </summary>
        [Required]
        public int ErrorId { get; set; }

		/// <summary>
		/// Registered Error.
		/// </summary>
        public virtual ErrorViewModel Error { get; set; }

		/// <summary>
		/// Event Count.
		/// </summary>
        [Required]
        public int EventCount { get; set; }

    }
}
