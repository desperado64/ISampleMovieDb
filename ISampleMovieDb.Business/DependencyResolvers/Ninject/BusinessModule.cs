using ISampleCommentDb.Business.Abstract;
using ISampleMovieDb.Business.Abstract;
using ISampleMovieDb.Business.Concrete;
using ISampleMovieDb.DataAccess.Abstract;
using ISampleMovieDb.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //this.Kernel.Components.Add<INinjectHttpApplicationPlugin, NinjectWebApiHttpApplicationPlugin>();

            this.Bind<IRatingService>().To<RatingManager>().InSingletonScope();
            this.Bind<IRatingDal>().To<EfRatingDal>().InSingletonScope(); 

            this.Bind<IMovieService>().To<MovieManager>().InSingletonScope();
            this.Bind<IMovieDal>().To<EfMovieDal>().InSingletonScope();

            this.Bind<IUserService>().To<UserManager>().InSingletonScope();
            this.Bind<IUserDal>().To<EfUsereDal>().InSingletonScope();

            this.Bind<ICommentService>().To<CommentManager>().InSingletonScope();
            this.Bind<ICommentDal>().To<EfCommentDal>().InSingletonScope();

            this.Bind<IMailAdressService>().To<MailAdressManager>().InSingletonScope();
            this.Bind<IMailAdressDal>().To<EfMailAdressDal>().InSingletonScope();
        }
    }
}
