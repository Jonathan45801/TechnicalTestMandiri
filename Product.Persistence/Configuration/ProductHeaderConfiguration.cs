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
    public class ProductHeaderConfiguration : IEntityTypeConfiguration<ProductHeader>
    {
        public void Configure(EntityTypeBuilder<ProductHeader> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NamaProduct)
                .HasColumnName("NamaProduct");

            builder.Property(x => x.DescriptionProduct)
                .HasColumnName("DescriptionProduct");

            builder.Property(x => x.CreatedTime)
                .HasColumnName("CreatedTime");

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.ToTable("Product");
        }
    }
}
