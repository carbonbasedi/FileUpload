using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Task_PurpleBuzz.Areas.Admin.ViewModels.HomeSlider;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeSliderController : Controller
	{
		private readonly AppDbContext _context;

		public HomeSliderController(AppDbContext context)
		{
			_context = context;
		}

		#region Index
		[HttpGet]
		public IActionResult Index()
		{
			var homeSliders = _context.HomeSliders.Where(w => !w.IsDeleted).ToList();

			var model = new HomeSliderIndexVM
			{
				HomeSliders = homeSliders,
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
		public IActionResult Create(HomeSliderCreateVM model)
		{

			if (!ModelState.IsValid) return View();

			var homeSlider = new HomeSlider
			{
				Title = model.Title,
				CreatedAt = DateTime.Now,
			};

			_context.HomeSliders.Add(homeSlider);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion

		#region Details
		public IActionResult Details(int id)
		{
			var homeSlider = _context.HomeSliders.Include(w => w.HomeSliderInfos.Where(w => !w.IsDeleted)).FirstOrDefault(w => w.Id == id && !w.IsDeleted);
			if (homeSlider == null) return NotFound();

			var model = new HomeSliderDetailsVM
			{
				Title = homeSlider.Title,
				CreatedAt = homeSlider.CreatedAt,
				ModifiedAt = homeSlider.ModifiedAt,
				homeSliderInfos = homeSlider.HomeSliderInfos.ToList(),
			};
			return View(model);
		}
		#endregion

		#region Update
		[HttpGet]
		public IActionResult Update(int id)
		{
			if (!ModelState.IsValid) return View();

			var homeSlider = _context.HomeSliders.FirstOrDefault(h => h.Id == id && !h.IsDeleted);
			if (homeSlider is null) return NotFound();

			var model = new HomeSliderUpdateVM
			{
				Title = homeSlider.Title,
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult Update(int id, HomeSliderUpdateVM model)
		{
			if (!ModelState.IsValid) return View();

			var homeSlider = _context.HomeSliders.FirstOrDefault(hs => !hs.IsDeleted && hs.Id == id);
			if (homeSlider is null) return NotFound();

			homeSlider.Title = model.Title;
			homeSlider.ModifiedAt = DateTime.Now;

			_context.HomeSliders.Update(homeSlider);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion

		#region Delete
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var homeSlider = _context.HomeSliders.FirstOrDefault(hm => hm.Id == id);
			if (homeSlider is null) return NotFound();

			homeSlider.IsDeleted = true;
			homeSlider.IsActive = false;
			homeSlider.DeletedAt = DateTime.Now;

			_context.HomeSliders.Update(homeSlider);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion

		#region Activate
		[HttpGet]
		public IActionResult Activate(int id)
		{
			var homeSlider = _context.HomeSliders.FirstOrDefault(hs => hs.Id == id && !hs.IsDeleted);
			if (homeSlider is null) return NotFound();

			var dbHomeSliders = _context.HomeSliders.Where(hs => hs.Id != homeSlider.Id);

			if (!homeSlider.IsActive)
			{
				foreach (var dbHomeSlider in dbHomeSliders)
				{
					dbHomeSlider.IsActive = false;
					_context.HomeSliders.Update(dbHomeSlider);
				}
				_context.SaveChanges();
			}

			homeSlider.IsActive = !homeSlider.IsActive;
			homeSlider.ModifiedAt = DateTime.Now;

			_context.HomeSliders.Update(homeSlider);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion
	}
}
