using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Domain
{
    public class ForumModel
    {
        public int ForumID { get; set; }
        [Required]
        public string ForumName { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ForumImageURL { get; set; }
    }
}
