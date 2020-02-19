using Forum.DataLayer.Interfaces;
using Forum.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Forum.Repository.DataLayer
{
    public class CategoryRepository : AdoRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(string connectionString) : base(connectionString)
        {
        }

        #region Get
        public List<Category> GetAll()
        {
            // TODO: Make this escaped
            using (var command = new SqlCommand("SELECT * FROM Categories"))
            {
                return GetRecords(command).ToList();
            }
        }

        public Category GetById(string id)
        {
            using (var command = new SqlCommand("SELECT * FROM Categories WHERE CategoryID = @id"))
            {
                command.Parameters.AddWithValue("@id", id);
                return GetRecord(command);
            }
        }
        #endregion

        public override Category PopulateRecord(SqlDataReader reader)
        {
            return new Category
            {
                CategoryID = reader.GetInt32(1),
                CategoryName = reader.GetString(2),
                Description = reader.GetString(3)
            };
        }
 
    }
}
