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
using WurmTools.Core.Tools;
using WurmTools.Core.Settings;

namespace WurmToolsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            delayTextBox.Text = SettingsManager.ReadSetting("DelayValue");
        }

        

    private async void StartMineButton_Click(object sender, RoutedEventArgs e)
        {
            int initialDelay = (int.Parse(SettingsManager.ReadSetting("InitialDelayValue")) * 1000);

            int delay = 1;
            
            string input = delayTextBox.Text;
            if(string.IsNullOrEmpty(input))
            {

                MessageBox.Show("You must enter a delay in the box above Start Mining", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                delay = (int.Parse(input) * 1000);
            }
            
            
            MiningStatusMessageLabel.Foreground = Brushes.Green;
            MiningStatusMessageLabel.Content = "You are actively mining!";
            


            
            Mining.IsMiningEnabled = true;
            await Task.Delay(initialDelay);
            await Mining.Mine(delay);
        }

        private void StopMiningButton_Click(object sender, RoutedEventArgs e)
        {
            MiningStatusMessageLabel.Foreground = Brushes.Red;
            MiningStatusMessageLabel.Content = "You are not mining right now, Enter a delay and click Start Mining!";

            Mining.IsMiningEnabled = false;
        }

        private void DelayHelpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is the total in seconds for the duration of the mining action. This can vary based on your skill. I recommend starting at 50 seconds and tuning from there. You must stop mining to update the value!", "Delay Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NormalMining_Checked(object sender, RoutedEventArgs e)
        {
            Mining.SelectedMiningMode = Mining.NormalMiningModeHotKey;
        }

        private void TunnelMining_Checked(object sender, RoutedEventArgs e)
        {
            Mining.SelectedMiningMode = Mining.TunnelMiningModeHotKey;
        }

        private void UpMining_Checked(object sender, RoutedEventArgs e)
        {
            Mining.SelectedMiningMode = Mining.UpMiningModeHotKey;
        }

        private void DownMining_Checked(object sender, RoutedEventArgs e)
        {
            Mining.SelectedMiningMode = Mining.DownMiningModeHotKey;
        }

        private void SettingsMenuButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.Show();
            Close();
        }

        private void SaveDelayButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsManager.AddUpdateAppSettings("DelayValue", delayTextBox.Text);
            MessageBox.Show("Settings Saved Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        

        
    }
}
