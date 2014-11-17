﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiTypesApp
{

    static class Program
    {

        #region PInvoke Methods (We will discuss this later! :))
        [DllImport("kernel32", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
        #endregion
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            string mode = args.Length > 0 ? args[0] : "gui";
            if (mode == "gui")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                // Open windows form as our GUI
            }
            else if (mode == "console")
            {
                int u = 0;
                Process process = Process.GetProcessById(u);
                if (process.ProcessName == "cmd"
                       || process.ProcessName == "powershell"
                )
                {
                    // Use Current shell as our GUI
                }
                else
                {
                    //Open New console shell as our GUI.
                }
            }
        }
    }
}
