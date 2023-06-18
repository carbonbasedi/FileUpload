using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Task_PurpleBuzz.Areas.Admin.ViewModels.HomeSliderInfo;
using Task_PurpleBuzz.DAL;

namespace Task_PurpleBuzz.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeSliderInfoController : Controller
	{
		private readonly AppDbContext _context;

		public HomeSliderInfoController(AppDbContext context)
		{
			_context = context;
		}

		#region Index
		public IActionResult Index()
		{
			var model = new HomeSliderInfoIndexVM
			{
				HomeSliderInfos = _context.HomeSliderInfos.Include(hs => hs.HomeSlider).Where(hsi => !hsi.IsDeleted).ToList()
			};
			return View(model);
		}

		#endregion

		#region Create
		public IActionResult Create()
		{
			var model = new HomeSliderInfoCreateVM
			{
				SliderTitleList = _context.HomeSliders.Where(hsi => !hsi.IsDeleted).Select(hsi => new SelectListItem
				{
					Text = hsi.Title,
					Value = hsi.Id.ToString(),
				}).ToList()
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(HomeSliderInfoCreateVM model) 
		{
			model.SliderTitleList = _context.HomeSliders.Where(hsi => !hsi.IsDeleted).Select(hsi => new SelectListItem
			{
				Text=hsi.Title,
				Value = hsi.Id.ToString(),
			}).ToList();

			if (!ModelState.IsValid) return View(model);

			var infos = _context.HomeSliderInfos.FirstOrDefault(hsi => hsi.Title.Trim().ToLower() == model.Title.Trim().ToLower() &&
																		!hsi.IsDeleted);

			if(infos is not null)
			{
				ModelState.AddModelError("Title", "There is no slider title under this name");
				return View(model);
			}

			infos = new Models.HomeSliderInfo
			{
				Title = model.Title,
				Desc = model.Desc,
				HomeSliderId = model.HomeSliderId,
				CreatedAt = DateTime.Now,
			};

			_context.HomeSliderInfos.Add(infos);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion

		#region Update 

		[HttpGet]
		public IActionResult Update(int id)
		{
			var homeSliderInfo = _context.HomeSliderInfos.FirstOrDefault(hsi => hsi.Id == id && !hsi.IsDeleted);
			if (homeSliderInfo is null) return NotFound();

			var model = new HomeSliderInfoUpdateVM
			{
				Title = homeSliderInfo.Title,
				Desc = homeSliderInfo.Desc,
				SliderTitleList = _context.HomeSliders.Where(hsi => !hsi.IsDeleted).Select(hsi => new SelectListItem
				{
					Text = hsi.Title,
					Value = hsi.Id.ToString(),
				}).ToList(),
				HomeSliderId = homeSliderInfo.HomeSliderId,
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Update(int id, HomeSliderInfoUpdateVM model)
		{
			if (!ModelState.IsValid)
			{
				model.SliderTitleList = _context.HomeSliders.Where(hsi => !hsi.IsDeleted).Select(hsi => new SelectListItem
				{
					Text = hsi.Title,
					Value = hsi.Id.ToString(),
				}).ToList();

				return View(model);
			}

			var homeSliderInfo = _context.HomeSliderInfos.FirstOrDefault(hsi => hsi.Title.Trim().ToLower() == model.Title.Trim().ToLower() &&
																				hsi.Id != id &&
																				!hsi.IsDeleted);

			if (homeSliderInfo is not null)
			{
				ModelState.AddModelError("Title", "There exists Slider Title under this name");
				return View(model);
			}

			homeSliderInfo = _context.HomeSliderInfos.FirstOrDefault(hsi => hsi.Id == id && !hsi.IsDeleted);
			if (homeSliderInfo is null) return NotFound();

			var homeSlider = _context.HomeSliderInfos.FirstOrDefault(hs => !hs.IsDeleted && hs.Id == model.HomeSliderId);
			if (homeSlider == null)
			{
				ModelState.AddModelError("HomeSliderId", "There is already Slider Category under this name");
			}

			homeSliderInfo.Title = model.Title;
			homeSliderInfo.Desc = model.Desc;
			homeSliderInfo.HomeSliderId = model.HomeSliderId;
			homeSliderInfo.ModifiedAt = DateTime.Now;

			_context.HomeSliderInfos.Update(homeSliderInfo);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion

		#region Detail 
		public IActionResult Details(int id)
		{
			var homeSliderInfo = _context.HomeSliderInfos.Include(hs => hs.HomeSlider)
														 .FirstOrDefault(hsi => hsi.Id == id &&
														 !hsi.IsDeleted);

			if(homeSliderInfo is null) return NotFound();

			var model = new HomeSliderInfoDetailsVM
			{
				Title = homeSliderInfo.Title,
				Desc = homeSliderInfo.Desc,
				HomeSlider = homeSliderInfo.HomeSlider,
				CreatedAt = homeSliderInfo.CreatedAt,
				ModifiedAt = homeSliderInfo.ModifiedAt
			};

			return View(model);
		}

		#endregion

		#region Delete
		public IActionResult Delete(int id)
		{
			var homeSliderInfo = _context.HomeSliderInfos.FirstOrDefault(hsi => hsi.Id == id && !hsi.IsDeleted);
			if( homeSliderInfo is null ) return NotFound();

			homeSliderInfo.IsDeleted = true;
			homeSliderInfo.DeletedAt = DateTime.Now;

			_context.HomeSliderInfos.Update(homeSliderInfo);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		#endregion
	}
}
