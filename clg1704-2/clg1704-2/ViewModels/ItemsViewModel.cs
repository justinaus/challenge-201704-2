using System;
using System.Diagnostics;
using System.Threading.Tasks;
using clg17042.Helpers;
using clg17042.Models;
using Xamarin.Forms;

namespace clg17042.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<UserItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        bool isLoadingMore = true;
        public bool IsLoadingMore 
        {
			get { return isLoadingMore; }
			set { SetProperty(ref isLoadingMore, value); }
        }


        public ItemsViewModel()
        {
            Title = "Users";
            Items = new ObservableRangeCollection<UserItem>();

            IsLoadingMore = false;

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


		public async void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
            UserItem targetItem = (UserItem)e.Item;

            if (targetItem == Items[Items.Count - 1])
			{
				Debug.WriteLine("last item");

                await LoadItemsMore();
			}
		}


        private async Task LoadItemsMore() {
			if (IsBusy) return;
            if (IsLoadingMore) return;

            IsLoadingMore = true;

			var items = await DataStore.GetItemsAsync(App.BasicParams);

            IsLoadingMore = false;

            Items.AddRange(items);
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync( App.BasicParams );

                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
