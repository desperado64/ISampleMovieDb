using ISampleMovieDb.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Entities.Concrete
{
    public class Rating : IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int rating { get; set; }
    }
}
