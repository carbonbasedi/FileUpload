using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Task_PurpleBuzz.Areas.Admin.ViewModels.Works
{
    public class WorkCreateVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        public string Desc { get; set; }
        public string ImgPath { get; set; }

        [Display(Name = "Work Category")]
        public int WorkCategoryId { get; set; }
        public List<SelectListItem>? WorkCategories { get; set; }
    }
}
