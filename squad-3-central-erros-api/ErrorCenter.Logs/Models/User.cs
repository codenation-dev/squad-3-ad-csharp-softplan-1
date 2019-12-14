using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for a User.
	/// </summary>
    [Table("USER")]
    public class User
    {
		/// <summary>
		/// Unique identifier for a User.
		/// </summary>
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		/// <summary>
		/// Name of the User.
		/// </summary>
        [Column("NAME")]
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

		/// <summary>
		/// User's e-mail.
		/// </summary>
        [Column("EMAIL")]
        [StringLength(200)]
        [Required]
        public string Email { get; set; }

		/// <summary>
		/// Password of a User.
		/// </summary>
        [Column("PASSWORD")]
        [StringLength(50)]
        [Required]
        public string Password { get; set; }

		/// <summary>
		/// Unique token for a User's Session.
		/// </summary>
        [Column("TOKEN")]
        [MaxLength(40)]
        [Required]
        public string Token { get; set; }

       // public virtual ICollection<ErrorOccurrence> ErrorOccurrences { get; set; }

    }

}

