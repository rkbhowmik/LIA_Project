using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Data.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string URL { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }
        //public List<ItemType> ItemTypes { get; set; }
    }
}
