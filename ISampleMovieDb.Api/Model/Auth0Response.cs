using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISampleMovieDb.Api.Model
{
    public class Auth0Response
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
    }
}
