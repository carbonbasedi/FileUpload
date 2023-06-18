using Microsoft.AspNetCore.Mvc;
using System;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;
using Task_PurpleBuzz.ViewModels.About;

namespace Task_PurpleBuzz.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var aboutBannerComponent =  _context.AboutBannerComponent.FirstOrDefault();
            var teamMembers = _context.TeamMembers.Where(tm => !tm.IsDeleted).ToList();


            var model = new AboutIndexVM
            {
                TeamMembers = teamMembers,
                AboutBannerComponent = aboutBannerComponent
            };

            return View(model);
        }
    }
}
