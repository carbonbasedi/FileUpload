namespace Task_PurpleBuzz.Areas.Admin.ViewModels.TeamMembers
{
	public class TeamMemberDetailsVM
	{
		public string Name { get; set; }
		public string Occupancy { get; set; }
        public string ImgPath { get; set; }
        public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
	}
}
