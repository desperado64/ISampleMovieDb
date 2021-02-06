using ISampleMovieDb.Business.Abstract;
using ISampleMovieDb.Business.Utilities;
using ISampleMovieDb.Business.ValidationRules.FluentValidation;
using ISampleMovieDb.DataAccess.Abstract;
using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ISampleMovieDb.Business.Concrete
{
    public class RatingManager : IRatingService
    {
        private IRatingDal ratingDal;

        public RatingManager(IRatingDal ratingDal)
        {
            this.ratingDal = ratingDal;
        }

        public void Add(Rating rating)
        {
            ValidationTool.Validate(new RatingValidator(), rating);
            ratingDal.Add(rating);
        }

        public Rating Get(int id)
        {
            return ratingDal.Get(x => x.ID == id);

        }

        public Rating Get(Expression<Func<Rating, bool>> filter)
        {
            return ratingDal.Get(filter);
        }

        public List<Rating> GetAll(Expression<Func<Rating, bool>> filter = null)
        {
            return ratingDal.GetAll(filter);
        }

        public void Update(Rating rating)
        {
            ValidationTool.Validate(new RatingValidator(), rating);
            ratingDal.Update(rating);
        }
    }
}
