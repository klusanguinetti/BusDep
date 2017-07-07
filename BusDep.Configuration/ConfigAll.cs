namespace BusDep.Configuration
{
    using System;
    using BusDep.Business;
    using BusDep.IBusiness;
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
            DependencyFactory.RegisterType<IJugadorDA, JugadorDA>(
             new InjectionMember[]
             {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
             }
             );

            #region genericos
            DependencyFactory.RegisterType<IBaseDA<Antecedente>, CommonDA<Antecedente>>(
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
            DependencyFactory.RegisterType<IBaseDA<Deporte>, CommonDA<Deporte>>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
                }
                );
            DependencyFactory.RegisterType<IBaseDA<Evaluacion>, CommonDA<Evaluacion>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<EvaluacionCabecera>, CommonDA<EvaluacionCabecera>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<EvaluacionDetalle>, CommonDA<EvaluacionDetalle>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Jugador>, CommonDA<Jugador>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Puesto>, CommonDA<Puesto>>(
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
            DependencyFactory.RegisterType<IBaseDA<TemplateEvaluacionDetalle>, CommonDA<TemplateEvaluacionDetalle>>(
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
            DependencyFactory.RegisterType<IBaseDA<TipoVideo>, CommonDA<TipoVideo>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Usuario>, CommonDA<Usuario>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<UsuarioAplicativo>, CommonDA<UsuarioAplicativo>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Video>, CommonDA<Video>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TipoEvaluacion>, CommonDA<TipoEvaluacion>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Entrenador>, CommonDA<Entrenador>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Intermediario>, CommonDA<Intermediario>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Club>, CommonDA<Club>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
              }
              );
            #endregion
            #endregion

            #region Business
            DependencyFactory.RegisterType<ILoginBusiness, LoginBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
                }
                );
            DependencyFactory.RegisterType<IUsuarioBusiness, UsuarioBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
                }
                );
            DependencyFactory.RegisterType<ICommonBusiness, CommonBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
                }
                );
            DependencyFactory.RegisterType<IBusquedaBusiness, BusquedaBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBase>()
                }
                );
            DependencyFactory.RegisterType<IUsuarioJugadorBusiness, UsuarioJugadorBusiness>(
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
