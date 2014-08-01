
using System.Net;

namespace MbUils.Updater
{
	class Program
	{
		static void Main()
		{
			//download zip from github
			DownloadFile(@"https://github.com/mfcallahan/MB_Utils/releases/download/v1.0/MB_Utils-1.0.zip", @"MB_Utils.zip");

			//unzip

		}

		private static void DownloadFile(string url, string fileName)
		{
			WebClient webClient = new WebClient();
			webClient.DownloadFile(url, fileName);
		}
	}
}
