using System;
using System.Reflection;
using AutoFixture.Kernel;

namespace Demos.AutoFixture.Tests.Utils
{
    public class ConstructorArgumentRelay<TTarget, TValueType> : ISpecimenBuilder
    {
        private readonly string _parameterName;
        private readonly TValueType _value;

        public ConstructorArgumentRelay(string parameterName, TValueType value)
        {
            _parameterName = parameterName;
            _value = value;
        }

        public string ParameterName => _parameterName;

        public TValueType Value => _value;

        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ParameterInfo parameter = request as ParameterInfo;
            if (parameter == null)
            {
                return new NoSpecimen();
            }

            if (parameter.Member.DeclaringType != typeof(TTarget) ||
                parameter.Member.MemberType != MemberTypes.Constructor ||
                parameter.ParameterType != typeof(TValueType) ||
                parameter.Name != _parameterName)
            {
                return new NoSpecimen();
            }

            return _value;
        }
    }
}
