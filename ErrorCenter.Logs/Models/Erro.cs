using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
    [Table("erro")]
    public class Erro
    {
        [Key, Column("id"), Required]
        public int Id { get; set; }

        [Column("id_usuario"), Required] ///// atualizar
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Column("id_nivel"), Required]
        public int IdNivel { get; set; }

        [ForeignKey("IdNivel")]
        public Nivel Nivel { get; set; }

        [Column("id_ambiente"), Required]
        public int IdAmbiente { get; set; }

        [ForeignKey("IdAmbiente")]
        public Ambiente Ambiente { get; set; }

        [Column("origem"), MaxLength(16), Required]
        public string Origem { get; set; } //ip

        [Column("data_hora"), Required]
        public DateTime DataHora { get; set; }

        [Column("titulo"), MaxLength(100), Required]
        public string Titulo { get; set; }

        [Column("detalhe"), MaxLength(2000), Required]
        public string Detalhe { get; set; }

        [Column("status"), MaxLength(1), Required]
        public char Status { get; set; }

        public Erro()
        {

        }
    }
}
