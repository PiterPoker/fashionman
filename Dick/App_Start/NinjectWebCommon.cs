using System;
using System.Web;
using Dick.App_Start;
using Dick.Models.Client;
using Dick.Models.DAO;
using Dick.Models.DAO.Client;
using Dick.Models.DAO.Cloth;
using Dick.Models.DAO.ClothingPattern;
using Dick.Models.DAO.Cutter;
using Dick.Models.DAO.Order;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof (NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof (NinjectWebCommon), "Stop")]

namespace Dick.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof (OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof (NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IClientService>().To<ClientService>();
            kernel.Bind<IClientDao>().To<ClientDao>();
            kernel.Bind<IClothDao>().To<ClothDao>();
            kernel.Bind<IClothingPatterDao>().To<ClothingPatterDao>();
            kernel.Bind<ICutterDao>().To<CutterDao>();
            kernel.Bind<IOrderDao>().To<OrderDao>();
            kernel.Bind<IUserDao>().To<UserDao>();
        }
    }
}