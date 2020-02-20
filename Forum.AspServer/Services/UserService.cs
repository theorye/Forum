using Forum.AspServer.Models;
using Forum.AspServer.Services.Interfaces;
using Forum.DataLayer.Repository;
using Forum.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.AspServer.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(IOptions<DataConnection> options)
        {
            DataConnection connection = options.Value;
            _repository = new UserRepository(connection.DefaultConnection);

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public void Create(UserCreateModel user)
        {
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User dbUser = new User
            {
                Username = user.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _repository.Create(dbUser);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int ID)
        {
            return _repository.GetById(ID);
        }

        public void Update(User user)
        {
            _repository.Update(user);
        }
    }
}
