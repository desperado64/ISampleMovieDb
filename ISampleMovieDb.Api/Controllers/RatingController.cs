using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISampleMovieDb.Business.Abstract;
using ISampleMovieDb.Business.DependencyResolvers.Autofac;
using ISampleMovieDb.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISampleMovieDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {

        [HttpPost("private-post")]  
        [Authorize("read:actions")]
        [Route("add")]
        public ActionResult Post(Rating rating)
        {
            try
            {
                IRatingService ratingService = InstanceFactory.GetInstance<IRatingService>();
                if (rating.ID < 1)
                {
                    ratingService.Add(rating);
                    return Ok(rating);
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
        public ActionResult Put(Rating rating)
        {
            try
            {
                IRatingService ratingService = InstanceFactory.GetInstance<IRatingService>();
                if (rating.ID > 0)
                {
                    ratingService.Update(rating);
                    return Ok(rating);
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
    }
}