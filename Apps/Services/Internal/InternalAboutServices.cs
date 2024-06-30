using System.Windows;

namespace Inventory_System.Services.Internal;

internal class InternalAboutServices
{
    MessageBoxButton button = MessageBoxButton.OK;

    public void ExecuteAboutInfo(object parameter)
    {
        string message = 
            "Application: Inventory System (Demo)\n" +
            "Author: Risky Akbar\n" +
            "Version: v1.0a";
        string caption = "Info";

        LoggingServices.Logging("Viewing Application Info");
        MessageBox.Show(message, caption, button);
    }

    public void ExecuteAboutLicense(object parameter)
    {
        string message = "# Inventory System (Demo)\r\n\r\n" +
            "Copyright © 2024 by Risky Akbar\r\n\r\n" +
            "Licensed under the Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International License:\r\n\r\n" +
            "https://creativecommons.org/licenses/by-nc-nd/4.0/\r\n\r\n" +
            "You are free to:\r\n\r\n* " +
            "Share: Copy and redistribute the material in any medium or format\r\n* " +
            "Adapt: Remix, transform, and build upon the material\r\n\r\nUnder the following terms:\r\n\r\n* " +
            "Attribution: You must give appropriate credit, provide a link to the license, and indicate if changes were made. " +
            "You may do so in any reasonable manner, but not in any way that suggests the licensor endorses you or your use.\r\n* " +
            "NonCommercial: You may not use the material for commercial purposes.\r\n* " +
            "NoDerivatives: If you remix, transform, or build upon the material, you may not distribute the modified material.\r\n\r\n" +
            "Notices:\r\n\r\n* " +
            "You do not have to comply with the license for elements of the material in the public domain or where your use is permitted by an applicable exception or limitation.\r\n* " +
            "No warranties are given. The license may not give you all of the permissions necessary for your intended use. " +
            "For example, other rights such as publicity, privacy, or moral rights may limit how you use the material.\r\n\r\n" +
            "Questions?\r\n\r\nIf you have any questions about this license, please contact Risky Akbar at <rhysqi.akbar@gmail.com>.";

        string caption = "License";

        MessageBox.Show(message, caption, button);

        LoggingServices.Logging("Viewing Application License");
    }
}
