using System;
using System.IO;
using System.Windows.Forms;

namespace MbUtils
{
	public class GenUtils
    {
		//sleep for t seconds
		public static void _Sleep(int t, ref string errStr)
		{
			try
			{
				System.Threading.Thread.Sleep(t * 1000);
			}
			catch(Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		//sample dialog box
		public static void _WinDialogBox()
		{
			MessageBox.Show(@"Hello, world!", "My Program");
		}

    }//end class

}//end namespace