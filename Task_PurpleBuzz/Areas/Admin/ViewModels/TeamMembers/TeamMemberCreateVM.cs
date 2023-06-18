using System.ComponentModel.DataAnnotations;

namespace Task_PurpleBuzz.Areas.Admin.ViewModels.TeamMembers
{
	public class TeamMemberCreateVM
	{
		[Required(ErrorMessage = "Name is required")]
		[MaxLength(20, ErrorMessage = "Name mustn't exceed 20 characters")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Occupancy is required")]
		[MaxLength(20, ErrorMessage = "Occupancy mustn't exceed 20 characters")]
		public string Occupancy { get; set; }

		[Required(ErrorMessage = "ImgPath is required")]
		public string ImgPath { get; set; }
    }
}
