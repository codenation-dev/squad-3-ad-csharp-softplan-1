using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for a Situation.
	/// </summary>
    [Table("SITUATION")]
    public class Situation
    {
		/// <summary>
		/// Unique identifier for the Situation.
		/// </summary>
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		/// <summary>
		/// Name of the Situation.
		/// </summary>
        [Column("NAME")]
        [StringLength(30)]
        [Required]
        public string Name { get; set; }

       // public virtual ICollection<Error> Errors { get; set; }
    }
}
