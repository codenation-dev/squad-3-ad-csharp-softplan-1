using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for a ErrorOccurrence.
	/// </summary>
    public class ErrorOccurrence
    {
		/// <summary>
		/// Unique identifier for the ErrorOccurrence.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Origin of the Error.
		/// </summary>
        public string Origin { get; set; }

		/// <summary>
		/// Details of the Error.
		/// </summary>
        public string Details { get; set; }

		/// <summary>
		/// Date of the Error.
		/// </summary>
        public DateTime DateTime { get; set; }

		/// <summary>
		/// Id of the User that registered the Error.
		/// </summary>
        public int UserId { get; set; }

		/// <summary>
		/// User that registered the Error.
		/// </summary>
        public virtual User User { get; set; }// referencia 

		/// <summary>
		/// Unique identifier of the Error.
		/// </summary>
        public int ErrorId { get; set; }

		/// <summary>
		/// Registered Error.
		/// </summary>
        public virtual Error Error { get; set; }// referencia 

		/// <summary>
		/// Event Count.
		/// </summary>
        public int EventCount { get; set; }
    }
}
