using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.ViewModels.About
{
	public class AboutIndexVM
	{
        public List<TeamMembers> TeamMembers { get; set; }
        public AboutBannerComponent AboutBannerComponent { get; set; }

        public List<TeamMemberWFU> TeamMemberWFUs { get; set; }
    }
}
