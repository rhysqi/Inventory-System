using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Apps.Views.UserControls;

/// <summary>
/// Interaction logic for RoundButtonUserControl.xaml
/// </summary>
public partial class RoundButtonUserControl : UserControl
{
    public RoundButtonUserControl()
    {
        InitializeComponent();
        DataContext = this;
    }

    public static readonly DependencyProperty TextContentProperty = 
        DependencyProperty.Register(
            "TextContent", typeof(string),
            typeof(RoundButtonUserControl),
            new PropertyMetadata(string.Empty));

    public string TextContent
    {
        get => (string)GetValue(TextContentProperty);
        set => SetValue(TextContentProperty, value);
    }

    // Button Color property
    public static readonly DependencyProperty ButtonColorProperty =
        DependencyProperty.Register(
            "ButtonColor", typeof(Brush),
            typeof(RoundButtonUserControl),
            new PropertyMetadata(Brushes.White));

    public Brush ButtonColor
    {
        get => (Brush)GetValue(ButtonColorProperty);
        set => SetValue(ButtonColorProperty, value);
    }

    // TextColor Property
    public static readonly DependencyProperty TextColorProperty =
        DependencyProperty.Register(
            "TextColor",
            typeof(Brush),
            typeof(RoundButtonUserControl),
            new PropertyMetadata(Brushes.Black));

    public Brush TextColor
    {
        get => (Brush)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }
}
