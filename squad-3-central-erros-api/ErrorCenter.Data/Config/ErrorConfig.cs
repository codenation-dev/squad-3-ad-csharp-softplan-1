using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Data.Config
{
    public class ErrorConfig
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.ToTable("error");

            builder.HasKey(p => p.Id);

        }

    }
}
