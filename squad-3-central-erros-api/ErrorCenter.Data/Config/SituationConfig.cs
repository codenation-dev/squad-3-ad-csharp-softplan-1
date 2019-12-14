using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Data.Config
{
    public class SituationConfig : IEntityTypeConfiguration<Situation>
    {
        public void Configure(EntityTypeBuilder<Situation> builder)
        {
            builder.ToTable("situation");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(30).HasColumnType("varchar(30)");
        }
    }
}
