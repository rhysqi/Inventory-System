using Apps.Models;

using System.Windows;

namespace Apps.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddNewItemWindow.xaml
    /// </summary>
    public partial class AddNewItemWindow : Window
    {
        public ItemsModel NewItem { get; private set; }

        public AddNewItemWindow()
        {
            InitializeComponent();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            // Create the new item object from user input
            NewItem = new ItemsModel
            {
                ID = ItemIdTextBox.Text,
                Name = ItemNameTextBox.Text,
                Description = ItemDescriptionTextBox.Text,
                IsDeleted = false
            };

            // Attempt to convert the Amount (string) to an integer
            if (int.TryParse(ItemAmountTextBox.Text, out int amount))
            {
                // If parsing is successful, assign the value to Amount
                NewItem.Amount = amount;
            }
            else
            {
                // If parsing fails, you can either set a default value or handle the error
                MessageBox.Show("Please enter a valid number for Amount.");
                return;  // Optionally return or handle the invalid input case
            }

            // Close the window after the item is created
            DialogResult = true;
            Close();
        }
    }
}
