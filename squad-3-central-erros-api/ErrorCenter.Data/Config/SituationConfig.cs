using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Data.Config
{
    public class SituationConfig
    {
        public void Configure(EntityTypeBuilder<Situation> builder)
        {
            builder.ToTable("situation");

            builder.HasKey(p => p.SituationId);
        }
    }
}
