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
            DependencyFactory.RegisterType<IUsuarioDA, UsuarioDA>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
                }
                );
            DependencyFactory.RegisterType<IJugadorDA, JugadorDA>(new PerThreadLifetimeManager(),
             new InjectionMember[]
             {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
             }
             );
            DependencyFactory.RegisterType<ICommnDA, CommnDA>(new PerThreadLifetimeManager(),
            new InjectionMember[]
            {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
            }
            );
            DependencyFactory.RegisterType<IEntrenadorDA, EntrenadorDA>(new PerThreadLifetimeManager(),
             new InjectionMember[]
             {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
             }
             );
            DependencyFactory.RegisterType<IEventoPublicidadDA, EventoPublicidadDA>(new PerThreadLifetimeManager(),
             new InjectionMember[]
             {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
             }
             );
            
            #region genericos
            DependencyFactory.RegisterType<IBaseDA<Antecedente>, BaseDA<Antecedente>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<DatosPersona>, BaseDA<DatosPersona>>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
                }
                );
            DependencyFactory.RegisterType<IBaseDA<Deporte>, BaseDA<Deporte>>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
                }
                );
            DependencyFactory.RegisterType<IBaseDA<Evaluacion>, BaseDA<Evaluacion>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<EvaluacionCabecera>, BaseDA<EvaluacionCabecera>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<EvaluacionDetalle>, BaseDA<EvaluacionDetalle>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Jugador>, BaseDA<Jugador>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Puesto>, BaseDA<Puesto>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TemplateEvaluacion>, BaseDA<TemplateEvaluacion>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TemplateEvaluacionDetalle>, BaseDA<TemplateEvaluacionDetalle>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TipoUsuario>, BaseDA<TipoUsuario>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TipoVideo>, BaseDA<TipoVideo>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Usuario>, BaseDA<Usuario>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<UsuarioAplicativo>, BaseDA<UsuarioAplicativo>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<Video>, BaseDA<Video>>(new PerThreadLifetimeManager(),
               new InjectionMember[]
               {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
               }
               );
            DependencyFactory.RegisterType<IBaseDA<TipoEvaluacion>, BaseDA<TipoEvaluacion>>(new PerThreadLifetimeManager(),
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Entrenador>, BaseDA<Entrenador>>(new PerThreadLifetimeManager(),
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Intermediario>, BaseDA<Intermediario>>(new PerThreadLifetimeManager(),
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Club>, BaseDA<Club>>(new PerThreadLifetimeManager(),
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<ClubDetalle>, BaseDA<ClubDetalle>>(new PerThreadLifetimeManager(),
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorDataAccess>()
              }
              );
            DependencyFactory.RegisterType<IBaseDA<LogActividad>, BaseDA<LogActividad>>(new PerThreadLifetimeManager(),
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
              }
              );
            DependencyFactory.RegisterType<IBaseDA<LogError>, BaseDA<LogError>>(new PerThreadLifetimeManager(),
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
              }
              );
            DependencyFactory.RegisterType<IBaseDA<RecuperoUsuario>, BaseDA<RecuperoUsuario>>(new PerThreadLifetimeManager(),
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Recomendacion>, BaseDA<Recomendacion>>(new PerThreadLifetimeManager(),
              new InjectionMember[]
              {
                    new Interceptor<VirtualMethodInterceptor>(),
              }
              );
            DependencyFactory.RegisterType<IBaseDA<Publicidad>, BaseDA<Publicidad>>(new PerThreadLifetimeManager(),
             new InjectionMember[]
             {
                    new Interceptor<VirtualMethodInterceptor>(),
             }
             );
            DependencyFactory.RegisterType<IBaseDA<EventoPublicidad>, BaseDA<EventoPublicidad>>(new PerThreadLifetimeManager(),
             new InjectionMember[]
             {
                    new Interceptor<VirtualMethodInterceptor>(),
             }
             );
            #endregion
            #endregion

            #region Business
            DependencyFactory.RegisterType<ILoginBusiness, LoginBusiness>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<IUsuarioBusiness, UsuarioBusiness>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<ICommonBusiness, CommonBusiness>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<IBusquedaBusiness, BusquedaBusiness>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<IUsuarioJugadorBusiness, UsuarioJugadorBusiness>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<IUsuarioEntrenadorBusiness, UsuarioEntrenadorBusiness>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<IBackOfficeBusiness, BackOfficeBusiness>(new PerThreadLifetimeManager(),
                new InjectionMember[]
                {
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<InterceptorBusiness>()
                }
                );
            DependencyFactory.RegisterType<IBackOfficeLoginBusiness, BackOfficeLoginBusiness>(new PerThreadLifetimeManager(),
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
