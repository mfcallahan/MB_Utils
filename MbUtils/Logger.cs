using System;
using System.IO;

namespace MbUtils
{
	class Logger
	{
		public static void _WriteToLogFile(string logFilePath, string logMsg, ref string errStr)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(logFilePath))
				{
					sw.WriteLine(logMsg);
				}
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static void _DumpException(string dir, string ex)
		{
			using (StreamWriter sw = new StreamWriter(dir + "error_" + GetTimestamp(DateTime.Now) + ".txt"))
			{
				sw.WriteLine(ex);
			}
		}

		private static string GetTimestamp(DateTime value)
		{
			return value.ToString("yyyyMMddHHmmssffff");
		}

		private static string CleanExceptionDumpFiles()
		{
			
		}
		

	}//end class

}//end namespace
