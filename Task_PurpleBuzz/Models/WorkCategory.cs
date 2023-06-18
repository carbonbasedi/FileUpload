namespace Task_PurpleBuzz.Models
{
	public class WorkCategory
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Work> Works { get; set; }
    }
}
