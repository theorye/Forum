using System;
using System.Collections.Generic;
using System.Text;
using Forum.Domain;

namespace Forum.DataLayer.Interfaces
{
    public interface IForumRepository
    {
        List<ForumModel> GetAll();
        ForumModel GetById(int ID);
        void Create(ForumModel forum);
        void Update(ForumModel forum);
        void Delete(int ID);
    }
}
