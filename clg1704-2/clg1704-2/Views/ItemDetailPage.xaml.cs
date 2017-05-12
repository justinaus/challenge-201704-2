using clg17042.ViewModels;
using Xamarin.Forms;

namespace clg17042.Views
{
    public partial class ItemDetailPage : ContentPage
    {

        ItemDetailViewModel viewModel;


        public ItemDetailPage( ItemDetailViewModel viewModel )
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
