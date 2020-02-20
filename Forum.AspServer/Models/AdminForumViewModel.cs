using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.AspServer.Models
{
    public class AdminForumViewModel
    {
        public ForumModel Forum { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
