using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;
using Task_PurpleBuzz.ViewModels.Home;

namespace Task_PurpleBuzz.Controllers
{
    public class HomeController : Controller
    {
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var serviceComponent = _context.ServiceComponents.FirstOrDefault(sc => !sc.IsDeleted);
            var homeSlider = _context.HomeSliders.Include(hsi => hsi.HomeSliderInfos).FirstOrDefault(hs => hs.IsActive);

            var model = new HomeIndexVM
            {
                HomeSlider = homeSlider,
                ServiceComponent = serviceComponent
            };

            return View(model);
        }
    }
}
