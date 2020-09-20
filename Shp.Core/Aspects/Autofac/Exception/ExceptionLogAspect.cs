using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Shp.Core.CrossCuttingConcerns.Logging;
using Shp.Core.CrossCuttingConcerns.Logging.Log4Net;
using Shp.Core.Utilities.Intercepters;
using Shp.Core.Utilities.Messages;

namespace Shp.Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            if (!loggerService.BaseType.IsAssignableFrom(typeof(LoggerServiceBase)))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase) Activator.CreateInstance(loggerService);
        }
        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetailWithException(invocation, e);
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetailWithException(IInvocation invocation, System.Exception e)
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

            return new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters,
                ExceptionMessage = e.Message
            };
        }
    }
}
