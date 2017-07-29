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
       
        private ConfigAll()
        {
        }

        private static ConfigAll instance = null;
        // Propiedad para acceder a la instancia
        public static ConfigAll Instance
        {
            get
            {
                return instance ?? new ConfigAll();
            }
        }
        public bool IsClearContainer
        {
            get { return DependencyFactory.IsClearContainer; }
        }
        public void Init()
        {
            #region DataAccess
            DependencyFactory.RegisterType<IUsuarioDA, UsuarioDA>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
                }
                );
            DependencyFactory.RegisterType<IJugadorDA, JugadorDA>(
             new InjectionMember[]
             {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
             }
             );

            #region genericos
            DependencyFactory.RegisterType<IBaseDA<Antecedente>, BaseDA<Antecedente>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<DatosPersona>, BaseDA<DatosPersona>>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
                }
                );
            DependencyFactory.RegisterType<IBaseDA<Deporte>, BaseDA<Deporte>>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
                }
                );
            DependencyFactory.RegisterType<IBaseDA<Evaluacion>, BaseDA<Evaluacion>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<EvaluacionCabecera>, BaseDA<EvaluacionCabecera>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<EvaluacionDetalle>, BaseDA<EvaluacionDetalle>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Jugador>, BaseDA<Jugador>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Puesto>, BaseDA<Puesto>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TemplateEvaluacion>, BaseDA<TemplateEvaluacion>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TemplateEvaluacionDetalle>, BaseDA<TemplateEvaluacionDetalle>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TipoUsuario>, BaseDA<TipoUsuario>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TipoVideo>, BaseDA<TipoVideo>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Usuario>, BaseDA<Usuario>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<UsuarioAplicativo>, BaseDA<UsuarioAplicativo>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Video>, BaseDA<Video>>(
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TipoEvaluacion>, BaseDA<TipoEvaluacion>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Entrenador>, BaseDA<Entrenador>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Intermediario>, BaseDA<Intermediario>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Club>, BaseDA<Club>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<ClubDetalle>, BaseDA<ClubDetalle>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<LogActividad>, BaseDA<LogActividad>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
              }
              );
            DependencyFactory.RegisterType<IBaseDA<LogError>, BaseDA<LogError>>(
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
              }
              );
            #endregion
            #endregion

            #region Business
            DependencyFactory.RegisterType<ILoginBusiness, LoginBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<IUsuarioBusiness, UsuarioBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<ICommonBusiness, CommonBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<IBusquedaBusiness, BusquedaBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<IUsuarioJugadorBusiness, UsuarioJugadorBusiness>(
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                ); 
            #endregion
        }

        public void Dispose()
        {
            DependencyFactory.ClearContainer();
            instance = null;
        }
    }
}
