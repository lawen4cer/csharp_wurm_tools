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
        int counter;
        System.Windows.Forms.Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            delayTextBox.Text = SettingsManager.ReadSetting("DelayValue");
            timerTextBox.Text = SettingsManager.ReadSetting("SaveTimerValue");
        }



        private async void StartMineButton_Click(object sender, RoutedEventArgs e)
        {
            counter = (int.Parse(timerTextBox.Text) * 60);
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Start();



            int initialDelay = (int.Parse(SettingsManager.ReadSetting("InitialDelayValue")) * 1000);

            int delay = 1;

            string input = delayTextBox.Text;
            if (string.IsNullOrEmpty(input))
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

        private void timer_Tick(object sender, EventArgs e)
        {
            counter--;
            TimerContainer.Visibility = Visibility.Visible;
            CountDownTextBlock.Text = $"{Math.Ceiling(((double)counter / 60)).ToString()} Minutes";
            if (counter == 0)
            {
                Mining.IsMiningEnabled = false;
                RoutedEventArgs routedEventArgs = new RoutedEventArgs();
                StopMiningButton_Click(this, routedEventArgs);
            }
        }

        private void StopMiningButton_Click(object sender, RoutedEventArgs e)
        {
            MiningStatusMessageLabel.Foreground = Brushes.Red;
            MiningStatusMessageLabel.Content = "You are not mining right now, Enter a delay and click Start Mining!";

            Mining.IsMiningEnabled = false;
            timer.Stop();
            timer.Dispose();
            TimerContainer.Visibility = Visibility.Hidden;
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
            MessageBox.Show("Settings Saved Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            SettingsManager.AddUpdateAppSettings("DelayValue", delayTextBox.Text);
        }

        private void SaveTimerButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsManager.AddUpdateAppSettings("SaveTimerValue", timerTextBox.Text);
            MessageBox.Show("Settings Saved Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void TimerHelpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is the total time that the script will run in minutes before stopping. I recommend keeping it to an hour at a time. You can run out of room on Wurm and get the no space to mine error message", "Delay Help", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
