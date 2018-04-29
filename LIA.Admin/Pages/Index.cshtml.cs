using System.Linq;
using LIA.Data.Data.Entities;
using LIA.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages
{
    [Authorize(Roles ="Admin")]

    public class IndexModel : PageModel
    {
        //public string text;
		IDbReader _reader;
     
        public IndexModel(IDbReader reader)
        {
          _reader = reader;
        }

        public void OnGet()
        {
            var counter = Count();
            ViewData["itemCounter"] = counter.itemCount;
            ViewData["itemTypeCounter"] = counter.itemTypeCount;
            ViewData["moduleCounter"] = counter.moduleCount;
            ViewData["courseCounter"] = counter.courseCount;
            ViewData["authorCounter"] = counter.authorCount;
            ViewData["ucCounter"] = counter.ucCount;
          
        }


        (int itemCount, int itemTypeCount, int courseCount, int ucCount, int moduleCount, int authorCount) Count()
        {
            return (itemCount: _reader.Get<Item>().Count(),
                    itemTypeCount: _reader.Get<ItemType>().Count(),
                    courseCount: _reader.Get<Course>().Count(),
                    moduleCount: _reader.Get<Module>().Count(),
                    authorCount: _reader.Get<Author>().Count(),
                    ucCount: _reader.Get<UserCourse>().Count());
        }
    }
}