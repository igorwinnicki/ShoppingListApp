using Xamarin.Forms;
using ShoppingListApp.Models;
using ShoppingListApp.ViewModels;
using System;

namespace ShoppingListApp.Views
{
    public partial class ShoppingListPage : ContentPage
    {
        public ShoppingListPage()
        {
            InitializeComponent();
        }

        private void OnAddItemClicked(object sender, EventArgs e)
        {
            var name = ItemNameEntry.Text;
            if (int.TryParse(ItemQuantityEntry.Text, out int quantity))
            {
                if (!string.IsNullOrEmpty(name) && quantity > 0)
                {
                    var newItem = new ShoppingItem { Name = name, Quantity = quantity, IsBought = false };
                    var viewModel = BindingContext as ShoppingListViewModel;
                    viewModel?.AddItemCommand.Execute(newItem);

                    ItemNameEntry.Text = string.Empty;
                    ItemQuantityEntry.Text = string.Empty;
                }
            }
        }

        private void OnItemToggled(object sender, ToggledEventArgs e)
        {
            var switchControl = sender as Switch;
            var shoppingItem = switchControl?.BindingContext as ShoppingItem;
            var viewModel = BindingContext as ShoppingListViewModel;
            viewModel?.ToggleBoughtCommand.Execute(shoppingItem);
        }
    }
}
