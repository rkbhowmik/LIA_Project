using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LIA.Data.Data.Entities;
using LIA.Data.Services;

namespace LIA.Admin.Pages.Items
{
    public class IndexModel : PageModel
    {
        IDbReader _db;
        public IEnumerable<Item> Item { get; set; }

        public IndexModel(IDbReader db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Item = _db.GetWithIncludes<Item>();
        }
    }
}
