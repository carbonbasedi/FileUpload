using Microsoft.AspNetCore.Mvc;
using Task_PurpleBuzz.Areas.Admin.ViewModels.TeamMembers;
using Task_PurpleBuzz.DAL;
using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TeamMembersController : Controller
	{
		private readonly AppDbContext _context;

		public TeamMembersController(AppDbContext context)
		{
			_context = context;

		}

		#region Index

		[HttpGet]
        public IActionResult Index()
		{
			var model = new TeamMemberIndexVM
			{
				TeamMembers = _context.TeamMembers.Where(tm => !tm.IsDeleted).ToList(),
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
		public IActionResult Create(TeamMemberCreateVM model)
		{
			if (!ModelState.IsValid) return View();

			var teamMember = new TeamMembers
			{
				Name = model.Name,
				Occupancy = model.Occupancy,
				ImgPath = model.ImgPath,
				CreatedAt = DateTime.Now,
			};

			_context.TeamMembers.Add(teamMember);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion

		#region Details
		[HttpGet]
		public IActionResult Details(int id)
		{
			var teamMember = _context.TeamMembers.FirstOrDefault(tm => tm.Id == id && !tm.IsDeleted);
			if (teamMember is null) return NotFound();

			var model = new TeamMemberDetailsVM
			{
				Name = teamMember.Name,
				Occupancy=teamMember.Occupancy,
				ImgPath = teamMember.ImgPath,
				CreatedAt = teamMember.CreatedAt,
				ModifiedAt = teamMember.ModifiedAt,
			};

			return View(model);
		}
		#endregion

		#region Update
		[HttpGet]
		public IActionResult Update(int id)
		{
			var teamMember = _context.TeamMembers.FirstOrDefault(tm => tm.Id == id && !tm.IsDeleted);
			if (teamMember is null) return NotFound();

			var model = new TeamMemberUpdateVM
			{
				Name = teamMember.Name,
				Occupancy = teamMember.Occupancy,
				ImgPath = teamMember.ImgPath,
			};

			return View(model);
		}
		[HttpPost]
		public IActionResult Update(int id, TeamMemberUpdateVM model) 
		{
			if(!ModelState.IsValid) return View();

			var teamMember = _context.TeamMembers.FirstOrDefault(tm => !tm.IsDeleted && tm.Id != id);
			if (teamMember is null) return View();

			teamMember = _context.TeamMembers.FirstOrDefault(tm => tm.Id == id && !tm.IsDeleted);
			if (teamMember is null) return NotFound();

			teamMember.Name = model.Name;
			teamMember.Occupancy = model.Occupancy;
			teamMember.ImgPath = model.ImgPath;
			teamMember.ModifiedAt = DateTime.Now;

			_context.TeamMembers.Update(teamMember);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion

		#region Delete
		public IActionResult Delete(int id)
		{
			var teamMember = _context.TeamMembers.FirstOrDefault(tm => tm.Id == id);
			if (teamMember is null) return NotFound();

			teamMember.IsDeleted = true;
			teamMember.DeletedAt = DateTime.Now;

			_context.TeamMembers.Update(teamMember);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion

	}
}
