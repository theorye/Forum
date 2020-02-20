using Forum.Domain;
using System.Collections.Generic;

namespace Forum.AspServer.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int ID);
        void Create(Category category);
        void Update(Category category);
        void Delete(int ID);

    }
}
