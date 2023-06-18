using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Task_PurpleBuzz.Areas.Admin.ViewModels.Works;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)
        {
            _context = context;

        }

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var model = new WorkIndexVM
            {
                Works = _context.Works.Include(w => w.WorkCategory).Where(w => !w.IsDeleted).ToList()
            };

            return View(model);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {

            var model = new WorkCreateVM
            {
                WorkCategories = _context.WorkCategories.Where(wc => !wc.IsDeleted).Select(wc => new SelectListItem
                {
                    Text = wc.Name,
                    Value = wc.Id.ToString(),
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(WorkCreateVM model)
        {
            model.WorkCategories = _context.WorkCategories.Where(wc => !wc.IsDeleted).Select(wc => new SelectListItem
            {
                Text = wc.Name,
                Value = wc.Id.ToString(),
            }).ToList();


            if (!ModelState.IsValid) return View(model);


            var work = _context.Works.FirstOrDefault(w => w.Title.Trim().ToLower() == model.Title.Trim().ToLower() && 
                                                         !w.IsDeleted);
            if (work is not null)
            {
                ModelState.AddModelError("Title", "There exists work under this name");
                return View(model);
            }

            var workCategory = _context.WorkCategories.Find(model.WorkCategoryId);
            if (workCategory is null)
            {
                ModelState.AddModelError("WorkCategoryId", "Category under this name doesn't exists");
                return View(model);
            }

            work = new Work
            {
                Title = model.Title,
                Desc = model.Desc,
                ImgPath = model.ImgPath,
                WorkCategoryId = model.WorkCategoryId,
                CreatedAt = DateTime.Now,
            };

            _context.Works.Add(work);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion

        #region Update 

        [HttpGet]
        public IActionResult Update(int id)
        {
            var work = _context.Works.FirstOrDefault(w => w.Id == id && !w.IsDeleted);
            if (work is null) return NotFound();

            var model = new WorkUpdateVM
            {
                Title = work.Title,
                Desc = work.Desc,
                ImgPath = work.ImgPath,
                WorkCategories = _context.WorkCategories.Where(wc => !wc.IsDeleted).Select(wc => new SelectListItem
                {
                    Text = wc.Name,
                    Value = wc.Id.ToString(),
                }).ToList(),
                WorkCategoryId = work.WorkCategoryId,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, WorkUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                model.WorkCategories = _context.WorkCategories.Where(wc => !wc.IsDeleted).Select(wc => new SelectListItem
                {
                    Text = wc.Name,
                    Value = wc.Id.ToString(),
                }).ToList();

                return View(model);
            }

            var work = _context.Works.FirstOrDefault(w => w.Title.Trim().ToLower() == model.Title.Trim().ToLower() && 
                                                          w.Id != id &&
                                                         !w.IsDeleted);
            if (work is not null)
            {
                ModelState.AddModelError("Title", "There exists work under this name");
                return View(model);
            }

            work = _context.Works.FirstOrDefault(w => w.Id == id && !w.IsDeleted);
            if (work is null) return NotFound();

            var workCategory = _context.WorkCategories.FirstOrDefault(wc => !wc.IsDeleted && wc.Id == model.WorkCategoryId);
            if (workCategory is null)
            {
                ModelState.AddModelError("WorkCategoryId","There is no Slider under this name");
                return View(model);
            }

            work.Title = model.Title;
            work.Desc = model.Desc;
            work.ImgPath = model.ImgPath;
            work.WorkCategoryId = model.WorkCategoryId;
            work.ModifiedAt = DateTime.Now;

            _context.Works.Update(work);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion

        #region Details 
        public IActionResult Details(int id)
        {
            var work = _context.Works.Include(w => w.WorkCategory).FirstOrDefault(w => w.Id == id && 
                                                         !w.IsDeleted);
            if (work is null) return NotFound();

            var model = new WorkDetailsVM
            {
                Title = work.Title,
                Desc = work.Desc,
                CreatedAt = work.CreatedAt,
                ModifiedAt = work.ModifiedAt,
                ImgPath = work.ImgPath,
                WorkCategory = work.WorkCategory
            };

            return View(model);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id) 
        {
            var work = _context.Works.FirstOrDefault(w => w.Id == id && !w.IsDeleted);
            if (work is null) return NotFound();

            work.IsDeleted = true;
            work.DeletedAt = DateTime.Now;

            _context.Works.Update(work);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
    }
}
