using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moq.Domain.Models;

namespace Moq.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder
                .Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar(100)");

            builder
                .Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar(100)");

        }
    }
}
