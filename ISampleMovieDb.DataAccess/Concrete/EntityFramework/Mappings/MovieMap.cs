using ISampleMovieDb.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.DataAccess.Concrete.EntityFramework.Mappings
{
    class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable(@"Movies", @"dbo");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasColumnName("ID");
            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.OriginalTitle).HasColumnName("OriginalTitle");
            builder.Property(x => x.PosterPath).HasColumnName("PosterPath");
            builder.Property(x => x.Adult).HasColumnName("Adult");
            builder.Property(x => x.Overview).HasColumnName("Overview");
            builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
            builder.Property(x => x.Genres).HasColumnName("Genres");
            builder.Property(x => x.OriginalLanguage).HasColumnName("OriginalLanguage");
            builder.Property(x => x.BackdropPath).HasColumnName("BackdropPath");
            builder.Property(x => x.Popularity).HasColumnName("Popularity");
            builder.Property(x => x.VoteCount).HasColumnName("VoteCount");
            builder.Property(x => x.Video).HasColumnName("Video");
            builder.Property(x => x.VoteAverage).HasColumnName("VoteAverage");
            builder.Property(x => x.TmdbID).HasColumnName("TmdbID");
        }
    }
}
