using ISampleMovieDb.DataAccess.Concrete.EntityFramework.Mappings;
using ISampleMovieDb.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.DataAccess.Concrete.EntityFramework
{
    public class ISampleMovieDbContext : DbContext
    {
        public string cs = @"Data Source={0}; Initial Catalog=ISampleMovieDb; User Id=LSampleMovieDb; Password=korkut1453;MultipleActiveResultSets=True";

        public ISampleMovieDbContext()
        {
            string ip = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DbSettings")["IP"];
            cs = String.Format(cs, ip);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(cs);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RatingMap());
            modelBuilder.ApplyConfiguration(new MovieMap());
            modelBuilder.ApplyConfiguration(new UserMap());           
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new MailAdressMap());

        }
     
        public DbSet<Movie> Movies { get; set; }

    }

}
