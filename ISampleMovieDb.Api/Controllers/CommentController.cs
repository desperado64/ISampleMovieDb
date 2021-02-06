using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISampleCommentDb.Business.Abstract;
using ISampleMovieDb.Business.DependencyResolvers.Autofac;
using ISampleMovieDb.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISampleMovieDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        [HttpPost("private-post")]
        [Authorize("read:actions")]
        [Route("add")]
        public ActionResult Post(Comment comment)
        {
            try
            {
                ICommentService commentService = InstanceFactory.GetInstance<ICommentService>();

                if (comment.ID < 1)
                {
                    commentService.Add(comment);
                    return Ok(comment);
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
        public ActionResult Put(Comment comment)
        {
            try
            {
                ICommentService commentService = InstanceFactory.GetInstance<ICommentService>();

                if (comment.ID > 0)
                {
                    commentService.Update(comment);
                    return Ok(comment);
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
                ICommentService commentService = InstanceFactory.GetInstance<ICommentService>();
                Comment comment = commentService.Get(id);

                if (comment!=null)
                {
                    commentService.Delete(comment);
                    return Ok();
                }
                else
                {
                    return BadRequest("İlgili Yorum Bulunamadı yada Silinmiş.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}