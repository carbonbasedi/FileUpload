using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.ViewModels.Work
{
	public class WorkIndexVM
	{
        public List<Models.WorkCategory> WorkCategories { get; set; }

		public FeaturedWorkComponent FeaturedWorkComponent { get; set; }
    }
}
