namespace BusDep.UnityInject
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.Practices.Unity.InterceptionExtension;

    /// <summary>
    /// class DependencyFactory
    /// </summary>
    public class DependencyFactory
    {
        #region constructor
        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static DependencyFactory()
        {
            Container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                Container.LoadConfiguration(section);
            }
            //Interception
            Container.AddNewExtension<Interception>();
        }
        #endregion

        #region atributos
        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        private static IUnityContainer Container { get; set; }
        #endregion


        #region metodos

        public static void RegisterType<TTo, TFrom>(LifetimeManager lifetimeManager) where TFrom : TTo
        {
            if (!Container.IsRegistered<TTo>())
                Container.RegisterType<TTo, TFrom>(lifetimeManager);
        }

        public static void RegisterType<TTo, TFrom>() where TFrom : TTo
        {
            if (!Container.IsRegistered<TTo>())
                RegisterType<TTo, TFrom>(new ContainerControlledLifetimeManager());
        }

        public static void RegisterType<TTo, TFrom>(IEnumerable<InjectionMember> injectionMember) where TFrom : TTo
        {
            if (!Container.IsRegistered<TTo>())
                RegisterType<TTo, TFrom>(new ContainerControlledLifetimeManager(), injectionMember.ToArray());
        }
        public static void RegisterType<TTo, TFrom>(LifetimeManager lifetimeManager, IEnumerable<InjectionMember> injectionMember) where TFrom : TTo
        {
            if (!Container.IsRegistered<TTo>())
                Container.RegisterType<TTo, TFrom>(lifetimeManager, injectionMember.ToArray());
        }
        

        public static void ClearContainer()
        {
            foreach (var registration in Container.Registrations
                .Where(p => p.LifetimeManagerType == typeof(ContainerControlledLifetimeManager)))
            {
                registration.LifetimeManager.RemoveValue();
            }
            if (Container.Registrations.Any(p => p.LifetimeManagerType == typeof(ContainerControlledLifetimeManager)))
            {
                Container.Dispose();
                Container = new UnityContainer();
                var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                if (section != null)
                {
                    Container.LoadConfiguration(section);
                }
                Container.AddNewExtension<Interception>();
            }
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            if (Container.IsRegistered(typeof(T)))
            {
                return Container.Resolve<T>();
            }

            var registeredNames = Container.Registrations.Where(p => p.RegisteredType == typeof(T));
            if (registeredNames.Count() == 1)
            {
                return Container.Resolve<T>(registeredNames.First().Name);
            }

            if (registeredNames.Count() > 1)
            {
                throw new Exception("Existe más de un registro con la interfaz " + typeof(T).Name);
            }
            return default(T);
        }

        public static T Resolve<T>(string name)
        {
            if (Container.IsRegistered(typeof(T), name))
            {
                return Container.Resolve<T>(name);
            }

            return default(T);
        }
        #endregion
    }
}
