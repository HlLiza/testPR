using Dapper;
using RentalHousingService.DAL.Interfaces;
using RentalService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHousingService.DAL.Repositories
{

    public class UserRepository : RepositoryBase, IUserRepository
        {
            public UserRepository(IDbTransaction transaction) : base(transaction) { }


            public async Task<int?> Add(User entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("user");
                }

                var a = await Connection.QueryAsync<int>(
                    "INSERT INTO User(Id, TypeUser, Name, Surname, Language, PasswordHash, Salt) " +
                    "VALUES (@Id, @TypeUser, @Name, @Surname, @Language, @PasswordHash, @Salt); SELECT SCOPE_IDENTITY()",
                    param: new { entity.Id, entity.TypeUser, entity.Name, entity.Surname, entity.Language, entity.PasswordHash, entity.Salt },
                    transaction: Transaction
                    );
                return a.Single();
            }

            public async Task<int?> Delete(User entity)
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                return await Connection.ExecuteAsync(
                    "DELETE FROM User WHERE Id = @Id",
                    param: new { entity.Id },
                    transaction: Transaction
                );
            }

            public async Task<int?> Edit(User entity)
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                return await Connection.ExecuteAsync(
                     "UPDATE User SET Id = @Id, TypeUser = @TypeUser, Name = @Name, Surname = @Surname," +
                     "Language = @Language, PasswordHash = @PasswordHash, Salt = @Salt  WHERE Id = @Id",
                     param: new { entity.Id, entity.TypeUser, entity.Name, entity.Surname, entity.Language, entity.PasswordHash, entity.Salt },
                     transaction: Transaction
                 );
            }

            public async Task<User> FindById(int id)
            {
                var user = await Connection.QueryAsync<User>(
                    sql: "SELECT * FROM User WHERE Id = @Id",
                    param: new { Id = id },
                    transaction: Transaction);
                return user.FirstOrDefault();
            }

            public async Task<IEnumerable<User>> GetAll()
            {
                return await Connection.QueryAsync<User>(
                  sql: "SELECT * FROM User",
                  transaction: Transaction);
            }



            public async Task<IEnumerable<User>> FindUsersByType(int typeUser)
            {
                return await Connection.QueryAsync<User>(
                    "SELECT * FROM User WHERE TypeUser = @TypeUser",
                    param: new { TypeUser = typeUser },
                    transaction: Transaction
                );

            }

            public async Task<User> FindUserByLogin(string login)
            {
                var user = await Connection.QueryAsync<User>(
                    sql: "SELECT * FROM User WHERE Login=@Login",
                    param: new { Login = login },
                    transaction: Transaction
                );
                return user.FirstOrDefault();
            }


        }
    }
