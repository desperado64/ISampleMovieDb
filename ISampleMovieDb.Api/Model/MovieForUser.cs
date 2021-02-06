using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISampleMovieDb.Api.Model
{
    public class MovieForUser
    {
        public Movie TmdbData { get; set; }
        public UserRating UserRating { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
