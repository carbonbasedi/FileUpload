using Microsoft.EntityFrameworkCore;
using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<AboutBannerComponent> AboutBannerComponent{ get; set; }
        public DbSet<ContactsBannerComponent> ContactsBannerComponents { get; set; }
        public DbSet<ContactsSuccessComponent> ContactsSuccessComponents { get; set; }
        public DbSet<ContactsSupportComponent> ContactsSupportComponents { get; set; }
        public DbSet<WorkCategory> WorkCategories { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<ServiceComponent> ServiceComponents { get; set; }
        public DbSet<FeaturedWorkComponent> FeaturedWorkComponents { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }
        public DbSet<HomeSlider> HomeSliders { get; set; }
        public DbSet<HomeSliderInfo> HomeSliderInfos { get; set; }
        public DbSet<TeamMemberWFU> TeamMemberWFUs { get; set; }
    }
}
