using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Task_PurpleBuzz.Areas.Admin.ViewModels.HomeSlider
{
	public class HomeSliderDetailsVM
	{
		public string Title { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
        public List<Models.HomeSliderInfo> homeSliderInfos { get; set; }
    }
}
