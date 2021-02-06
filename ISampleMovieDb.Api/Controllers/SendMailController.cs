using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISampleMovieDb.Api.Model;
using ISampleMovieDb.Api.Util.Mail;
using ISampleMovieDb.Business.Abstract;
using ISampleMovieDb.Business.DependencyResolvers.Ninject;
using ISampleMovieDb.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISampleMovieDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        [HttpPost("private-post")]
        [Authorize("read:actions")]
        [Route("send")]
        public ActionResult Post(SendMailModel model)
        {
            try
            {
                IMailAdressService mailAdressService = InstanceFactory.GetInstance<IMailAdressService>();
                MailAdress mailAdress = mailAdressService.Get(model.MailAdressID);

                if (mailAdress!=null)
                {
                    SendMail sendMail = new SendMail();
                    string displayname = mailAdress.DisplayName;
                    string subject = model.MovieName + " Filminiz Mutlaka İzleyin";
                    string userName = mailAdress.Username;
                    string server = mailAdress.Server;
                    string password = mailAdress.Password;
                    int port = mailAdress.Port;
                    bool ssl = mailAdress.SSL;

                    string content = model.Mail + " adresine sahip kullanıcı size " + model.MovieName + " adlı filmi izleminizi tavsiye ediyor.";

                    List<string> list = new List<string>();
                    list.Add(model.Mail);

                    string result = sendMail.Send(subject, content, list, userName, password, server, port, displayname, ssl) ? "Mail Gönderildi" : "Mail Gönderilemedi";

                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}