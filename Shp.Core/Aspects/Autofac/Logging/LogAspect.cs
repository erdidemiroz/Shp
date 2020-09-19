using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Shp.Core.CrossCuttingConcerns.Logging;
using Shp.Core.CrossCuttingConcerns.Logging.Log4Net;
using Shp.Core.Utilities.Intercepters;
using Shp.Core.Utilities.Messages;

namespace Shp.Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (!loggerService.BaseType.IsAssignableFrom(typeof(LoggerServiceBase)))
                throw new Exception(AspectMessages.WrongLoggerType);
            
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var logDetail = GetLogDetail(invocation);
            _loggerServiceBase.Info(logDetail);
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
               logParameters.Add(new LogParameter
               {
                   Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                   Value = invocation.Arguments[i],
                   Type = invocation.Arguments[i].GetType().Name
               }); 
            }

            return new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };
        }
    }
}
