using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISampleMovieDb.Api.Model
{
    public class UserRating
    {
        public decimal RatingAverage { get; set; }
        public int RatingCount { get; set; }
    }
}
