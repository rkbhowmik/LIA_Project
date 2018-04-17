﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        //public List<Module> Modules { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
