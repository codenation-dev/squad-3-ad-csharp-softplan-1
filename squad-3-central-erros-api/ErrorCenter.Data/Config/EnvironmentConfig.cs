using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Data.Config
{
    public class EnvironmentConfig
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            builder.ToTable("environment");
            
            builder.HasKey(p => p.Environment_Id);
            
        }

    }
}
