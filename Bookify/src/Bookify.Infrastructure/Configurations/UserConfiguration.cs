using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToFunction("users");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName)
                .HasMaxLength(25)
                .HasConversion(firstName => firstName.Value, value => new FirstName(value));

            builder.Property(user => user.LastName)
                .HasMaxLength(25)
                .HasConversion(lastName => lastName.Value, value => new LastName(value));

            builder.Property(user => user.Email)
                .HasMaxLength(100)
                .HasConversion(email => email.Value, value => new Domain.Users.Email(value));

            builder.HasIndex(user => user.Email)
                .IsUnique();
        }
    }
}
