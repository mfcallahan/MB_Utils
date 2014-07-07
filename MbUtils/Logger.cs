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

		public static void _DumpException(string dir, string ex)
		{
			string fileN = dir + "MbUtils_error_" + GetTimeStamp(DateTime.Now) + ".txt";

			if (File.Exists(fileN))
				File.Delete(fileN);

			using (StreamWriter sw = new StreamWriter(dir + "MbUtils_error_" + GetTimeStamp(DateTime.Now) + ".txt"))
			{
				sw.WriteLine(ex);
			}
		}

		private static string GetTimeStamp(DateTime dateTimeNow)
		{
			string suffix = dateTimeNow.ToString("yyyyMMddHHmmss");
			suffix = suffix.Replace(@":", @"-");
			suffix = suffix.Replace(@" ", @"-");
			return suffix;
		}

		private static void CleanExceptionDumpFiles()
		{
			
		}
		

	}//end class

}//end namespace
