﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App446MasterDetail.Models;
using App446MasterDetail.Views;
using App446MasterDetail.ViewModels;


namespace App446MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPageDriver : TabbedPage
    {
        ItemsViewModel viewModel;

        public TabbedPageDriver()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

       

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}