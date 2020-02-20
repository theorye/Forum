using Forum.AspServer.Models;
using Forum.AspServer.Services.Interfaces;
using Forum.DataLayer.Interfaces;
using Forum.DataLayer.Repository;
using Forum.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.AspServer.Services
{
    public class ForumService : IForumService
    {
        private readonly IForumRepository _repository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ForumService(IWebHostEnvironment hostingEnvironment, IOptions<DataConnection> options)
        {
            DataConnection connection = options.Value;
            _repository = new ForumRepository(connection.DefaultConnection);
            _hostingEnvironment = hostingEnvironment;

        }

        public void Create(ForumModel forum, IFormFileCollection files)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            if (files.Count > 0)
            {
                // files has been asked to be uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, forum.ForumName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                forum.ForumImageURL = @$"\images\{forum.ForumName}{extension}";

            }
            else
            {
                // no file was uploaded, so use the default
                var uploads = Path.Combine(webRootPath, @"images\default_forum.png");
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + forum.ForumName + ".png");
                forum.ForumImageURL = @$"\images\{forum.ForumName}.png";
            }

            _repository.Create(forum);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ForumModel> GetAll()
        {
            return _repository.GetAll();
        }

        public ForumModel GetById(int ID)
        {

            return _repository.GetById(ID);
        }

        public void Update(ForumModel forum)
        {
            _repository.Update(forum);
        }
    }
}
