using BLL.Interface.Services;
using BLL.Interfacies.Services;
using BLL.Services;
using Ninject.Modules;

namespace WebApplication.Infrastructure
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IImageService>().To<ImageService>();
            Bind<ILikeService>().To<LikeService>();
        }
    }
}