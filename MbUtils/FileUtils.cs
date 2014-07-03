using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MbUtils
{
	class FileUtils
	{
		//deletes all files associated with a mapinfo table
		public static void _KillTable(string fileN, ref string errStr)
		{
			try
			{
				//array of MapInfo and ESRI file types that may be found in use at LAM
				string[] exts =
				{
".tab", ".dat", ".ind", ".map", ".id", ".tda", ".tin", ".tma", ".xls", ".xlsx", ".txt", ".dbf", ".csv", ".mdb", ".accdb", ".shp", ".shx", ".prj",".sbn", ".sbx",".fbn", ".fbx", ".ain", ".aih", ".ixs",".mxs", ".atx", ".shp.xml", ".xml", ".cpg"
				};

				foreach (string e in exts)
				{
					if (File.Exists(Path.GetFileNameWithoutExtension(fileN) + e))
						File.Delete(Path.GetFileNameWithoutExtension(fileN) + e);
				}
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		//displays a folder browser dialog
		public static string _FolderBrowserDialog(string dir, ref string errStr)
		{
			string path = "";
			try
			{
				FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
				folderBrowser.Description = "Select Folder";
				folderBrowser.ShowNewFolderButton = false;
				folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
				folderBrowser.SelectedPath = dir;
				folderBrowser.ShowNewFolderButton = true;
				folderBrowser.ShowNewFolderButton = false;

				DialogResult result = folderBrowser.ShowDialog();
				if (result == DialogResult.OK)
				{
					path = folderBrowser.SelectedPath;
				}
				if (result == DialogResult.Cancel)
				{
					return "";
				}

			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

			return path;
		}

		//get array of files in a folder
		public static void _ListFiles(string dir, string[] files, int numFiles, ref string errStr)
		{
			try
			{
				string[] dirFiles = Directory.GetFiles(dir);

				for(int i = 0; i < numFiles; i++)
				{
					files[i] = Path.GetFileName(dirFiles[i]);
				}
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static int _NumFiles(string dir)
		{
			DirectoryInfo di = new DirectoryInfo(dir);
			return di.GetFiles().Length;
		}

		public static void _ListFolders(string dir, string[] folders, int numFolders, ref string errStr)
		{
			try
			{
				string[] dirs = Directory.GetDirectories(dir);

				for (int i = 0; i < numFolders; i++)
				{
					DirectoryInfo di = new DirectoryInfo(dirs[i]);
					folders[i] = di.Name;
				}
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static int _NumFolders(string dir)
		{
			DirectoryInfo di = new DirectoryInfo(dir);
			return di.GetDirectories().Length;
		}

		public static bool _DoesFolderExist(string dir)
		{
			if (Directory.Exists(dir))
				return true;

			return false;
		}

		public static bool _DoesFileExist(string fileN)
		{
			if (File.Exists(fileN))
				return true;

			return false;
		}

		public static void _CreateFolder(string dir, ref string errStr)
		{
			if (!Directory.Exists(dir))
			{
				try
				{
					Directory.CreateDirectory(dir);
				}
				catch (Exception ex)
				{
					errStr = ex.ToString();
				}
			}

		}

		public static void _DeleteFolder(string dir, ref string errStr)
		{
			if (!Directory.Exists(dir))
			{
				try
				{
					Directory.Delete(dir);
				}
				catch (Exception ex)
				{
					errStr = ex.ToString();
				}
			}

		}

		public static void _DeleteFile(string dir, ref string errStr)
		{
			if (!File.Exists(dir))
			{
				try
				{
					File.Delete(dir);
				}
				catch (Exception ex)
				{
					errStr = ex.ToString();
				}
			}

		}


	}//end class

}//end namespace
