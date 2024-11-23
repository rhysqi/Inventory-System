using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Apps.Views.UserControls;

/// <summary>
/// Interaction logic for RoundButtonUserControl.xaml
/// </summary>
public partial class RoundButtonUserControl : UserControl
{
    public RoundButtonUserControl()
    {
        InitializeComponent();
    }

    // Text Content Property
    private static readonly DependencyProperty TextContentProperty = 
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
    private static readonly DependencyProperty ButtonColorProperty =
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
    private static readonly DependencyProperty TextColorProperty =
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

    // CommandInput Property
    public static readonly DependencyProperty CommandInputPropperty =
        DependencyProperty.Register(
            "CommandInput",
            typeof(ICommand),
            typeof(RoundButtonUserControl),
            new PropertyMetadata(null));

    public ICommand CommandInput
    {
        get => (ICommand)GetValue(CommandInputPropperty);
        set => SetValue(CommandInputPropperty, value);
    }
}
