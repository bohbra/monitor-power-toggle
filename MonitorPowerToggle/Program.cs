using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace MonitorPowerToggle
{
    class Program
    {
        static void Main(string[] args)
        {
            var arg = args.FirstOrDefault();       

            if (arg == null)
            {
                System.Console.WriteLine("Please enter a valid argument");
                Console.Read();
                return;
            }

            var monitorState = arg == "-on" ? MonitorState.MonitorStateOn : MonitorState.MonitorStateOff;
            
            // turn monitor off
            SetMonitorState(monitorState);
        }
        
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        private static void SetMonitorState(MonitorState state)
        {
            SendMessage(0xFFFF, 0x112, 0xF170, (int)state);
        }
    }
}
