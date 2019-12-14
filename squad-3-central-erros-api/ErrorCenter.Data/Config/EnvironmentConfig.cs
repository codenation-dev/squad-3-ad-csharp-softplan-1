using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Data.Config
{
    public class EnvironmentConfig : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            builder.ToTable("environment");
            
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(30).HasColumnType("varchar(30)");
            
        }
    }
}
