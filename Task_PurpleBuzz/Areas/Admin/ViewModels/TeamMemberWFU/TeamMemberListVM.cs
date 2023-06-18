namespace Task_PurpleBuzz.Areas.Admin.ViewModels.TeamMemberWFU
{
	public class TeamMemberListVM
	{
        public TeamMemberListVM()
        {
            TeamMemberWFUs = new List<Models.TeamMemberWFU>();
        }
        public List<Models.TeamMemberWFU> TeamMemberWFUs { get; set; }
    }
}
