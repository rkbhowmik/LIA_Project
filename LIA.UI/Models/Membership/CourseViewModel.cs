using LIA.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.UI.Models.Membership
{
    public class CourseViewModel
    {
        public Course Course { get; set; }

        public List<Item> Items { get; set; }
    }
}
