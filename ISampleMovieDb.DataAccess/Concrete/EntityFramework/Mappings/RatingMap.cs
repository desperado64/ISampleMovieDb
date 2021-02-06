using ISampleMovieDb.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.DataAccess.Concrete.EntityFramework.Mappings
{
    class RatingMap : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable(@"Ratings", @"dbo");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasColumnName("ID");
            builder.Property(x => x.UserID).HasColumnName("UserID");
            builder.Property(x => x.MovieID).HasColumnName("MovieID");
            builder.Property(x => x.rating).HasColumnName("Rating");

        }
    }
}
