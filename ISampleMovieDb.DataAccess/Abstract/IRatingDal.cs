using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.DataAccess.Abstract
{
    public interface IRatingDal :  IEntityRepository<Rating>
    {
    }
}
