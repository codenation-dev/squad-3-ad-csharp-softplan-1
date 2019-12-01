using ErrorCenter.Domain.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
    [Table("usuario")]
    public class Usuario : ModelBase
    {

        [Key, Column("id"), Required]
        public int Id { get; set; }

        [Column("token"), MaxLength(40), Required]
        public string Token { get; set; }

        [Column("nome"), MaxLength(100), Required]
        public string Nome { get; set; }

        [Column("email"), MaxLength(200), Required]
        public string Email { get; set; }

        [Column("senha"), MaxLength(30), Required]
        public string Senha { get; set; }

        public ICollection<Erro> Erros { get; set; }

        public Usuario()
        {

        }
    }

}

