namespace Task_PurpleBuzz.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImgPath { get; set; }
        public bool IsDeleted { get; set; }
        public int WorkCategoryId { get; set; }
        public WorkCategory WorkCategory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
