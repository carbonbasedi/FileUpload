namespace Task_PurpleBuzz.Models
{
	public class HomeSlider
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
		public ICollection<HomeSliderInfo> HomeSliderInfos { get; set; }

	}
}
