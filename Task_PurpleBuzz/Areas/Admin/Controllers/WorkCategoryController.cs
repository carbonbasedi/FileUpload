using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Task_PurpleBuzz.Areas.Admin.ViewModels.WorkCategory;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class WorkCategoryController : Controller
	{
		private readonly AppDbContext _context;

		public WorkCategoryController(AppDbContext context)
		{
			_context = context;
		}

		#region Index

		[HttpGet]
		public IActionResult Index()
		{
			var model = new WorkCategoryIndexVM
			{
				WorkCategories = _context.WorkCategories.Where(wc => !wc.IsDeleted).ToList()
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
		public IActionResult Create(WorkCategoryCreateVM model)
		{
			if (!ModelState.IsValid) return View();

			var workCategory = _context.WorkCategories.FirstOrDefault(wc => wc.Name.Trim().ToLower() == model.Name.Trim().ToLower() && !wc.IsDeleted);

			if (workCategory is not null)
			{
				ModelState.AddModelError("Name", "Category under this name already exists in database");
				return View();
			}

			workCategory = new WorkCategory
			{
				Name = model.Name,
				CreatedAt = DateTime.Now,
			};

			_context.WorkCategories.Add(workCategory);
			_context.SaveChanges();

			return RedirectToAction("index");
		}
		#endregion

		#region Details
		[HttpGet]
		public IActionResult Details(int id)
		{
			var workCategory = _context.WorkCategories.Include(wc => wc.Works.Where(w => !w.IsDeleted)).FirstOrDefault(wc => wc.Id == id &&
																			!wc.IsDeleted);
			if (workCategory is null) return NotFound();

			var model = new WorkCategoryDetailsVM
			{
				Name = workCategory.Name,
				IsDeleted = workCategory.IsDeleted,
				CreatedAt = workCategory.CreatedAt,
				ModifiedAt = workCategory.ModifiedAt,
				DeletedAt = workCategory.DeletedAt,
				Works = workCategory.Works.ToList(),
			};

			return View(model);
		}
		#endregion

		#region Update
		[HttpGet]
		public IActionResult Update(int id)
		{
			var workCategory = _context.WorkCategories.FirstOrDefault(wc => wc.Id == id && !wc.IsDeleted);
			if (workCategory is null) return NotFound();

			var model = new WorkCategoryUpdateVM
			{
				Name = workCategory.Name,
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult Update(int id, WorkCategoryUpdateVM model)
		{
			if (!ModelState.IsValid) return View();

			var workCategory = _context.WorkCategories.FirstOrDefault(wc => wc.Name.Trim().ToLower() == model.Name.Trim().ToLower() && wc.Id != id && !wc.IsDeleted);
			if(workCategory is not null)
			{
				ModelState.AddModelError("Name", "Category under this name already exists in database");
				return View();
			}

			workCategory = _context.WorkCategories.FirstOrDefault(wc => wc.Id == id && !wc.IsDeleted);
			if(workCategory is null) return NotFound();

			workCategory.Name = model.Name;
			workCategory.ModifiedAt = DateTime.Now;

			_context.WorkCategories.Update(workCategory);
			_context.SaveChanges();

			return RedirectToAction("index");
		}
		#endregion

		#region Delete
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var workCategory = _context.WorkCategories.FirstOrDefault(wc => wc.Id == id);
			if (workCategory is null) return NotFound();

			workCategory.IsDeleted = true;
			workCategory.DeletedAt = DateTime.Now;

			_context.WorkCategories.Update(workCategory);
			_context.SaveChanges();

			return RedirectToAction("index");
        }
		#endregion
	}
}
