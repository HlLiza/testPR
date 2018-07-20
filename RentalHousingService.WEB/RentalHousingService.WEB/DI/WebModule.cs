using Ninject.Modules;
using RentalHousingService.BLL.Interfaces;
using RentalHousingService.BLL.Services;

namespace RentalHousingService.WEB.DI
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}