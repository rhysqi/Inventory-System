﻿using System;
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
    }

    DependencyProperty TextProperty = 
        DependencyProperty.Register(
            "Text", typeof(string),
            typeof(RoundButtonUserControl),
            new PropertyMetadata(string.Empty));

    public string Text
    {
        get; set;
    }
}