using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;

namespace User.Persistence.Configuration
{
    public class UserLoginTokenConfiguration : IEntityTypeConfiguration<UserLoginToken>
    {
        public void Configure(EntityTypeBuilder<UserLoginToken> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserLogins)
                .WithMany(x => x.UserLoginTokens)
                .HasForeignKey(x => x.UserLoginId);

            builder.Property(x => x.AuthToken)
                .HasColumnName("AuthToken");

            builder.Property(x => x.Type)
                .HasColumnName("Type");

            builder.Property(x => x.ExpiresAt)
                .HasColumnName("ExpireAt");

            builder.Property(x => x.CreatedTime)
                .HasColumnName("CreatedTime");

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.ToTable("UserLoginToken");
        }
    }
}
