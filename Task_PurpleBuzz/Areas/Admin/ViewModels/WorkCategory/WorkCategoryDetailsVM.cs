namespace Task_PurpleBuzz.Areas.Admin.ViewModels.WorkCategory
{
	public class WorkCategoryDetailsVM
	{
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<Models.Work> Works { get; set; }
    }
}
