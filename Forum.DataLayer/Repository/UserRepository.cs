using Forum.DataLayer.Interfaces;
using Forum.Domain;
using Forum.Repository.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Forum.DataLayer.Repository
{
    public class UserRepository : AdoRepository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public void Create(User user)
        {
            using (var command = new SqlCommand(@"
                INSERT INTO[dbo].[Users] 
                (
                    [Username]
                    , [PasswordHash]
                    , [PasswordSalt]
                ) 
                VALUES(
                    @Username
                    , @PasswordHash
                    , @PasswordSalt
                );"
))
            {
                command.Parameters.AddWithValue("@Username", user.Username);
                SqlParameter passParam = command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                passParam.DbType = DbType.Binary;
                SqlParameter saltParam = command.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
                saltParam.DbType = DbType.Binary;
                ExecuteNonQuery(command);
            }
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            using (var command = new SqlCommand(@"
                SELECT
                [Id]
                ,[Username]
                FROM[dbo].[Users]"
            ))
            {
                return GetRecords(command).ToList();
            }
        }

        public User GetById(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public override User PopulateRecord(SqlDataReader reader)
        {

            return new User
            {
                ID = reader.GetInt32(0),
                Username = reader.GetString(1)                
            };
        }
    }
}
