using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WurmTools.Core.Tools
{
    public class Mining
    {
        public static bool IsMiningEnabled { get; set; } = false;
        
        public static async Task Mine(int delay)
        {
            
            while (IsMiningEnabled)
            {
                
                SendKeys.SendWait("{3 3}");
                await Task.Delay(delay);
            }
        }
    }
}
