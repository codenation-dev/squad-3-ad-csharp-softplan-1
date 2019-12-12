using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
    [Table("ENVIRONMENT")]
    public class Environment
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Environment_Id { get; set; }

        [Column("ENVIRONMENT")]
        [StringLength(30)]
        [Required]
        public string EnvironmentName { get; set; }

        public virtual ICollection<Error> Errors { get; set; }


    }
}