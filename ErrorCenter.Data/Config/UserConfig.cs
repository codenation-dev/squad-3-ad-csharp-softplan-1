using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorCenter.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(200).HasColumnType("varchar(200)");
            builder.Property(p => p.Password).HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(p => p.Token).HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(p => p.Email).HasMaxLength(200).HasColumnType("varchar(200)");
        }
    }
}
