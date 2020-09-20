using System;
using System.Linq;
using Castle.DynamicProxy;
using FluentValidation;
using Shp.Core.CrossCuttingConcerns.Validation;
using Shp.Core.Utilities.Intercepters;
using Shp.Core.Utilities.Messages;

namespace Shp.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new System.Exception(AspectMessages.WrongValidationType);

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator =  (IValidator)Activator.CreateInstance(_validatorType); //create a new instance for base validator type
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //achieve first generic of base validator type to get entity
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType); //achieve arguments of all methods where entityType
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
