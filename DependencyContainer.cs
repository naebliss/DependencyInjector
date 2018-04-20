using System;
using System.Collections.Generic;

namespace DependencyInjector
{
    class DependencyContainer
    {
        private readonly Dictionary<Type, Type> _registrations;

        public DependencyContainer()
        {
            _registrations = new Dictionary<Type, Type>();
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _registrations.Add(typeof(TInterface), typeof(TImplementation));
        }

        public TInterface Resolve<TInterface>() where TInterface : class 
        {
            return Resolve(typeof(TInterface)) as TInterface;
        }

        private object Resolve(Type type)
        {
            var target = ResolveType(type);
            var constructor = target.GetConstructors()[0];
            var parameters = constructor.GetParameters();

            var resolvedParameters = new List<object>();
            foreach (var parameter in parameters)
            {
                resolvedParameters.Add(Resolve(parameter.ParameterType));
            }

            return constructor.Invoke(resolvedParameters.ToArray());
        }

        private Type ResolveType(Type type)
        {
            return _registrations.ContainsKey(type) ? _registrations[type] : type;
        }
    }
}