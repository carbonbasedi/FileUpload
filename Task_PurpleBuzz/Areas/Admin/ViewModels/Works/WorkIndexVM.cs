namespace Task_PurpleBuzz.Areas.Admin.ViewModels.Works
{
	public class WorkIndexVM
	{
        public WorkIndexVM()
        {
            Works = new List<Models.Work>();
        }
        public List<Models.Work> Works { get; set; }
    }
}
