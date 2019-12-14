using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErrorCenter.Data.Config
{
    public class ErrorConfig : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.ToTable("ERROR");

            builder.HasKey(p => p.Id);
           // builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Code).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.EnvironmentId).IsRequired();
            builder.Property(p => p.LevelId).IsRequired();
            builder.Property(p => p.SituationId).IsRequired();

            /*

		/// <summary>

		/// <summary>
		/// Code of the Error.
		/// </summary>
        [Column("CODE")]
        [Required]
        public int Code { get; set; }
		
		/// <summary>
		/// Title of the Error.
		/// </summary>
        [Column("TITLE")]
        [StringLength(200)]
        [Required]
        public string Title { get; set; }

		/// <summary>
		/// Description of the Error.
		/// </summary>
        [Column("DESCRIPTION")]
        [StringLength(200)]
        [Required]
        public string Description { get; set; }

		/// <summary>
		/// ID of the Environment.
		/// </summary>
        [ForeignKey("ENVIRONMENT_ID"), Required]
        public int EnvironmentId { get; set; }

		/// <summary>
		/// ID of the Environment.
		/// </summary>
        [Column("ENVIRONMENT_ID"), Required]
        public virtual Environment Environment { get; set; }// referencia 

		/// <summary>
		/// ID of the Level of severity.
		/// </summary>
        [ForeignKey("LEVEL_ID"), Required]
        public int LevelId { get; set; }

		/// <summary>
		/// ID of the Level of severity.
		/// </summary>
        [Column("LEVEL_ID"), Required]
        public virtual Level Level { get; set; }// referencia 

		/// <summary>
		/// ID of the Situation.
		/// </summary>
        [ForeignKey("SITUATION_ID"), Required]
        public int SituationId { get; set; }

		/// <summary>
		/// ID of the Situation.
		/// </summary>
        [Column("SITUATION_ID"), Required]
        public virtual Situation Situation { get; set; }// referencia 
             * 
             */

        }

    }
}
