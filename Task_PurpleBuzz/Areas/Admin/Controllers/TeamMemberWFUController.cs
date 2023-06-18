using Microsoft.AspNetCore.Mvc;
using Task_PurpleBuzz.Areas.Admin.ViewModels.TeamMemberWFU;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;
using Task_PurpleBuzz.Utilities.File;

namespace Task_PurpleBuzz.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("admin/team-member/{action=list}/{id?}")]
	public class TeamMemberWFUController : Controller
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IFileService _fileService;
		private readonly AppDbContext _context;


		public TeamMemberWFUController(
			AppDbContext context,
			IWebHostEnvironment webHostEnvironment,
			IFileService fileService)

        {
            _webHostEnvironment = webHostEnvironment;
			_fileService = fileService;
			_context = context;
        }


		[HttpGet]
		public IActionResult List()
		{
			var model = new TeamMemberWFUListVM
			{
				TeamMemberWFUs = _context.TeamMemberWFUs.ToList()
			};
			return View(model);
		}


		#region Create
		[HttpGet]
		public IActionResult Create() 
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(TeamMemberWFUCreateVM model)
		{
			if(!ModelState.IsValid) return View(model);

			if (_fileService.IsImage(model.Photo))
				ModelState.AddModelError("Photo", "Wrong file format");

			if(_fileService.IsBiggerThanSize(model.Photo,200))
				ModelState.AddModelError("Photo", "File size is over 200kb");

			var teamMemberWFU = new TeamMemberWFU
			{
				Name = model.Name,
				Surname = model.Surname,
				Duty = model.Duty, 
				About = model.About,
				CreatedAt = DateTime.Now,
				PhotoName = _fileService.Upload(model.Photo)
			};

			_context.Add(teamMemberWFU);
			_context.SaveChanges();

			return RedirectToAction("List");
		}
		#endregion

		#region Delete
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var teamMemberWFU = _context.TeamMemberWFUs.Find(id);
			if (teamMemberWFU is null) return NotFound();

			_fileService.Delete(teamMemberWFU.PhotoName);

			_context.TeamMemberWFUs.Remove(teamMemberWFU);
			_context.SaveChanges();

			return RedirectToAction("List");
		}
		#endregion

		#region Update
		[HttpGet]
		public IActionResult Update(int id) 
		{
			var teamMember = _context.TeamMemberWFUs.Find(id);
			if (teamMember is null) return NotFound();

			var model = new TeamMemberWFUUpdateVM
			{
				Name = teamMember.Name,
				Surname = teamMember.Surname,
				Duty = teamMember.Duty,
				About = teamMember.About,
				PhotoName = teamMember.PhotoName,
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult Update(int id, TeamMemberWFUUpdateVM model)
		{
			if (!ModelState.IsValid) return View();

			var teamMembersWFU = _context.TeamMemberWFUs.Find(id);
			if (teamMembersWFU is null) return NotFound();

			if(model.Photo is not null)
			{
				_fileService.Delete(teamMembersWFU.PhotoName);
				teamMembersWFU.PhotoName = _fileService.Upload(model.Photo);
			}
			teamMembersWFU.Name = model.Name;
			teamMembersWFU.Surname = model.Surname;
			teamMembersWFU.About = model.About;
			teamMembersWFU.Duty = model.Duty;
			teamMembersWFU.ModifiedAt = DateTime.Now;

			_context.TeamMemberWFUs.Update(teamMembersWFU);
			_context.SaveChanges();

			return RedirectToAction(nameof(List));
		}
		#endregion

	}
}
