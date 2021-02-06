using ISampleMovieDb.Business.Abstract;
using ISampleMovieDb.Business.DependencyResolvers.Ninject;
using ISampleMovieDb.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    public class MailAdressController : ControllerBase
    {
        [HttpGet("private-list")]
        [Authorize("read:actions")]
        [Route("mails")]
        public ActionResult List()
        {
            IMailAdressService mailAdressService = InstanceFactory.GetInstance<IMailAdressService>();
            List<MailAdress> list = mailAdressService.GetAll();
            return Ok(list);

        }

        [HttpPost("private-post")]
        [Authorize("read:actions")]
        [Route("add")]
        public ActionResult Post(MailAdress mailAdress)
        {
            try
            {
                IMailAdressService mailAdressService = InstanceFactory.GetInstance<IMailAdressService>();
                if (mailAdress.ID < 1)
                {
                    mailAdressService.Add(mailAdress);
                    return Ok(mailAdress);
                }
                else
                {
                    return BadRequest("Yanlış istek.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("private-put")]
        [Authorize("read:actions")]
        [Route("update")]
        public ActionResult Put(MailAdress mailAdress)
        {
            try
            {
                IMailAdressService mailAdressService = InstanceFactory.GetInstance<IMailAdressService>();
                if (mailAdress.ID > 0)
                {
                    mailAdressService.Update(mailAdress);
                    return Ok(mailAdress);
                }
                else
                {
                    return BadRequest("Yanlış istek.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("private-delete")]
        [Authorize("read:actions")]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                IMailAdressService mailAdressService = InstanceFactory.GetInstance<IMailAdressService>();
                MailAdress mailAdress = mailAdressService.Get(id);
                if (mailAdress!=null)
                {
                    mailAdressService.Delete(mailAdress);
                    return Ok();
                }
                else
                {
                    return BadRequest("İlgili Mail Adresi Bulunamadı yada Silinmiş.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpGet("private-get")]
        [Authorize("read:actions")]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            IMailAdressService mailAdressService = InstanceFactory.GetInstance<IMailAdressService>();
            MailAdress mailAdress = mailAdressService.Get(id);
            return Ok(mailAdress);

        }
    }
}
