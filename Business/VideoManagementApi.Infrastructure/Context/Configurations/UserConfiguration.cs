using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Context.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.UserName).IsRequired();
        builder.Property(a => a.FirstName).IsRequired();
        builder.Property(a => a.PasswordSalt).IsRequired();
        builder.Property(a => a.PasswordHash).IsRequired();
        builder.ToTable("Users");
    }
}