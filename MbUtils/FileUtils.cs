using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MbUtils
{
	class FileUtils
	{
		public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
		{
			foreach (DirectoryInfo dir in source.GetDirectories())
				CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
			foreach (FileInfo file in source.GetFiles())
				file.CopyTo(Path.Combine(target.FullName, file.Name));
		}

		public static void _KillTable(string fileN, ref string errStr)
		{
			try
			{
				string delPath = Path.GetDirectoryName(fileN);

				//array of MapInfo and ESRI file types that may be associated with a MapInfo table
				string[] exts =
				{
".tab", ".dat", ".ind", ".map", ".id", ".tda", ".tin", ".tma", ".xls", ".xlsx", ".txt", ".dbf", ".csv", ".mdb", ".accdb", ".shp", ".shx", ".prj",".sbn", ".sbx",".fbn", ".fbx", ".ain", ".aih", ".ixs",".mxs", ".atx", ".shp.xml", ".xml", ".cpg"
				};

				foreach (string e in exts)
				{
					string delFile = delPath + @"\" + Path.GetFileNameWithoutExtension(fileN) + e;
					if (File.Exists(delFile))
						File.Delete(delFile);
				}
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static string _FolderBrowserDialog(string dir, ref string errStr)
		{
			string path = "";
			try
			{
				//GenUtils._SetMapInfowFront();
				FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
				folderBrowser.Description = "Select Folder";
				folderBrowser.ShowNewFolderButton = true;
				folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
				folderBrowser.SelectedPath = dir;

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

		public static void _GetFiles(string dir, string[] files, int numFiles, string searchExt, int alldirs, ref string errStr)
		{
			try
			{
				dir = dir.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
				string[] dirFiles;

				if (alldirs == 1)
				{
					dirFiles = Directory.GetFiles(dir, searchExt, SearchOption.AllDirectories);
				}
				else
				{
					dirFiles = Directory.GetFiles(dir, searchExt);
				}

				for (int i = 0; i < numFiles; i++)
				{
					files[i] = dirFiles[i];
				}
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static int _NumFiles(string dir, string searchExt, int allDirs)
		{
			DirectoryInfo di = new DirectoryInfo(dir);

			if(allDirs == 1)
				return di.GetFiles(searchExt, SearchOption.AllDirectories).Length;

			return di.GetFiles(searchExt).Length;
		}

		public static void _GetFolders(string dir, string[] folders, int numFolders, ref string errStr)
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

		public static bool _DoesFolderExist(string dir, ref string errStr)
		{
			try
			{
				if (Directory.Exists(dir))
					return true;
			}
			catch(Exception ex)
			{
				errStr = ex.ToString();
			}

			return false;
		}

		public static bool _DoesFileExist(string fileN, ref string errStr)
		{
			try
			{
				if (File.Exists(fileN))
					return true;
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

			return false;
		}

		public static void _CreateFolder(string dir, ref string errStr)
		{
			try
			{
				if (!Directory.Exists(dir))
				{
					Directory.CreateDirectory(dir);
				}
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static void _DeleteFolder(string dir, ref string errStr)
		{
			try
			{
				if (Directory.Exists(dir))
					Directory.Delete(dir);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static void _DeleteFile(string dir, ref string errStr)
		{
			try
			{
				if (File.Exists(dir))
					File.Delete(dir);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static void _CopyFile(string sourcePath, string destPath, ref string errStr)
		{
			try
			{
				File.Copy(sourcePath, destPath);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static void _CopyFolder(string sourcePath, string destPath, ref string errStr)
		{
			try
			{
				DirectoryInfo source = new DirectoryInfo(sourcePath);
				DirectoryInfo dest = new DirectoryInfo(destPath);

				CopyFilesRecursively(source, dest);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

		}

		public static void _CreateFile(string filePath, ref string errStr)
		{
			try
			{
				File.Create(filePath).Dispose();
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static string _GetFileNameFromPath(string dir)
		{
			return Path.GetFileName(dir);
		}

		public static string _GetFileCreationTime(string dir, ref string errStr)
		{
			try
			{
				return File.GetCreationTime(dir).ToString(CultureInfo.InvariantCulture);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

			return "";
		}

		public static string _GetFileLastWriteTime(string dir, ref string errStr)
		{
			try
			{
				return File.GetLastWriteTime(dir).ToString(CultureInfo.InvariantCulture);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

			return "";
		}

	}//end class

}//end namespace
