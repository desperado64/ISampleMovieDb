using ISampleMovieDb.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.DataAccess.Concrete.EntityFramework.Mappings
{
    class MailAdressMap : IEntityTypeConfiguration<MailAdress>
    {
        public void Configure(EntityTypeBuilder<MailAdress> builder)
        {
            builder.ToTable(@"MailAdresses", @"dbo");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasColumnName("ID");
            builder.Property(x => x.AccountName).HasColumnName("AccountName");
            builder.Property(x => x.DisplayName).HasColumnName("DisplayName");
            builder.Property(x => x.Username).HasColumnName("Username");

            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.Server).HasColumnName("Server");
            builder.Property(x => x.Port).HasColumnName("Port");
            builder.Property(x => x.SSL).HasColumnName("SSL");


        }
    }
}
