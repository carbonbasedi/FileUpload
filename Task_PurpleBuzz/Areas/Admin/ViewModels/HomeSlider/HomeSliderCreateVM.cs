using System.ComponentModel.DataAnnotations;

namespace Task_PurpleBuzz.Areas.Admin.ViewModels.HomeSlider
{
	public class HomeSliderCreateVM
	{
		[Required(ErrorMessage = "Title is required")]
		[MaxLength(20, ErrorMessage = "Title mustn't exceed 20 characters")]
		public string Title { get; set; }
	}
}
