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
            builder.Property(p => p.Code).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).HasColumnType("varchar(200)");
            builder.Property(p => p.Title).HasMaxLength(200).HasColumnType("varchar(200)");
            builder.HasOne(p => p.Level).WithMany(p => p.Errors);
            builder.HasOne(p => p.Situation).WithMany(p => p.Errors);
            builder.HasOne(p => p.Environment).WithMany(p => p.Errors);
        }

    }
}
