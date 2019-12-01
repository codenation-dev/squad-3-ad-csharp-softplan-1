using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
    [Table("ambiente")]
    public class Ambiente
    {
        [Key, Column("id"), Required]
        public int Id { get; set; }

        [Column("nome"), MaxLength(40), Required]
        public string Nome { get; set; }
        public ICollection<Erro> Erros { get; set; }

        public Ambiente()
        {

        }
    }
}