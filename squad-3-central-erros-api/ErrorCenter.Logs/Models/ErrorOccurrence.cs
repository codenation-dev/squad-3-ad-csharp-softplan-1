using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
    [Table("ERROR_OCCURRENCE")]
    public class ErrorOccurrence
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("ORIGIN")]
        [StringLength(200)]
        [Required]
        public string Origin { get; set; }

        [Column("DETAILS")]
        [StringLength(2000)]
        [Required]
        public string Details { get; set; }

        [Column("DATE_TIME")]
        [Required]
        public DateTime DateTime { get; set; }

        [ForeignKey("USER_ID"), Required]
        public int UserId { get; set; }

        [Column("USER_ID"), Required]
        public virtual User User { get; set; }// referencia 

        [ForeignKey("ERROR_ID"), Required]
        public int ErrorId { get; set; }

        [Column("ERROR_ID"), Required]
        public virtual Error Error { get; set; }// referencia 
    }
}
