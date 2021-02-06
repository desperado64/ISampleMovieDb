using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ISampleMovieDb.Business.Abstract
{
    public interface IRatingService
    {
        List<Rating> GetAll(Expression<Func<Rating, bool>> filter = null);
        Rating Get(int id);
        Rating Get(Expression<Func<Rating, bool>> filter);
        void Add(Rating rating);
        void Update(Rating rating);
    }
}
