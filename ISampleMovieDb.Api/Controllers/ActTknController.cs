using ISampleMovieDb.Api.Model;
using ISampleMovieDb.ExternalWebServices.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISampleMovieDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ActTknController : ControllerBase
    {
        [HttpPost]
        [Route("generate")]

        public ActionResult Generate(int page, int size)
        {
            string link = "https://dev-mgok.us.auth0.com/oauth/token";
            Auth0Request request = new Auth0Request
            {
                client_id = "isErZZ0bceIM7UIZidVuIY0nFuTX22oJ",
                client_secret = "aGJoRHF9TMC5xXT8bHrm4sIlR2JqOM6mrCF8r7qA2CHRh3S_r-iqI1DspPto7rtT",
                audience = "http://localhost:65159/api/",
                grant_type = "client_credentials"
            };
            Auth0Response response = JsonParse.Post<Auth0Request, Auth0Response>(link, request);

            return Ok(response);

        }
    }
}
