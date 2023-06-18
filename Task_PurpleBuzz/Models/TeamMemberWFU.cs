namespace Task_PurpleBuzz.Models
{
	public class TeamMemberWFU
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public string Duty { get; set; }
        public string PhotoName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set;}
    }
}
