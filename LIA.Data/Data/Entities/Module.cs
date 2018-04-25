using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Data.Entities
{
    public class Module
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        //public List<Item> Items { get; set; }

        public Course CourseId { get; set; }

        public Course Course { get; set; }
    }
}
