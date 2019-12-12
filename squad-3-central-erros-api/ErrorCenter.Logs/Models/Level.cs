using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
    [Table("LEVEL")]
    public class Level
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelId { get; set; }

        [Column("LEVEL")]
        [StringLength(30)]
        [Required]
        public string LevelName { get; set; }

        public virtual ICollection<Error> Errors { get; set; }
    }
}
