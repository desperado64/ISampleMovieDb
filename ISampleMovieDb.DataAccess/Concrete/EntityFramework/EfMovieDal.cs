﻿using ISampleMovieDb.DataAccess.Abstract;
using ISampleMovieDb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.DataAccess.Concrete.EntityFramework
{
    public class EfMovieDal : EfEntityRepositoryBase<Movie,ISampleMovieDbContext>,IMovieDal
    {
    }
}
