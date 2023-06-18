namespace Task_PurpleBuzz.Areas.Admin.ViewModels.TeamMemberWFU
{
	public class TeamMemberWFUListVM
	{
        public TeamMemberWFUListVM()
        {
            TeamMemberWFUs = new List<Models.TeamMemberWFU>();
        }
        public List<Models.TeamMemberWFU> TeamMemberWFUs { get; set; }
    }
}
