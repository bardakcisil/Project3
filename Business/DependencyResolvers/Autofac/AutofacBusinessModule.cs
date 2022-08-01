using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EFProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}

//startupta 33 34 ün yaptigi isi yapar. autofacta kayit (instance gelistirmenin yolu ortami yukarısıdır.)
//apidaki program csde yazilan kod: ios olarak kendi altyapını kllanma ben businesdeki autofac business modulu kullanarak yapı verim dersen o.o
//webApi -> program.cs ( host.createDefaultBuilder(args) - .ConfigureWebHostDefaults() ) 