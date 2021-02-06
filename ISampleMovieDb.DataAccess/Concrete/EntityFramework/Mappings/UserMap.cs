using ISampleMovieDb.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.DataAccess.Concrete.EntityFramework.Mappings
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(@"Users", @"dbo");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasColumnName("ID");
            builder.Property(x => x.Username).HasColumnName("Username");
            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.Email).HasColumnName("Email");

        }
    }
}
