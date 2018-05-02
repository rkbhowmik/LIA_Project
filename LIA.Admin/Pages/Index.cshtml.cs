using System.Linq;
using LIA.Admin.Services;
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
        private readonly IUserInfoService _db;
        public IndexModel(IDbReader reader, IUserInfoService db)
        {
          _reader = reader;
            _db = db;
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
            ViewData["userCounter"] = counter.userCount;
          
        }


        (int itemCount, int itemTypeCount, int courseCount, int ucCount, int moduleCount, int authorCount, int userCount) Count() => (
                    itemCount: _reader.Get<Item>().Count(),
                    itemTypeCount: _reader.Get<ItemType>().Count(),
                    courseCount: _reader.Get<Course>().Count(),
                    ucCount: _reader.Get<UserCourse>().Count(),
                    moduleCount: _reader.Get<Module>().Count(),
                    authorCount: _reader.Get<Author>().Count(),
                    userCount: _db.UserCount());
    }
}