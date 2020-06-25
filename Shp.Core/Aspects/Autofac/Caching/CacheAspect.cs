using System.Linq;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Shp.Core.CrossCutingConcerns.Caching;
using Shp.Core.Utilities.Intercepters;
using Shp.Core.Utilities.IoC;

namespace Shp.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); //ClassName.MethodName
            var arguments = invocation.Arguments.ToList();
            var key = string.Format($"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"); //key based on class name, method name and parameters
            if (_cacheManager.isAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
