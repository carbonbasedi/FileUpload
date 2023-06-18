using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.ViewModels.Work;

namespace Task_PurpleBuzz.Controllers
{
	public class WorkController : Controller
	{
		private readonly AppDbContext _context;

		public WorkController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
			var featuredWorksComponent = _context.FeaturedWorkComponents.FirstOrDefault(fwc => !fwc.IsDeleted);

			var workCategories = _context.WorkCategories
										.Include(x => x.Works.Where(wc => !wc.IsDeleted))
										.Where(wc => !wc.IsDeleted)
										.ToList();

			var model = new WorkIndexVM
			{
				FeaturedWorkComponent = featuredWorksComponent,
				WorkCategories = workCategories
			};
			return View(model);
		}
	}
}
