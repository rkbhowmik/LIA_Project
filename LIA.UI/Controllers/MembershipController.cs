using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Data.Data.Entities;
using LIA.Data.Services;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}