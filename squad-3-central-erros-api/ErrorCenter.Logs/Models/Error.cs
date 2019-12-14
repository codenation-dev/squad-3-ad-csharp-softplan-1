using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for an Error.
	/// </summary>
    [Table("ERROR")]
    public class Error
    {
		/// <summary>
		/// Unique identifier for the Error.
		/// </summary>
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		/// <summary>
		/// Code of the Error.
		/// </summary>
        [Column("CODE")]
        [Required]
        public int Code { get; set; }
		
		/// <summary>
		/// Title of the Error.
		/// </summary>
        [Column("TITLE")]
        [StringLength(200)]
        [Required]
        public string Title { get; set; }

		/// <summary>
		/// Description of the Error.
		/// </summary>
        [Column("DESCRIPTION")]
        [StringLength(200)]
        [Required]
        public string Description { get; set; }

		/// <summary>
		/// ID of the Environment.
		/// </summary>
        [ForeignKey("ENVIRONMENT_ID"), Required]
        public int EnvironmentId { get; set; }

		/// <summary>
		/// ID of the Environment.
		/// </summary>
        [Column("ENVIRONMENT_ID"), Required]
        public virtual Environment Environment { get; set; }// referencia 

		/// <summary>
		/// ID of the Level of severity.
		/// </summary>
        [ForeignKey("LEVEL_ID"), Required]
        public int LevelId { get; set; }

		/// <summary>
		/// ID of the Level of severity.
		/// </summary>
        [Column("LEVEL_ID"), Required]
        public virtual Level Level { get; set; }// referencia 

		/// <summary>
		/// ID of the Situation.
		/// </summary>
        [ForeignKey("SITUATION_ID"), Required]
        public int SituationId { get; set; }

		/// <summary>
		/// ID of the Situation.
		/// </summary>
        [Column("SITUATION_ID"), Required]
        public virtual Situation Situation { get; set; }// referencia 

    }
}
