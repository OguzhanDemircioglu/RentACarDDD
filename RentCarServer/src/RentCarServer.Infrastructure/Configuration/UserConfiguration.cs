using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarServer.Domain.Users;

namespace RentCarServer.Infrastructure.Configuration;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(i => i.Id);

        builder.OwnsOne(i => i.FirstName, fn =>
        {
            fn.Property(p => p.Value)
                .HasColumnName("FirstName")
                .IsRequired();
        });

        builder.OwnsOne(i => i.LastName, ln =>
        {
            ln.Property(p => p.Value)
                .HasColumnName("LastName")
                .IsRequired();
        });

        builder.OwnsOne(i => i.FullName, fn =>
        {
            fn.Property(p => p.Value)
                .HasColumnName("FullName")
                .IsRequired();
        });

        builder.OwnsOne(i => i.Email, e =>
        {
            e.Property(p => p.Value)
                .HasColumnName("Email")
                .IsRequired();
        });

        builder.OwnsOne(i => i.UserName, un =>
        {
            un.Property(p => p.Value)
                .HasColumnName("UserName")
                .IsRequired();
        });

        builder.OwnsOne(u => u.Password, pw =>
        {
            pw.Property(p => p.PasswordHash)
                .HasColumnName("PasswordHash")
                .IsRequired();

            pw.Property(p => p.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .IsRequired();
        });
    }
}