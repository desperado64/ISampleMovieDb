using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISampleMovieDb.Api.Model
{
    public class SendMailModel
    {
        public int MailAdressID { get; set; }
        public string MovieName { get; set; }
        public string Mail { get; set; }
    }
}
