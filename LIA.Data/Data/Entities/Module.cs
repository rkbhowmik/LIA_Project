﻿using System;
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

        [Display(Name = "Module Title")]
        public string Title { get; set; }

        public List<Item> Items { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
