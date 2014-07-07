using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MbUtils.Progressbar
{
	public partial class ProgressbarForm : Form
	{
		private static readonly string _on = Path.GetDirectoryName(Application.ExecutablePath) + @"\pBarOn.mbutil";

		public ProgressbarForm(string title, string msg)
		{
			InitializeComponent();

			Cursor = Cursors.WaitCursor;
			pBar.Style = ProgressBarStyle.Marquee;
			pBar.Value = 0;
			pBar.MarqueeAnimationSpeed = 25;
			//pictureBox1.InitialImage =;

			Text = title;
			pBarLabel.Text = msg;

			File.Create(_on).Dispose();

			Run();
		}

		public static void ProgressbarEntry(string dialogTitle, string dialogText)
		{
			Thread t = new Thread(() =>
			{
				ProgressbarForm p = new ProgressbarForm(dialogTitle, dialogText);
				p.ShowDialog();
				Run();
			});

			t.SetApartmentState(ApartmentState.STA);
			t.Start();
			
		}

		private static void Run()
		{
			FileSystemWatcher watcher = new FileSystemWatcher
			{
				Path = Path.GetDirectoryName(Application.ExecutablePath),
				Filter = "pBarOn.mbutil"
			};
			watcher.Deleted += OnChanged;
			watcher.EnableRaisingEvents = true;
		}

		private static void OnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
		{
			Application.Exit();
		}
	}

}
