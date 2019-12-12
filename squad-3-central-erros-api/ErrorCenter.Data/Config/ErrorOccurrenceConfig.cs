using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Data.Config
{
    public class ErrorOccurrenceConfig
    {
        public void Configure(EntityTypeBuilder<ErrorOccurrence> builder)
        {
            builder.ToTable("ErrorOccurrence");

            builder.HasKey(p => p.ErrorId);
        }
    }
}
