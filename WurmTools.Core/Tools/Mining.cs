using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using WurmTools.Core.Settings;

namespace WurmTools.Core.Tools
{
    public class Mining
    {

        public static string NormalMiningModeHotKey { get; set; } = SettingsManager.ReadSetting("NormalMiningHotKey");
        public static string TunnelMiningModeHotKey { get; set; } = SettingsManager.ReadSetting("TunnelMiningHotKey");
        public static string UpMiningModeHotKey { get; set; } = SettingsManager.ReadSetting("UpMiningHotKey");
        public static string DownMiningModeHotKey { get; set; } = SettingsManager.ReadSetting("DownMiningHotKey");

        public static string NumberOfQueues { get; } = SettingsManager.ReadSetting("NumberOfQueues");
        public static bool IsMiningEnabled { get; set; } = false;

        public static string SelectedMiningMode { get; set; }
        
        public static async Task Mine(int delay)
        {
            
            while (IsMiningEnabled)
            {
                
                SendKeys.SendWait($"{{{SelectedMiningMode} 3}}");
                await Task.Delay(delay);
            }
        }
    }
}
