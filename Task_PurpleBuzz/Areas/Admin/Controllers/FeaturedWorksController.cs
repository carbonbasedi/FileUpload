using Microsoft.AspNetCore.Mvc;
using Task_PurpleBuzz.Areas.Admin.ViewModels.FeaturedWorksComponent;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeaturedWorksController : Controller
	{
		private readonly AppDbContext _context;

		public FeaturedWorksController(AppDbContext context) 
		{
			_context = context;
		}

		#region Index
		[HttpGet]
		public IActionResult Index()
		{
			var featuredWorkComponents = _context.FeaturedWorkComponents.ToList();

			var model = new FeaturedWorksIndexVM
			{
				FeaturedWorkComponents = featuredWorkComponents
			};
			return View(model);
		}
		#endregion

		#region Create
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(FeaturedWorksCreateVM model)
		{
			if (!ModelState.IsValid) return View();

			var featuredWorksComponent = new FeaturedWorkComponent
			{
				Title = model.Title,
				Substring = model.Substring,
				Description = model.Description,
			};

			var dbFeaturedWorksComponent = _context.FeaturedWorkComponents.FirstOrDefault(fwc => !fwc.IsDeleted);
			if (dbFeaturedWorksComponent != null)
			{
				dbFeaturedWorksComponent.IsDeleted = true;
				_context.FeaturedWorkComponents.Update(dbFeaturedWorksComponent);
			};

			_context.FeaturedWorkComponents.Add(featuredWorksComponent);
			_context.SaveChanges();

			return RedirectToAction("details", "featuredworks" , new {id = featuredWorksComponent.Id});
		}
		#endregion

		[HttpGet]
		public IActionResult Details(int id)
		{
			var featuredWorksComponent = _context.FeaturedWorkComponents.Find(id);

			var model = new FeaturedWorksDetailsVM
			{
				Title = featuredWorksComponent.Title,
				Substring = featuredWorksComponent.Substring,
				Description = featuredWorksComponent.Description,
			};

			return View(model);
		}
	}
}
