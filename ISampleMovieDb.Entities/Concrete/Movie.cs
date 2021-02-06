using ISampleMovieDb.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Entities.Concrete
{
    public class Movie : IEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string PosterPath { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
        public string Genres { get; set; }
        public string OriginalLanguage { get; set; }
        public string BackdropPath { get; set; }
        public string Popularity { get; set; }
        public int VoteCount { get; set; }
        public bool Video { get; set; }
        public decimal VoteAverage { get; set; }
        public int TmdbID { get; set; }
    }
}
