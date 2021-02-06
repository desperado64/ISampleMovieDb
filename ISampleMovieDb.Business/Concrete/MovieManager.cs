using ISampleMovieDb.Business.Abstract;
using ISampleMovieDb.DataAccess.Abstract;
using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ISampleMovieDb.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private IMovieDal movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            this.movieDal = movieDal;
        }

        public void Add(Movie movie)
        {
            movieDal.Add(movie);
        }

        public Movie Get(Expression<Func<Movie, bool>> filter)
        {
            return movieDal.Get(filter);
        }

        public List<Movie> GetAll(Expression<Func<Movie, bool>> filter = null)
        {
            return movieDal.GetAll(filter);
        }

        public Movie Get(int id)
        {
            return movieDal.Get(x => x.ID == id);
        }

        public void Update(Movie movie)
        {
            movieDal.Update(movie);
        }

        public List<Movie> GetAll(int page, int size)
        {
            int p1 = page * size;
            int p2 = (page + 1) * size;
            return movieDal.GetAll(x => x.ID >= p1 && x.ID < p2);
        }
    }
}
