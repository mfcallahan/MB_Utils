using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading;
using System.Windows.Forms;


namespace MbUtils
{
	public class GenUtils
    {
		//set MapInfo instance as front window
		[DllImport("User32.dll")]
		private static extern IntPtr SetForegroundWindow(int hWnd);

		public static void _SetMapInfowFront(int mihWnd)
		{
			SetForegroundWindow(mihWnd);
		}

		//sleep for t seconds
		public static void _Sleep(int t, ref string errStr)
		{
			try
			{
				Thread.Sleep(t * 1000);
			}
			catch(Exception ex)
			{
				errStr = ex.ToString();
			}
		}

    }//end class

}//end namespace