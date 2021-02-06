using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISampleCommentDb.Business.Abstract;
using ISampleMovieDb.Api.Model;
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
    public class MovieController : ControllerBase
    {

        // GET api/values
        [HttpGet("private-list")]
        [Authorize("read:actions")]
        [Route("list")]
      
        public ActionResult List(int page,int size)
        {
            IMovieService movieService = InstanceFactory.GetInstance<IMovieService>();
            List<Movie> list = movieService.GetAll(page, size);

            return Ok(list);           

        }

        [HttpGet("private-get")]
        [Authorize("read:actions")]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            IMovieService movieService = InstanceFactory.GetInstance<IMovieService>();
            ICommentService commebtService = InstanceFactory.GetInstance<ICommentService>();
            IRatingService ratingtService = InstanceFactory.GetInstance<IRatingService>();

            Movie movie = movieService.Get(id);

            if (movie!=null)
            {
                List<Rating> ratings = ratingtService.GetAll(x => x.MovieID == id);
                decimal rating = ratings.Count > 0 ? ratings.Sum(x => x.rating) / ratings.Count : 0;
                int count = ratings.Count;
                UserRating ur = new UserRating
                {
                    RatingAverage = rating,
                    RatingCount = count
                };

                List<Comment> comments = commebtService.GetAll(x => x.MovieID == id);

                MovieForUser movieForUser = new MovieForUser
                {
                    TmdbData = movie,
                    UserRating = ur,
                    Comments = comments
                };

                return Ok(movieForUser);
            }
            else
            {
                return Ok(new MovieForUser());
            }
            

        }



    }
}