namespace Task_PurpleBuzz.Areas.Admin.ViewModels.HomeSliderInfo
{
	public class HomeSliderInfoIndexVM
	{
        public HomeSliderInfoIndexVM()
        {
            HomeSliderInfos = new List<Models.HomeSliderInfo>();
        }
        public List<Models.HomeSliderInfo> HomeSliderInfos { get; set; }
    }
}
