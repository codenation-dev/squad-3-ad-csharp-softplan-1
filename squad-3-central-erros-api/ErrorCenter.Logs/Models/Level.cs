using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for a Level of severity.
	/// </summary>
    [Table("LEVEL")]
    public class Level
    {
		/// <summary>
		/// Unique identifier for a Level.
		/// </summary>
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		/// <summary>
		/// Name of the Level of severity.
		/// </summary>
        [Column("NAME")]
        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        //public virtual ICollection<Error> Errors { get; set; }
    }
}
