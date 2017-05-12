using clg17042.Models;

namespace clg17042.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public UserItem Item { get; set; }

        public ItemDetailViewModel(UserItem item = null)
        {
            Title = item.Name.First;
            Item = item;
        }
    }
}
