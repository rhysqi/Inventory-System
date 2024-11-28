using Apps.Models;
using Apps.Services;

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Apps.ViewModels.Pages;

internal class DeletedItemsViewModel : BaseViewModel
{
    private readonly ItemsService _itemsService;
    public ObservableCollection<ItemsModel> Items { get; set; }

    public ICommand DeletedItemsGet { get; set; }

    public ICommand RecoverItemCommand { get; set; }
    public ICommand RecoverAllItemCommand { get; set; }

    public ICommand DeleteItemCommand { get; set; }
    public ICommand DeleteAllItemCommand { get; set; }

    public DeletedItemsViewModel()
    {
        _itemsService = new ItemsService();
        Items = new ObservableCollection<ItemsModel>(_itemsService.GetAllItems());

        GetDeletedItems(null);

        DeletedItemsGet = new RelayCommand(GetDeletedItems);

        RecoverItemCommand = new RelayCommand(RecoverItem);
        RecoverAllItemCommand = new RelayCommand(RecoverAllItem);

        DeleteItemCommand = new RelayCommand(DeleteItem);
        DeleteAllItemCommand = new RelayCommand(DeleteAllItem);
    }

    private void GetDeletedItems(object parameter)
    {
        var itemsList = _itemsService.GetAllItems().
            Where(Items => Items.IsDeleted).ToList();

        Items.Clear();

        foreach (var item in itemsList)
        {
            Items.Add(item);
        }
    }

    // Recover deleted item
    private void RecoverItem(object parameter)
    {
        var itemToDelete = parameter as ItemsModel;

        if (itemToDelete != null)
        {
            itemToDelete.IsDeleted = false;

            _itemsService.UpdateItem(itemToDelete);

        }
        RefreshItems();
        MessageBox.Show("Item are recovered", "Items Recovery");
    }

    // Recover all items command
    private void RecoverAllItem(object parameter)
    {
        // Fetch all items that are deleted (IsDeleted = true)
        var itemsList = _itemsService.GetAllItems()
            .Where(items => items.IsDeleted)
            .ToList();

        if (itemsList.Count == 0)
        {
            MessageBox.Show("No deleted items found.");
            return;
        }

        // Iterate through each item and set IsDeleted to false
        foreach (var item in itemsList)
        {
            item.IsDeleted = false;
            _itemsService.UpdateItem(item);
        }

        RefreshItems();
        MessageBox.Show("All item are recovered", "Items Recovery");
    }

    // Delete item command
    private void DeleteItem(object parameter)
    {
        var itemToDelete = parameter as ItemsModel;

        string Msg = "Are you sure wanne delete permanent the item?";
        var MsgBox = MessageBox.Show(Msg, "Permanent Delete Items", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (MsgBox == MessageBoxResult.Yes)
        {
            if (itemToDelete != null)
            {
                _itemsService.DeleteItem(itemToDelete);
            }
        }

        RefreshItems();
    }

    // Delete all items command
    private void DeleteAllItem(object parameter)
    {
        // Fetch all items that are deleted (IsDeleted = true)
        var itemsList = _itemsService.GetAllItems()
            .Where(items => items.IsDeleted)
            .ToList();

        if (itemsList.Count == 0)
        {
            MessageBox.Show("No deleted items found.");
            return;
        }

        string Msg = "Are you sure wanne delete permanent all deleted Items?";
        var MsgBox = MessageBox.Show(Msg, "Permanent Delete All Items", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (MsgBox == MessageBoxResult.Yes)
        {
            // Iterate and delete items that IsDeleted True
            foreach (var item in itemsList)
            {
                _itemsService.DeleteItem(item);
            }
            MessageBox.Show("All item are deleted permanently");
        }
        RefreshItems();
    }

    private void RefreshItems()
    {
        var itemsList = _itemsService.GetAllItems()
        .Where(item => item.IsDeleted)
        .ToList();

        Items.Clear();
        foreach (var item in itemsList)
        {
            Items.Add(item);
        }
    }
}
