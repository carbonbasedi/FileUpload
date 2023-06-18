namespace Task_PurpleBuzz.Models
{
	public class TeamMembers
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string Occupancy { get; set; }
        public string ImgPath { get; set; }
        public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
