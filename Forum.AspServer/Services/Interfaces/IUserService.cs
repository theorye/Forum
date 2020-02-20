using Forum.AspServer.Models;
using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.AspServer.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int ID);
        void Create(UserCreateModel user);
        void Update(User user);
        void Delete(int id);
    }
}
