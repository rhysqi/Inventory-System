using Apps.Models;
using Apps.Services;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Apps.ViewModels.Pages;

internal class DeletedItemsViewModel : BaseViewModel
{
    private readonly ItemsService _itemsService;
    public ObservableCollection<ItemsModel> Items { get; set; }

    public ICommand DeletedItemsGet { get; set; }

    public ICommand RecoverItemCommand { get; set; }
    public ICommand DeleteItemCommand { get; set; }

    public DeletedItemsViewModel()
    {
        _itemsService = new ItemsService();
        Items = new ObservableCollection<ItemsModel>(_itemsService.GetAllItems());

        GetDeletedItems(null);

        DeletedItemsGet = new RelayCommand(GetDeletedItems);

        RecoverItemCommand = new RelayCommand(RecoverItem);
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

    private void RecoverItem(object parameter)
    {
        var itemToDelete = parameter as ItemsModel;

        if (itemToDelete != null)
        {
            itemToDelete.IsDeleted = false;

            _itemsService.UpdateItem(itemToDelete);

            RefreshItems();
        }
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
