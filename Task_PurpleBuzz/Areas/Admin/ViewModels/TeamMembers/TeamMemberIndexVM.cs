using System.Collections.Generic;

namespace Task_PurpleBuzz.Areas.Admin.ViewModels.TeamMembers
{
	public class TeamMemberIndexVM
	{
        public TeamMemberIndexVM()
        {
            TeamMembers = new List<Models.TeamMembers>();
        }
        public List<Models.TeamMembers> TeamMembers { get; set; }
    }
}
