using Inventory_System.Services;
using System.ComponentModel;

namespace Inventory_System.ViewModels;

internal class HistoryWindowViewModels : INotifyPropertyChanged
{
    // History ViewModels
    public HistoryWindowViewModels()
    {
        HistoryWindowServicess HistoryData = new();
        historyText = HistoryData.RenderHistory();
    }

    // property data flow
    private string historyText;
    public string HistoryText
    {
        get { return historyText; }
        set
        {
            if (historyText != value)
            {
                historyText = value;
                OnPropertyChanged(nameof(HistoryText));
            }
        }
    }
    
    // Property changed method
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
