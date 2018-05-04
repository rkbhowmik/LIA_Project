using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Data.Data.Entities;
using LIA.Data.Services;
using LIA.UI.Models.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LIA.UI.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class MembershipController : Controller
    {
        private IDbReader _reader;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private string userId;

        public MembershipController(IDbReader reader, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _reader = reader;
            _userManager = userManager;
            _signInManager = signInManager;
            userId = _userManager.GetUserId(_signInManager.Context.User);
        }

        public IActionResult Dashboard()
        {
            var model = new DashboardViewModel();
            model.Courses = new List<List<Course>>();

            var courses = _reader.GetCourses(userId);

            var numberOfRows = courses.Count() <= 3 ? 1 :
                courses.Count() / 3;

            for (int i = 0; i < numberOfRows; i++)
            {
                model.Courses.Add(courses.Skip(i * 3).Take(3).ToList());
            }

            return View(model);
        }

        public IActionResult Course(int courseId)
        {
            var course = _reader.GetWithIncludes<Course>().FirstOrDefault(c => c.Id.Equals(courseId));

            // Comparing CourseId in the Module entity with the courseId parameter 
            var modules = _reader.GetWithIncludes<Module>().Where(m => m.CourseId.Equals(courseId));

            var model = new CourseViewModel { Course = course, Modules = modules.ToList() };
            return View(model);
        }
    }
}