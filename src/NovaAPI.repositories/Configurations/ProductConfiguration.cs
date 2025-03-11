using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovaAPI.Entities.Models;

namespace NovaAPI.Repositories.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.ProductId)
            .HasName("PK_TB_PRODUCT");

            builder.Property(x => x.ProductId)
            .HasColumnName("PRODUCT_ID")
            .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
            .HasColumnType("INTEGER")
            .IsRequired();

            builder.Property(x => x.Name)
            .HasColumnName("NAME")
            .HasColumnType(DatabaseTypeConstant.Varchar)
            .UseCollation(DatabaseTypeConstant.Collate)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(x => x.Description)
            .HasColumnType(DatabaseTypeConstant.Varchar)
            .UseCollation(DatabaseTypeConstant.Collate)
            .HasMaxLength(200);

            builder.Property(x => x.Price)
            .HasColumnName("PRICE")
            .HasColumnType(DatabaseTypeConstant.Money)
            .HasPrecision(2)
            .IsRequired();

            builder.Property(x => x.Image)
            .HasColumnType(DatabaseTypeConstant.Varchar)
            .HasMaxLength(200);

        }
    }
}