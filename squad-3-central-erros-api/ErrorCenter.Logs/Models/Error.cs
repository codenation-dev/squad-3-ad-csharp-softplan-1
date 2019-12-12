using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
    [Table("ERROR")]
    public class Error
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("CODE")]
        [Required]
        public int Code { get; set; }

        [Column("TITLE")]
        [StringLength(200)]
        [Required]
        public string Title { get; set; }

        [Column("DESCRIPTION")]
        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        [ForeignKey("ENVIRONMENT_ID"), Required]
        public int EnvironmentId { get; set; }

        [Column("ENVIRONMENT_ID"), Required]
        public Environment Environment { get; set; }// referencia 

        [ForeignKey("LEVEL_ID"), Required]
        public int LevelId { get; set; }

        [Column("LEVEL_ID"), Required]
        public Level Level { get; set; }// referencia 

        [ForeignKey("SITUATION_ID"), Required]
        public int SituationId { get; set; }

        [Column("SITUATION_ID"), Required]
        public Situation Situation { get; set; }// referencia 

    }
}
