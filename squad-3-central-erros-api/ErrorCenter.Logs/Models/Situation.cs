using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
    [Table("SITUATION")]
    public class Situation
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SituationId { get; set; }

        [Column("SITUATION")]
        [StringLength(30)]
        [Required]
        public string SituationName { get; set; }

        public ICollection<Error> Errors { get; set; }
    }
}
