using Forum.AspServer.Models;
using Forum.AspServer.Services.Interfaces;
using Forum.DataLayer.Interfaces;
using Forum.Domain;
using Forum.Repository.DataLayer;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.AspServer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(IOptions<DataConnection> options)
        {
            var connection = options.Value;
            _repository = new CategoryRepository(connection.DefaultConnection);
        }
        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Create(Category category)
        {
            _repository.Create(category);
        }

        public void Update(Category category)
        {
            _repository.Update(category);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
