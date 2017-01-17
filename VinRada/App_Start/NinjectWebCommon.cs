[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VinRada.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VinRada.App_Start.NinjectWebCommon), "Stop")]

namespace VinRada.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using BLL;
    using BLL.Interfaces;
    using DAL;
    using System.Web.Http;
    using System.Collections.Generic;
    using Ninject.Parameters;
    using Ninject.Syntax;
    using System.Web.Http.Dependencies;
    using System.Linq;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterWithWebApi(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        #region WebAPi
        public class NinjectWebApiResolver : NinjectScope, System.Web.Http.Dependencies.IDependencyResolver
        {
            private readonly IKernel _kernel;
            public NinjectWebApiResolver(IKernel kernel)
                : base(kernel)
            {
                _kernel = kernel;
            }
            public IDependencyScope BeginScope()
            {
                return new NinjectScope(_kernel.BeginBlock());
            }
        }

        public class NinjectScope : System.Web.Http.Dependencies.IDependencyScope
        {
            protected IResolutionRoot resolutionRoot;
            public NinjectScope(IResolutionRoot kernel)
            {
                resolutionRoot = kernel;
            }
            public object GetService(Type serviceType)
            {
                Ninject.Activation.IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
                return resolutionRoot.Resolve(request).SingleOrDefault();
            }
            public IEnumerable<object> GetServices(Type serviceType)
            {
                Ninject.Activation.IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
                return resolutionRoot.Resolve(request).ToList();
            }
            public void Dispose()
            {
                IDisposable disposable = (IDisposable)resolutionRoot;
                if (disposable != null) disposable.Dispose();
                resolutionRoot = null;
            }
        }

        static void RegisterWithWebApi(IKernel kernel)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectWebApiResolver(kernel);
        }
        #endregion
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind<IArticlesService>().To<ArticlesService>().InRequestScope();
            kernel.Bind<IContactsService>().To<ContactsService>().InRequestScope();
            kernel.Bind<IMainInfoService>().To<MainInfoService>().InRequestScope();
            kernel.Bind<IMappingService>().To<MappingService>().InRequestScope();
            kernel.Bind<INewsService>().To<NewsService>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}
