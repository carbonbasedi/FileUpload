namespace Task_PurpleBuzz.Areas.Admin.ViewModels.Works
{
    public class WorkDetailsVM
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImgPath { get; set; }
        public Models.WorkCategory WorkCategory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
