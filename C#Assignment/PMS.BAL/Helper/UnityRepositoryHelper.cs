using PMS.DAL.Repository.Classes;
using PMS.DAL.Repository.Interface;
using Unity;
using Unity.Extension;

namespace PMS.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            {
                Container.RegisterType<IUserRepository, UserRepository>();
                Container.RegisterType<IProductRepository, ProductRepository>();
                Container.RegisterType<ICategoryReposiory, CategoryRepository>();

            }
        }
    }
}
