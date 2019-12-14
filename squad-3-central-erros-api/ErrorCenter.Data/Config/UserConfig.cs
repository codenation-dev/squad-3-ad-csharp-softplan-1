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
        }
    }
}
