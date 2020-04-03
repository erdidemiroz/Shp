using Autofac;
using Shp.Business.Abstract;
using Shp.Business.Concrete;
using Shp.DataAccess.Abstract;
using Shp.DataAccess.Concrete.EntityFramework;

namespace Shp.Business.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
        }
    }
}
