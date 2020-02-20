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
            using (var command = new SqlCommand(@"
                SELECT
                [CategoryId]
                , [CategoryName]
                , ISNULL([Description], '')
                , [CreatedOn]
                , [UpdatedOn]
                FROM Categories"
            ))
            {
                return GetRecords(command).ToList();
            }
        }

        public Category GetById(int ID)
        {
            using (var command = new SqlCommand(@"
                SELECT
                [CategoryId]
                , [CategoryName]
                , ISNULL([Description], '')
                , [CreatedOn]
                , [UpdatedOn]
                FROM Categories WHERE CategoryID = @ID"))
            {
                command.Parameters.AddWithValue("@ID", ID);
                return GetRecord(command);
            }
        }
        #endregion

        #region Create
        public void Create(Category category)
        {
            using (var command = new SqlCommand(@"
                INSERT INTO[dbo].[Categories]([CategoryName]) VALUES(@CategoryName);"
            ))
            {
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                ExecuteNonQuery(command);
            }
        }
        #endregion

        public void Update(Category category)
        {
            using (var command = new SqlCommand(@"
                UPDATE [dbo].[Categories] 
                SET [CategoryName] = @CategoryName 
                WHERE [CategoryID] = @CategoryID"
            ))
            {
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                ExecuteNonQuery(command);
            }
        }

        public void Delete(int ID)
        {
            using (var command = new SqlCommand(@"
               DELETE FROM[dbo].[Categories] WHERE[CategoryID] = @CategoryID"
            ))
            {
                command.Parameters.AddWithValue("@CategoryID", ID);
                ExecuteNonQuery(command);
            }
        }

        public override Category PopulateRecord(SqlDataReader reader)
        {

            return new Category
            {
                CategoryID = reader.GetInt32(0),
                CategoryName = reader.GetString(1),
                Description = reader.GetString(2)
            };
        }
 
    }
}
