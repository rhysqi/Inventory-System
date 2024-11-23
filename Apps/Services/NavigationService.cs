using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Apps.Services;

internal class NavigationService : INavigationService
{
    private readonly Frame _frame;

    public NavigationService(Frame frame)
    {
        _frame = frame;
    }

    public void NavigateTo(Page page)
    {
        if(page == null) throw new ArgumentNullException(nameof(page));
        _frame.Navigate(page);
    }
}
