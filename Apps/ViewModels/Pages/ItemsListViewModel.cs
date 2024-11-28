using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Apps.Models;
using Apps.Services;
using Apps.Views.Windows;

namespace Apps.ViewModels.Pages;

public class ItemsListViewModel : BaseViewModel
{
    private readonly ItemsService _itemsService;
    public ObservableCollection<ItemsModel> Items { get; set; }

    public ICommand ItemsListGet { get; set; }
    public ICommand DeleteItemCommand {  get; set; }
    public ICommand AddNewItemCommand { get; set; }

    public ItemsListViewModel()
    {
        _itemsService = new ItemsService();
        Items = new ObservableCollection<ItemsModel>(_itemsService.GetAllItems());

        GetItems(null);
        ItemsListGet = new RelayCommand(GetItems);

        DeleteItemCommand = new RelayCommand(DeleteItem);
        AddNewItemCommand = new RelayCommand(OpenAddItemWindow);
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
                UpdateItem(item);
            }
        }
        finally
        {
            _isHandlingRowEdit = false;
        }
    }

    // Function to open the AddItemWindow for adding a new item
    private void OpenAddItemWindow(object parameter)
    {
        var addItemWindow = new AddNewItemWindow();

        // Show the window and check if the user added an item
        if (addItemWindow.ShowDialog() == true)
        {
            // Get the new item from the window
            var newItem = addItemWindow.NewItem;

            // Add the item to the collection and the database
            AddItem(newItem);
        }
    }

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

            // If ID is not duplicated, add the new item
            var newItem = new ItemsModel
            {
                ID = itemsAdd.ID,
                Name = itemsAdd.Name,
                Description = itemsAdd.Description,
                Amount = itemsAdd.Amount,
                IsDeleted = false,
                DeletedDate = null
            };

            // Add Item to the database and collections
            try
            {
                _itemsService.AddedItem(newItem); // Make sure this method adds the item to the database correctly
                Items.Add(newItem); // Add to the ObservableCollection to update the UI

                string Msg = $"Added Item:\nID: {newItem.ID}\nName: {newItem.Name}\nDescription: {newItem.Description}\nAmount: {newItem.Amount}";
                MessageBox.Show(Msg, "Add New Item", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Invalid item data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            MessageBox.Show("Item is Deleted", "Delete Item");
        }
        RefreshItems();
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
