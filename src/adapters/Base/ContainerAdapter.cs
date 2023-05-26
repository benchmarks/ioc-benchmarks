using System;

namespace Unity.Benchmarks
{
    public abstract class ContainerAdapter
    {
        public abstract object IUnityContainer();

        public abstract object Resolve(Type type);

        public abstract object Resolve(Type type, string name);

        #region Type

        public abstract object RegisterType(Type type);

        public abstract object RegisterType(Type type, Type map);

        public abstract object RegisterType(Type type, string name);

        #endregion


        #region Instance

        public abstract object RegisterInstance(Type type, object instance);

        public abstract object RegisterInstance(Type type, string name, object instance);

        #endregion
    }
}
