using Task_PurpleBuzz.Models;

namespace Task_PurpleBuzz.ViewModels.Contacts
{
    public class ContactsIndexVM
    {
        public ContactsBannerComponent ContactsBannerComponent { get; set; }
        public ContactsSuccessComponent ContactsSuccessComponent { get; set; }
        public List<ContactsSupportComponent> ContactsSupportComponent { get; set; }
    }
}
