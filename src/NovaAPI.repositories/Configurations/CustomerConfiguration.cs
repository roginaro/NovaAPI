using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovaAPI.Entities.Models;

namespace NovaAPI.Repositories.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            {
                builder.ToTable("TB_CUSTOMER");

                builder.HasKey(x => x.CustomerId)
                .HasName("PK_TB_CUSTOMER");

                builder.Property(x => x.CustomerId)
                .HasColumnName("CUSTOMER_ID")
                .HasColumnType(DatabaseTypeConstant.Integer)
                .IsRequired();

                builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType(DatabaseTypeConstant.Varchar)
                .UseCollation(DatabaseTypeConstant.Collate)
                .HasMaxLength(100);

                builder.Property(x => x.Document)
                .HasColumnName("DOCUMENT")
                .HasColumnType(DatabaseTypeConstant.Varchar)
                .UseCollation(DatabaseTypeConstant.Collate)
                .HasMaxLength(50)
                .IsRequired();

                builder.Property(x => x.Email)
               .HasColumnName("EMAIL")
               .HasColumnType(DatabaseTypeConstant.Varchar)
               .UseCollation(DatabaseTypeConstant.Collate)
               .HasMaxLength(50)
               .IsRequired();

                builder.Property(x => x.Phone)
               .HasColumnName("PHONE")
               .HasColumnType(DatabaseTypeConstant.Varchar)
               .UseCollation(DatabaseTypeConstant.Collate)
               .HasMaxLength(50)
               .IsRequired();

                builder.Property(x => x.Address)
               .HasColumnName("ADDRESS")
               .HasColumnType(DatabaseTypeConstant.Varchar)
               .UseCollation(DatabaseTypeConstant.Collate)
               .HasMaxLength(50)
               .IsRequired();

                builder.HasIndex(x => x.CustomerId).HasDatabaseName("IDX_TB_CUSTOMER_01");
            }
        }
    }
}