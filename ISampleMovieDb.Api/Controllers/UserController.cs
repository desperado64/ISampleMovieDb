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

namespace ISampleUserDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("private-post")]
        [Authorize("read:actions")]
        [Route("add")]
        public ActionResult Post(User user)
        {
            try
            {
                IUserService userService = InstanceFactory.GetInstance<IUserService>();

                if (user.ID < 1)
                {
                    userService.Add(user);
                    return Ok(user);
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
        public ActionResult Put(User user)
        {
            try
            {
                IUserService userService = InstanceFactory.GetInstance<IUserService>();

                if (user.ID > 0)
                {
                    userService.Update(user);
                    return Ok(user);
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

        [HttpGet("private-list")]
        [Authorize("read:actions")]
        [Route("list")]

        public ActionResult List()
        {
            IUserService userService = InstanceFactory.GetInstance<IUserService>();
            List<User> list = userService.GetAll();

            return Ok(list);

        }

        [HttpGet("private-get")]
        [Authorize("read:actions")]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            IUserService userService = InstanceFactory.GetInstance<IUserService>();
            User user = userService.Get(id);
            return Ok(user);

        }
    }
}
