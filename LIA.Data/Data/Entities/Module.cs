using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Data.Entities
{
    public class Module
    {
        public int Id { get; set; }

        //public List<Item> Items { get; set; }

        public Course CourseId { get; set; }

        public Course Course { get; set; }
    }
}
