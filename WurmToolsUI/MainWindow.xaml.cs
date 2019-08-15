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
using WurmTools.Core.Tools;

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
        }

        private async void StartMineButton_Click(object sender, RoutedEventArgs e)
        {
            int delay = 1;
            //TODO: fix this error. Need to check for empty text in the delay box
            string input = DelayTextBox.Text;
            if(string.IsNullOrEmpty(input) || (input != ""))
            {
                delay = (int.Parse(input) * 1000);
            }
            else
            {
                MessageBox.Show("You must enter a delay in the box above Start Mining", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            
            MiningStatusMessageLabel.Foreground = Brushes.Green;
            MiningStatusMessageLabel.Content = "You are actively mining!";
            



            Mining.IsMiningEnabled = true;
            await Task.Delay(5000);
            await Mining.Mine(delay);
        }

        private void StopMiningButton_Click(object sender, RoutedEventArgs e)
        {
            MiningStatusMessageLabel.Foreground = Brushes.Red;
            MiningStatusMessageLabel.Content = "You are not mining right now, Enter a delay and click Start Mining!";

            Mining.IsMiningEnabled = false;
        }
    }
}
