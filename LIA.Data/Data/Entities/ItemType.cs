using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Data.Entities
{
    public class ItemType
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //public int ItemId { get; set; }
        //public Item Item { get; set; }
    }
}
