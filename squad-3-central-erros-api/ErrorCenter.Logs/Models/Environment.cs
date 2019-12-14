using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for a Environment.
	/// </summary>
    [Table("ENVIRONMENT")]
    public class Environment
    {
		/// <summary>
		/// Unique identifier of a Environment.
		/// </summary>
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		/// <summary>
		/// Name of the Environment.
		/// </summary>
        [Column("NAME")]
        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Error> Errors { get; set; }


    }
}