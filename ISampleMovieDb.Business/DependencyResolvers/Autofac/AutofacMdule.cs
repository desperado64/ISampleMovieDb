using Autofac;
using ISampleCommentDb.Business.Abstract;
using ISampleMovieDb.Business.Abstract;
using ISampleMovieDb.Business.Concrete;
using ISampleMovieDb.DataAccess.Abstract;
using ISampleMovieDb.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.Business.DependencyResolvers.Autofac
{
    public class AutofacMdule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RatingManager>().As<IRatingService>().InstancePerLifetimeScope();
            builder.RegisterType<EfRatingDal>().As<IRatingDal>().InstancePerLifetimeScope(); 

            builder.RegisterType<MovieManager>().As<IMovieService>().InstancePerLifetimeScope(); 
            builder.RegisterType<EfMovieDal>().As<IMovieDal>().InstancePerLifetimeScope();


            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUsereDal>().As<IUserDal>().InstancePerLifetimeScope();

            builder.RegisterType<CommentManager>().As<ICommentService>().InstancePerLifetimeScope();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().InstancePerLifetimeScope();

            builder.RegisterType<MailAdressManager>().As<IMailAdressService>().InstancePerLifetimeScope();
            builder.RegisterType<EfMailAdressDal>().As<IMailAdressDal>().InstancePerLifetimeScope();
        }
    }
}
