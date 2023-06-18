using System.ComponentModel.DataAnnotations;

namespace Task_PurpleBuzz.Areas.Admin.ViewModels.TeamMemberWFU
{
	public class TeamMemberWFUUpdateVM
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public string Duty { get; set; }

		[MaxLength(100)]
		public string About { get; set; }

		public IFormFile? Photo { get; set; }

        public string? PhotoName { get; set; }
    }
}
