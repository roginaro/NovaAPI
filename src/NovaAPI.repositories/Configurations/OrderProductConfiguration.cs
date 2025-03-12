using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovaAPI.Entities.Models;

namespace NovaAPI.Repositories.Configurations
{
    internal class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            {
                builder.ToTable("TB_ORDERPRODUCT");

                builder.HasKey(op => new { op.OrderId, op.ProductId })
                .HasName("PK_TB_ORDERPRODUCT");

                builder.Property(o => o.OrderId)
                .HasColumnName("ORDER_ID")
                .HasColumnType(DatabaseTypeConstant.Integer)
                .IsRequired();
                builder.Property(p => p.ProductId)
                .HasColumnName("PRODUCT_ID")
                .HasColumnType(DatabaseTypeConstant.Integer)
                .IsRequired();


                builder.HasIndex(p => p.ProductId).HasDatabaseName("IDX_TB_ORDERPRODUCT_01");
                builder.HasIndex(o => o.OrderId).HasDatabaseName("IDX_TB_ORDERPRODUCT_02");

                builder.HasOne(op => op.Order)
                    .WithMany(o => o.OrderProducts)
                    .HasForeignKey(op => op.OrderId);
                builder.HasOne(op => op.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(op => op.ProductId);
            }
        }
    }
}