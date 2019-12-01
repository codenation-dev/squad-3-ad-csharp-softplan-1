using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
    [Table("nivel")]
    public class Nivel
    {
        [Key, Column("id"), Required]
        public int Id { get; set; }

        [Column("nome"), MaxLength(20), Required]
        public string Nome { get; set; }
        public ICollection<Erro> Erros { get; set; }

        public Nivel()
        {

        }
    }
}
