namespace Task_PurpleBuzz.Areas.Admin.ViewModels.HomeSliderInfo
{
	public class HomeSliderInfoDetailsVM
	{
        public string Title { get; set; }
        public string Desc { get; set; }
        public Models.HomeSlider HomeSlider { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
