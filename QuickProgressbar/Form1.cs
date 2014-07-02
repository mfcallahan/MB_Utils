using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace GeocodeProgress
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            
            Run();
        }

        public void Run()
        {            
            pBarOn();
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = ExeDirectory;
            watcher.Filter = "geocoded.tab";
            watcher.Created += OnChanged;
            watcher.EnableRaisingEvents = true;

        }

        private static void OnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            Process[] p = Process.GetProcessesByName("MapInfow");
            if (p.Length > 0)
            {
                SetForegroundWindow((int) p[0].MainWindowHandle);
            }
            Application.Exit();
        }

        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(string ClassName, string WindowName);

        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);        

        //Progress bar on
        public void pBarOn()
        {
            this.Cursor = Cursors.WaitCursor;
            pBar.Style = ProgressBarStyle.Marquee;
            pBar.Value = 0;
            pBar.MarqueeAnimationSpeed = 25;
        }

        private static string ExeDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        
               
    }//end class

}//end namespace
