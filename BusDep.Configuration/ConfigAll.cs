using System;
using BusDep.Business;
using BusDep.IBusiness;

namespace BusDep.Configuration
{
    using BusDep.Entity;
    using BusDep.Configuration.Interception;
    using BusDep.DataAccess;
    using BusDep.IDataAccess;
    using BusDep.UnityInject;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;

    public class ConfigAll : IDisposable
    {
        public void Init()
        {
            #region DataAccess
            DependencyFactory.RegisterType<IUsuarioDA, UsuarioDA>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
                }
                );
            DependencyFactory.RegisterType<IBaseDA<TipoUsuario>, CommonDA<TipoUsuario>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Deporte>, CommonDA<Deporte>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<TemplateEvaluacion>, CommonDA<TemplateEvaluacion>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<DatosPersona>, CommonDA<DatosPersona>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
              }
              );
            #endregion

            #region Business
            DependencyFactory.RegisterType<ILoginBusiness, LoginBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
                }
                );
            DependencyFactory.RegisterType<IRegistracionBusiness, RegistracionBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
                }
                ); 
            #endregion
        }

        public void Dispose()
        {
            DependencyFactory.ClearContainer();
        }
    }
}
