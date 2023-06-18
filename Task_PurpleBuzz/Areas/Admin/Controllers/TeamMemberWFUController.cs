using Microsoft.AspNetCore.Mvc;
using Task_PurpleBuzz.Areas.Admin.ViewModels.TeamMemberWFU;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("admin/team-member/{action=list}/{id?}")]
	public class TeamMemberWFUController : Controller
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly AppDbContext _context;

		public TeamMemberWFUController(AppDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
			_context = context;
        }
		[HttpGet]
		public IActionResult List()
		{
			var model = new TeamMemberListVM
			{
				TeamMemberWFUs = _context.TeamMemberWFUs.ToList()
			};
			return View(new TeamMemberListVM());
		}

		[HttpGet]
		public IActionResult Create() 
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(TeamMemberWFUCreateVM model)
		{
			if(!ModelState.IsValid) return View(model);

			var photoName = Guid.NewGuid() + " " + model.Photo.FileName;
			var path = Path.Combine(_webHostEnvironment.WebRootPath, "assets/img", photoName);

			if(!model.Photo.ContentType.Contains("image/"))
				ModelState.AddModelError("Photo", "Wrong file format");

			if(model.Photo.Length / 1024 > 100)
				ModelState.AddModelError("Photo", "File size is over 100kb");

			using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
			{
				model.Photo.CopyTo(fileStream);
			}

			var teamMemberWFU = new TeamMemberWFU
			{
				Name = model.Name,
				Surname = model.Surname,
				Duty = model.Duty,
				About = model.About,

				PhotoName = photoName
			};

			_context.Add(teamMemberWFU);
			_context.SaveChanges();

			return RedirectToAction("List");
		}
	}
}
