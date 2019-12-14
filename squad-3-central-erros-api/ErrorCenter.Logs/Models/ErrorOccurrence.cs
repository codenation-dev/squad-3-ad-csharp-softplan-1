using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for a ErrorOccurrence.
	/// </summary>
    [Table("ERROR_OCCURRENCE")]
    public class ErrorOccurrence
    {
		/// <summary>
		/// Unique identifier for the ErrorOccurrence.
		/// </summary>
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		/// <summary>
		/// Origin of the Error.
		/// </summary>
        [Column("ORIGIN")]
        [StringLength(200)]
        [Required]
        public string Origin { get; set; }

		/// <summary>
		/// Details of the Error.
		/// </summary>
        [Column("DETAILS")]
        [StringLength(2000)]
        [Required]
        public string Details { get; set; }

		/// <summary>
		/// Date of the Error.
		/// </summary>
        [Column("DATE_TIME")]
        [Required]
        public DateTime DateTime { get; set; }

		/// <summary>
		/// Id of the User that registered the Error.
		/// </summary>
        [ForeignKey("USER_ID"), Required]
        public int UserId { get; set; }

		/// <summary>
		/// User that registered the Error.
		/// </summary>
        [Column("USER_ID"), Required]
        public virtual User User { get; set; }// referencia 

		/// <summary>
		/// Unique identifier of the Error.
		/// </summary>
        [ForeignKey("ERROR_ID"), Required]
        public int ErrorId { get; set; }

		/// <summary>
		/// Registered Error.
		/// </summary>
        [Column("ERROR_ID"), Required]
        public virtual Error Error { get; set; }// referencia 

		/// <summary>
		/// Event Count.
		/// </summary>
        [Column("EVENT_COUNT"), Required]
        public int EventCount { get; set; }
    }
}
