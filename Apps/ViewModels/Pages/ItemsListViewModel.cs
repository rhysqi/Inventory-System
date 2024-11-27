using System.Collections.ObjectModel;
using System.Windows.Input;

using Apps.Models;
using Apps.Services;

namespace Apps.ViewModels.Pages;

public class ItemsListViewModel : BaseViewModel
{
    private readonly ItemsService _itemsService;
    public ObservableCollection<ItemsModel> Items { get; set; }

    public ICommand ItemsListGet { get; set; }

    public ItemsListViewModel()
    {
        _itemsService = new ItemsService();
        Items = new ObservableCollection<ItemsModel>(_itemsService.GetAllItems());

        GetItems(null);
        ItemsListGet = new RelayCommand(GetItems);
    }

    private void GetItems(object parameter)
    {
        var itemsList = _itemsService.GetAllItems()
            .Where(items => items.IsDeleted == false)
            .ToList();

        Items.Clear();
        foreach (var item in itemsList)
        {
            Items.Add(item);
        }
    }
}
