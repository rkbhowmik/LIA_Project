using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data;
using LIA.Data.Data.Entities;
using LIA.Data.Services;

namespace LIA.Admin.Pages.ItemTypes
{
    public class IndexModel : PageModel
    {
        private readonly IDbReader _db;

        public IndexModel(IDbReader db)
        {
            _db = db;
        }

        public IEnumerable<ItemType> ItemType { get;set; }

        public void OnGet()
        {
            ItemType = _db.GetWithIncludes<ItemType>();
        }
    }
}
