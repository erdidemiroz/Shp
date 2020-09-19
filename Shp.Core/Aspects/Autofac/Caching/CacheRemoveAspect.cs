using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Shp.Core.CrossCuttingConcerns.Caching;
using Shp.Core.Utilities.Intercepters;
using Shp.Core.Utilities.IoC;

namespace Shp.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
