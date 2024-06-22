using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.Entities;

namespace User.Persistence.Configuration
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {

        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.UserName)
                .HasColumnName("UserName");

            builder.Property(x => x.Password)
                .HasColumnName("Password");

            builder.Property(x => x.CreatedTime)
                .HasColumnName("CreatedTime");

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.ToTable("UserLogin");
        }
    }
}
