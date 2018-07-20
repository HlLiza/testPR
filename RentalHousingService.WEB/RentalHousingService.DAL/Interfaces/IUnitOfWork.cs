using System;

namespace RentalHousingService.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository UserRepository { get; }

        void Commit();
    }
}
