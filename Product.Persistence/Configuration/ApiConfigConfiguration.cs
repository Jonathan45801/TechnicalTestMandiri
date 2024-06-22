using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistence.Configuration
{
    public class ApiConfigConfiguration : IEntityTypeConfiguration<ApiConfig>
    {
        public void Configure(EntityTypeBuilder<ApiConfig> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name");

            builder.Property(x => x.Url)
                .HasColumnName("Url");

            builder.Property(x => x.CreatedTime)
                .HasColumnName("CreatedTime");

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.ToTable("ApiConfig");
        }
    }
}
