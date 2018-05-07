using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Data.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Display(Name= "Author Name")]
        public string Name { get; set; }
        public string Details { get; set; }
        [Display(Name="Author Image")]
        public string ImageUrl { get; set; }

        //public List<Course> Courses { get; set; }

    }
}
