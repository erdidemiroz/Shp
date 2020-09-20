using System;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shp.Core.Extensions;
using Shp.Core.Utilities.Intercepters;
using Shp.Core.Utilities.IoC;

namespace Shp.Core.Aspects.Autofac.Authorization
{
    public class AuthorizationAspect : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthorizationAspect(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                    return;
            }
            throw new System.Exception("Authorization denied.");
        }
    }
}
