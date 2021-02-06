using ISampleMovieDb.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Entities.Concrete
{
    public class MailAdress : IEntity
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
    }
}
