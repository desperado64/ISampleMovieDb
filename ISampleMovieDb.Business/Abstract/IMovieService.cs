using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ISampleMovieDb.Business.Abstract
{
    public interface IMovieService
    {
        List<Movie> GetAll(Expression<Func<Movie, bool>> filter = null);
        List<Movie> GetAll(int page,int size);
        Movie Get(int id);
        Movie Get(Expression<Func<Movie, bool>> filter);
        void Add(Movie movie);
        void Update(Movie movie);
       // void Delete(Movie movie);
    }
}
