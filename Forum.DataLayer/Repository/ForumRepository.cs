using Forum.DataLayer.Interfaces;
using Forum.Domain;
using Forum.Repository.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Forum.DataLayer.Repository
{
    public class ForumRepository : AdoRepository<ForumModel>, IForumRepository
    {
        public ForumRepository(string connectionString) : base(connectionString)
        {
        }

        public void Create(ForumModel forum)
        {
            using (var command = new SqlCommand(@"
                INSERT INTO[dbo].[Forums] 
                (
                    [ForumName]
                    ,[Description]
                    ,[CategoryID]
                    ,[ForumImageURL]
                ) 
                VALUES(
                    @ForumName
                    , @Description
                    , @ForumCategoryID
                    , @ForumImageURL
                );"
            ))
            {
                command.Parameters.AddWithValue("@ForumName", forum.ForumName);
                command.Parameters.AddWithValue("@Description", forum.Description);
                command.Parameters.AddWithValue("@ForumCategoryID", forum.CategoryID);
                command.Parameters.AddWithValue("@ForumImageURL", forum.ForumImageURL);
                ExecuteNonQuery(command);
            }
        }

        public void Delete(int ID)
        {
            using (var command = new SqlCommand(@"
               DELETE FROM[dbo].[Forums] WHERE[ForumID] = @ForumID"
            ))
            {
                command.Parameters.AddWithValue("@ForumID", ID);
                ExecuteNonQuery(command);
            }
        }

        public List<ForumModel> GetAll()
        {
            using (var command = new SqlCommand(@"
                SELECT
                [f].[ForumID]
                , [f].[ForumName]
                , ISNULL([f].[Description], '')
                , [f].[CategoryID]
                , [c].[CategoryName]
                , [f].[ForumImageURL]
                FROM[dbo].[Forums] f
                INNER JOIN[dbo].[Categories] c ON c.CategoryID = f.CategoryID"
            ))
            {
                return GetRecords(command).ToList();
            }
        }

        public ForumModel GetById(int ID)
        {
            using (var command = new SqlCommand(@"
                SELECT
                [f].[ForumID]
                , [f].[ForumName]
                , ISNULL([f].[Description], '')
                , [f].[CategoryID]
                , [c].[CategoryName]
                , [f].[ForumImageURL]
                FROM[dbo].[Forums] f
                INNER JOIN[dbo].[Categories] c ON c.CategoryID = f.CategoryID
                WHERE [f].[ForumID] = @ID"
            ))
            {
                command.Parameters.AddWithValue("@ID", ID);
                return GetRecord(command);
            }
        }

        public void Update(ForumModel forum)
        {
            using(var command = new SqlCommand(@"
                UPDATE [dbo].[Forums]
                SET 
                [ForumName] = @ForumName
                , [CategoryID] = @CategoryID
                , [Description] = @Description
            "))
            {
                command.Parameters.AddWithValue("@ForumName", forum.ForumName);
                command.Parameters.AddWithValue("@CategoryID", forum.CategoryID);
                command.Parameters.AddWithValue("@Description", forum.Description);
                ExecuteNonQuery(command);
            }
        }

        public override ForumModel PopulateRecord(SqlDataReader reader)
        {
            return new ForumModel
            {
                ForumID = reader.GetInt32(0),
                ForumName = reader.GetString(1),
                Description = reader.GetString(2),
                CategoryID = reader.GetInt32(3),
                CategoryName = reader.GetString(4),
            };
        }
    }
}
