using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

    }
}
