using DriveStore.Models;
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
using System.Windows.Shapes;

namespace DriveStore.Views
{
    /// <summary>
    /// Interaction logic for LogedInWindow.xaml
    /// </summary>
    public partial class LogedInWindow : Window
    {
        private string FileName;
        private User user;
        TcpClient client;
        StreamWriter writer;
        public LogedInWindow(User usr)
        {
            InitializeComponent();
            user = usr;
            loginName.Content = user.LoginName;
        }


        private void send_Click(object sender, RoutedEventArgs e)
        {
            Stream Fs = File.OpenRead(FileName);
            Byte[] buffer = new Byte[Fs.Length];
            Fs.Read(buffer, 0, buffer.Length);
            FileInfo fi = new FileInfo(FileName);
            var content = System.Text.Encoding.Default.GetString(buffer);
            var name = fi.Name;
          
         
           
            writer.WriteLine(name);
            writer.Flush();
            writer.WriteLine(content);
            writer.Close();
         
        }
        private void connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new TcpClient(IPTextBox.Text, Int32.Parse(PortTextBox.Text));
                IPTextBox.IsReadOnly = true;
                PortTextBox.IsReadOnly = true;
                Connect.Content = "Connected";
                Connect.IsEnabled = false;
                Send.IsEnabled = true;
                Disconect.IsEnabled = true;
                NetworkStream stream = client.GetStream();
                writer = new StreamWriter(stream);

                writer.WriteLine(user.FullName+"."+ user.LoginName+"."+ user.DriveSize);
                writer.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         
        }
        private void disconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client.Close();
                IPTextBox.IsReadOnly = false;
                PortTextBox.IsReadOnly = false;
                Connect.Content = "Connect";
                Connect.IsEnabled = true;
                Send.IsEnabled =false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void selectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileName = openFileDialog.FileName;
                PreviewFile.Content = FileName;

            }
        }
    }
}
