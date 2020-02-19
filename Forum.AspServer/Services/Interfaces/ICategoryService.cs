using Forum.Domain;
using System.Collections.Generic;

namespace Forum.AspServer.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(string id);
    }
}
