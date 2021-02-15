using PMS.BAL.Classes;
using PMS.BAL.Helper;
using PMS.BAL.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ProductsApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IUser, UserManager>();
            container.RegisterType<IProduct, ProductManager>();
            container.RegisterType<ICategory, CategoryManager>();
            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}