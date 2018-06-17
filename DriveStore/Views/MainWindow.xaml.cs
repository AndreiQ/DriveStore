using DriveStore.Models;
using DriveStore.ViewModels;
using DriveStore.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

namespace DriveStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void register_Click(object sender, RoutedEventArgs e)
        {
            string fullName = NameTextBox.Text;
            string loginName = LoginTextBox.Text;
            string driveSize = DriveSizeTextBox.Text;

            User user = new User(fullName, loginName, driveSize);
            var logedinWindow = new LogedInWindow(user);
            logedinWindow.Show();
            this.Close();
        }

    }
}
