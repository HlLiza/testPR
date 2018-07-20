using Ninject.Modules;
using RentalHousingService.DAL.Interfaces;
using RentalHousingService.DAL.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace RentalHousingService.BLL.DI
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public static object ConfigurationManager { get; private set; }

        public override void Load()
        {
            Bind<IDbConnection>().To<SqlConnection>().WithConstructorArgument("connectionString", connectionString);
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
