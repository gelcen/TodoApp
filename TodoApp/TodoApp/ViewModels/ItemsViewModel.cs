using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TodoApp.Models;
using TodoApp.Views;
using TodoApp.Model.TodoItems;
using TodoApp.Services;

namespace TodoApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel, IViewModel
    {
        IDataRepository<TodoItem> _repository;
        public ObservableCollection<TodoItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel(IDataRepository<TodoItem> repository)
        {
            _repository = repository;
            Title = "Browse";
            Items = new ObservableCollection<TodoItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, TodoItem>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as TodoItem;
                Items.Add(newItem);
                await _repository.AddItemAsync(newItem);
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
                var items = await _repository.GetItemsAsync(true);
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