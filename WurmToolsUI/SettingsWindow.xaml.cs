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
using System.Windows.Shapes;
using System.Configuration;
using WurmTools.Core.Tools;
using WurmTools.Core.Settings;


namespace WurmToolsUI
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            normalHotKeyTextBox.Text = Mining.NormalMiningModeHotKey;
            tunnelHotKeyTextBox.Text = Mining.TunnelMiningModeHotKey;
            upHotKeyTextBox.Text = Mining.UpMiningModeHotKey;
            downHotKeyTextBox.Text = Mining.DownMiningModeHotKey;
            initialDelayTextBox.Text = SettingsManager.ReadSetting("InitialDelayValue");
            numOfQueuesTextBox.Text = Mining.NumberOfQueues;


        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsManager.AddUpdateAppSettings("NormalMiningHotKey", normalHotKeyTextBox.Text ?? "3");
            SettingsManager.AddUpdateAppSettings("TunnelMiningHotKey", tunnelHotKeyTextBox.Text ?? "6");
            SettingsManager.AddUpdateAppSettings("UpMiningHotKey", upHotKeyTextBox.Text ?? "5");
            SettingsManager.AddUpdateAppSettings("DownMiningHotKey", downHotKeyTextBox.Text ?? "4");
            SettingsManager.AddUpdateAppSettings("InitialDelayValue", initialDelayTextBox.Text ?? "5");


            Mining.NormalMiningModeHotKey = normalHotKeyTextBox.Text;
            Mining.TunnelMiningModeHotKey = tunnelHotKeyTextBox.Text;
            Mining.UpMiningModeHotKey = upHotKeyTextBox.Text;
            Mining.DownMiningModeHotKey = downHotKeyTextBox.Text;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            MessageBox.Show("Settings Saved Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Close();
        }

        

        private void CancelSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
