using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovaAPI.Entities.Models;

namespace NovaAPI.Repositories.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("TB_ORDER");

            builder.HasKey(x => x.OrderId)
            .HasName("PK_TB_ORDER");

            builder.Property(x => x.OrderId)
            .HasColumnName("ORDER_ID")
            .HasColumnType(DatabaseTypeConstant.Integer)
            .IsRequired();

            builder.Property(x => x.OrderDate)
            .HasColumnName("DATE")
            .HasColumnType(DatabaseTypeConstant.DateTime)
            .IsRequired();

            builder.Property(x => x.OrderNumber)
            .HasColumnName("NUMBER")
            .HasColumnType(DatabaseTypeConstant.Varchar)
            .UseCollation(DatabaseTypeConstant.Collate)
            .HasMaxLength(100);

            builder.Property(x => x.OrderStatus)
            .HasColumnName("STATUS")
            .HasColumnType(DatabaseTypeConstant.Varchar)
            .UseCollation(DatabaseTypeConstant.Collate)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(x => x.CustomerId)
            .HasColumnType(DatabaseTypeConstant.Varchar)
            .HasMaxLength(200);

            builder.HasIndex(x => x.OrderId).HasDatabaseName("IDX_TB_ORDER_01");

            builder.HasOne(c => c.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(p => p.CustomerId)
            .HasConstraintName("FK_TB_ORDER_01")
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}