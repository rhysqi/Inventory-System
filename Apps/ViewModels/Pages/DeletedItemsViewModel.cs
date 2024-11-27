using Apps.Models;
using Apps.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Apps.ViewModels.BaseViewModel;
using System.Windows.Input;

namespace Apps.ViewModels.Pages;

internal class DeletedItemsViewModel
{
    private readonly ItemsService _itemsService;
    public ObservableCollection<ItemsModel> Items { get; set; }

    public ICommand DeletedItemsGet { get; set; }

    public DeletedItemsViewModel()
    {
        _itemsService = new ItemsService();
        Items = new ObservableCollection<ItemsModel>(_itemsService.GetAllItems());

        GetDeletedItems(null);
        DeletedItemsGet = new RelayCommand(GetDeletedItems);
    }

    private void GetDeletedItems(object parameter)
    {
        var itemsList = _itemsService.GetAllItems().
            Where(Items => Items.IsDeleted == true).ToList();

        Items.Clear();

        foreach (var item in itemsList)
        {
            Items.Add(item);
        }
    }
}
