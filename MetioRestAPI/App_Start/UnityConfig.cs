using BS.Concrete;
using BS.Interface;
using DAL.Concrete;
using DAL.Interface;
using System;

using Unity;
using Unity.Injection;

namespace MetioRestAPI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            //container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            string conn = "Server=; Database =;Uid=;Pwd=;";
            
            container.RegisterType<IClientDal, ClientDal>(new InjectionConstructor(conn))
                .RegisterType<IDeviceDal, DeviceDal>(new InjectionConstructor(conn))
                .RegisterType<IPermissionDal, PermissionDal>(new InjectionConstructor(conn))
                .RegisterType<IRoleDal, RoleDal>(new InjectionConstructor(conn))
                .RegisterType<ITokenDal, TokenDal>(new InjectionConstructor(conn));

            container.RegisterType<IAuthManager, AuthManager>()
                .RegisterType<ITokenManager, TokenManager>()
                .RegisterType<IClientInfoManager, ClientInfoManager>()
                .RegisterType<IClientManager, ClientManager>();

        }
    }
}