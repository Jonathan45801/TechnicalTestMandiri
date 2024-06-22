using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entities;

namespace Product.Persistence.Configuration
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Details)
                .HasForeignKey(x => x.ProductId);

            builder.Property(x => x.ProductId)
                .HasColumnName("ProductId");

            builder.Property(x => x.Harga)
                .HasColumnName("Harga");

            builder.Property(x => x.TerJual)
                .HasColumnName("Terjual");

            builder.Property(x => x.CreatedTime)
                .HasColumnName("CreatedTime");

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.Property(x => x.LastUpdatedTime)
                .HasColumnName("LastUpdatedTime");

            builder.Property(x => x.LastUpdatedBy)
                .HasColumnName("LastUpdatedBy");

            builder.ToTable("ProductDetail");
        }
    }
}
