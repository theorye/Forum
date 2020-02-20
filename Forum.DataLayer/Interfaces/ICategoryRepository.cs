using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.DataLayer.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int ID);
        void Create(Category category);
        void Update(Category category);
        void Delete(int ID);
    }
}
