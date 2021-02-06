using ISampleMovieDb.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Entities.Concrete
{
    public class User : IEntity
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
