using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.ExternalWebServices.Tmdb.Model.Movie
{
    public class Popular
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }
}
