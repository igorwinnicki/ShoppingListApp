using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using ShoppingListApp.Models;

namespace ShoppingListApp.ViewModels
{
    public class ShoppingListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ShoppingItem> Items { get; set; }
        public Command<ShoppingItem> AddItemCommand { get; set; }
        public Command<ShoppingItem> DeleteItemCommand { get; set; }
        public Command<ShoppingItem> ToggleBoughtCommand { get; set; }

        public ShoppingListViewModel()
        {
            Items = new ObservableCollection<ShoppingItem>();
            AddItemCommand = new Command<ShoppingItem>(AddItem);
            DeleteItemCommand = new Command<ShoppingItem>(DeleteItem);
            ToggleBoughtCommand = new Command<ShoppingItem>(ToggleBought);
        }

        private void AddItem(ShoppingItem item)
        {
            Items.Add(item);
            OnPropertyChanged(nameof(Items));
        }

        private void DeleteItem(ShoppingItem item)
        {
            Items.Remove(item);
            OnPropertyChanged(nameof(Items));
        }

        private void ToggleBought(ShoppingItem item)
        {
            item.IsBought = !item.IsBought;
            OnPropertyChanged(nameof(Items));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
