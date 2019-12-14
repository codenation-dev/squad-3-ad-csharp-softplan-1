using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Data.Config
{
    public class ErrorOccurrenceConfig : IEntityTypeConfiguration<ErrorOccurrence>
    {
        public void Configure(EntityTypeBuilder<ErrorOccurrence> builder)
        {
            builder.ToTable("Error_Occurrence");

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Error).WithMany(p => p.ErrorOccurrences).HasForeignKey(p => p.ErrorId);
            builder.Property(p => p.EventCount).IsRequired();
            builder.Property(p => p.Origin).HasMaxLength(200).HasColumnType("varchar(200)");
            builder.HasOne(p => p.User).WithMany(p => p.ErrorOccurrences).HasForeignKey(p => p.UserId); 
            builder.Property(p => p.Details).HasMaxLength(2000).HasColumnType("varchar(2000)");
            builder.Property(p => p.DateTime).IsRequired();

            
        }
    }
}
