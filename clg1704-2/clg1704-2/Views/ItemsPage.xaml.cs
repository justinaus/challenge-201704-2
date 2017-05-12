using clg17042.Models;
using clg17042.ViewModels;
using Xamarin.Forms;

namespace clg17042.Views
{
    public partial class ItemsPage : ContentPage
    {

        ItemsViewModel viewModel;


        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			UserItem item = args.SelectedItem as UserItem;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			viewModel.OnItemAppearing(sender, e);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}
    }
}
