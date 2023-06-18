namespace Task_PurpleBuzz.Areas.Admin.ViewModels.WorkCategory
{
	public class WorkCategoryIndexVM
	{
        public WorkCategoryIndexVM()
        {
            WorkCategories = new List<Models.WorkCategory>();
        }
        public List<Models.WorkCategory> WorkCategories { get; set; }
    }
}
