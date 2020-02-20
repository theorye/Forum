using Forum.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.AspServer.Services.Interfaces
{
    public interface IForumService
    {
        List<ForumModel> GetAll();
        ForumModel GetById(int ID);
        void Create(ForumModel forum, IFormFileCollection files);
        void Update(ForumModel forum);
        void Delete(int id);
    }
}
