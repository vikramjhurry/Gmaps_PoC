using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using App446MasterDetail.Models;
using App446MasterDetail.Views;
using Xamarin.Forms.MultiSelectListView;
namespace App446MasterDetail.ViewModels
{
    public class TransportItemsViewModel :TransportBaseViewModel
    {
        public MultiSelectObservableCollection<TransportationTrips> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TransportItemsViewModel()
        {
            Title = "Browse";
            Items = new MultiSelectObservableCollection<TransportationTrips>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, TransportationTrips>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as TransportationTrips;
                Items.Add(newItem);
                await TripDataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await TripDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
