using Microsoft.AspNetCore.Mvc;
using Task_PurpleBuzz.Areas.Admin.ViewModels.ServiceComponent;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceComponentController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceComponentController(AppDbContext context) 
        {
            _context = context;
        }

		#region Index
		[HttpGet]
        public IActionResult Index()
        {
            var serviceComponents = _context.ServiceComponents.OrderByDescending(sc => sc.Id).ToList();

            var model = new ServiceComponentIndexVM
            { 
                ServiceComponents = serviceComponents,
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
        public IActionResult Create(ServiceComponentCreateVM model)
        {
            if (!ModelState.IsValid) return View();

            var serviceComponent = new ServiceComponent
            {
                Title = model.Title,
                Subtitle = model.Subtitle,
                Desc = model.Desc,
            };

            var dbServiceComponent = _context.ServiceComponents.FirstOrDefault(sc => !sc.IsDeleted);
            if (dbServiceComponent != null) 
            {
            dbServiceComponent.IsDeleted = true;
            _context.ServiceComponents.Update(dbServiceComponent);
            };

            _context.ServiceComponents.Add(serviceComponent);
            _context.SaveChanges();

            return RedirectToAction("details","servicecomponent", new {id = serviceComponent.Id});
        }
        #endregion

        [HttpGet]
        public IActionResult Details(int id) 
        {
            var serviceComponent = _context.ServiceComponents.Find(id);

            var model = new ServiceComponentDetailsVM
            {
                Title = serviceComponent.Title,
                Subtitle = serviceComponent.Subtitle,
                Description = serviceComponent.Desc,
            };

            return View(model);
        }

	}
}
