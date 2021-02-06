using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http.Dependencies;
using Autofac;

namespace ISampleMovieDb.Business.DependencyResolvers.Autofac
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacMdule());

            IContainer container = builder.Build();
            

            return  container.Resolve<T>();


        }
    }
}
