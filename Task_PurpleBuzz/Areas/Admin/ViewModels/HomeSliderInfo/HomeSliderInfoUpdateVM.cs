using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Task_PurpleBuzz.Areas.Admin.ViewModels.HomeSliderInfo
{
	public class HomeSliderInfoUpdateVM
	{
		[Required]
		[MinLength(3)]
		[MaxLength(15)]
		public string Title { get; set; }

		[Required]
		[MinLength(5)]
		[MaxLength(30)]
		public string Desc { get; set; }

		[Display(Name = "Slider Title")]
		public int HomeSliderId { get; set; }
		public List<SelectListItem>? SliderTitleList { get; set; }
	}
}
