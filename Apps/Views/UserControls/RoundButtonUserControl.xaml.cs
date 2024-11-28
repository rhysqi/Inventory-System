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

    // Commandparameter Property
    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register(
            "CommandParameter",
            typeof(object),
            typeof(RoundButtonUserControl),
            new PropertyMetadata(null));

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
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

    // HeightInput Property
    private static readonly DependencyProperty HeightInputProperty =
        DependencyProperty.Register(
            "HeightInput",
            typeof(double),
            typeof(RoundButtonUserControl),
            new PropertyMetadata(35.0));

    public double HeightInput
    {
        get => (double)GetValue(HeightInputProperty);
        set => SetValue(HeightInputProperty, value);
    }

    // Click Property
    // Define the Click event DependencyProperty
    public static readonly DependencyProperty ClickEventProperty =
        DependencyProperty.Register(
            "ClickEvent",
            typeof(RoutedEventHandler),
            typeof(RoundButtonUserControl),
            new PropertyMetadata(null));

    // Provide a public property for the ClickEvent DependencyProperty
    public RoutedEventHandler ClickEvent
    {
        get => (RoutedEventHandler)GetValue(ClickEventProperty);
        set => SetValue(ClickEventProperty, value);
    }

    // Trigger the Click event handler
    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        // Trigger the custom Click event handler if it's not null
        ClickEvent?.Invoke(this, e);
    }
}
