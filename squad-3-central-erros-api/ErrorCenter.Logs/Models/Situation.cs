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
        public int Id { get; set; }

        [Column("NAME")]
        [StringLength(30)]
        [Required]
        public string Name { get; set; }

       // public virtual ICollection<Error> Errors { get; set; }
    }
}
