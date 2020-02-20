using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.DataLayer.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int ID);
        void Create(User user);
        void Update(User user);
        void Delete(int ID);
    }
}
