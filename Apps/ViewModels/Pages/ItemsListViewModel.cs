using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Apps.Models;
using Apps.Services;

namespace Apps.ViewModels.Pages;

public class ItemsListViewModel : BaseViewModel
{
    private readonly ItemsService _itemsService;
    public ObservableCollection<ItemsModel> Items { get; set; }

    public ICommand ItemsListGet { get; set; }
    public ICommand DeleteItemCommand {  get; set; }

    public ItemsListViewModel()
    {
        _itemsService = new ItemsService();
        Items = new ObservableCollection<ItemsModel>(_itemsService.GetAllItems());

        GetItems(null);
        ItemsListGet = new RelayCommand(GetItems);

        DeleteItemCommand = new RelayCommand(DeleteItem);
    }

    // Get full of items
    private void GetItems(object parameter)
    {
        var itemsList = _itemsService.GetAllItems()
            .Where(items => !items.IsDeleted)
            .ToList();

        Items.Clear();
        foreach (var item in itemsList)
        {
            Items.Add(item);
        }
    }

    private bool _isHandlingRowEdit = false;

    public void HandleRowEdit(ItemsModel item, DataGrid dataGrid)
    {
        if (_isHandlingRowEdit)
            return;

        _isHandlingRowEdit = true;

        try
        {
            // Commit edit for check changed
            if (dataGrid != null)
            {
                dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
            }

            // Check item already in collection
            if (item != null)
            {
                var existingItem = Items.FirstOrDefault(x => x.ID == item.ID);

                if (existingItem != null)
                {
                    // If item already in collection, Update Item
                    UpdateItem(item);
                }
                else
                {
                    // If item not in collection, Add Item
                    AddItem(item);
                }
            }
        }
        finally
        {
            _isHandlingRowEdit = false;
        }
    }

    // Add data
    private void AddItem(object parameter)
    {
        var itemsAdd = parameter as ItemsModel;

        if (itemsAdd != null)
        {
            // Check ID for duplication
            if (Items.Any(item => item.ID == itemsAdd.ID))
            {
                MessageBox.Show($"Item with ID {itemsAdd.ID} already exists.", "Duplicate ID", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // If ID not there, Add new Item
            var newItem = new ItemsModel
            {
                ID = itemsAdd.ID,
                Name = itemsAdd.Name,
                Description = itemsAdd.Description,
                IsDeleted = false,
                DeletedDate = null
            };

            // Add Item to database and collections
            _itemsService.AddedItem(newItem);
            Items.Add(newItem);

            MessageBox.Show($"Added:\nID: {itemsAdd.ID}\nName: {itemsAdd.Name}\nDescription: {itemsAdd.Description}");
        }
    }

    // Edit data
    private void UpdateItem(ItemsModel updatedItem)
    {

        // Update items collection
        // Search items base on ID
        var existingItem = Items.FirstOrDefault(item => item.ID == updatedItem.ID);
        if (existingItem != null)
        {
            // Update value if has a changes
            existingItem.Name = updatedItem.Name;
            existingItem.Description = updatedItem.Description;
            existingItem.IsDeleted = updatedItem.IsDeleted;

            // Update item to database
            _itemsService.UpdateItem(existingItem);

            MessageBox.Show($"Item with ID {updatedItem.ID} has been updated.");
        }
        else
        {
            // If Item not found
            MessageBox.Show($"Item with ID {updatedItem.ID} not found for update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // Soft Delete items
    private void DeleteItem(object parameter)
    {
        var itemToDelete = parameter as ItemsModel;

        if (itemToDelete != null)
        {
            itemToDelete.IsDeleted = true;

            _itemsService.UpdateItem(itemToDelete);

            RefreshItems();
        }
    }

    // Refresh Database
    private void RefreshItems()
    {
        var itemsList = _itemsService.GetAllItems()
        .Where(item => !item.IsDeleted)
        .ToList();

        Items.Clear();
        foreach (var item in itemsList)
        {
            Items.Add(item);
        }
    }
}
