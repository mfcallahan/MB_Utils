using System;
using System.IO;

namespace Lam.MbUtils
{
	class Logger
	{
		public static void _CreateLogFile(string logFilePath, ref string errStr)
		{
			try
			{
				if (!Directory.Exists(logFilePath))
					Directory.CreateDirectory(logFilePath);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static void _DeleteLogFile(string logFilePath, ref string errStr)
		{
			try
			{
				if (!Directory.Exists(logFilePath))
					Directory.CreateDirectory(logFilePath);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static void _WriteToLogFile(string logFilePath, string logMsg, ref string errStr)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(logFilePath, true))
				{
					sw.WriteLine(logMsg);
				}
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}
		

	}//end class

}//end namespace
