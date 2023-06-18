namespace Task_PurpleBuzz.Models
{
	public class HomeSliderInfo
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Desc { get; set; }
		public bool IsDeleted { get; set; }
		public int HomeSliderId { get; set; }
		public HomeSlider HomeSlider { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
		public DateTime? DeletedAt { get; set; }

	}
}
