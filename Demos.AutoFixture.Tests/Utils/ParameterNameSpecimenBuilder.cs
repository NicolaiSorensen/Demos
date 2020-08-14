using System;
using System.Reflection;
using AutoFixture.Kernel;

namespace Demos.AutoFixture.Tests.Utils
{
    public class ParameterNameSpecimenBuilder<T> : ISpecimenBuilder
    {
        private readonly string _name;
        private readonly T[] _value;
        private readonly Random _random;

        public ParameterNameSpecimenBuilder(string name, params T[] value)
        {
            // we don't want a null name but we might want a null value
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            _name = name;
            _value = value;
            _random = new Random();
        }

        public object Create(object request, ISpecimenContext context)
        {
            if (request is ParameterInfo pi)
            {
                if (pi.ParameterType != typeof(T) ||
                    !string.Equals(
                        pi.Name,
                        _name,
                        StringComparison.CurrentCultureIgnoreCase))
                {
                    return new NoSpecimen();
                }
            }
            else
            {
                return new NoSpecimen();
            }

            var index = _random.Next(_value.Length);
            return _value[index];
        }
    }
}