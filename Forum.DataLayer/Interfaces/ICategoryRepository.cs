using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.DataLayer.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(string id);
    }
}
