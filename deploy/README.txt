+-----------------------------------+

*    MB_Utils ver 1.1    *
A MapBasic extension module.

MbUtils.mbo
MbUtils.def
MbUtils.dll
MbUtils.Progressbar.exe

updated: 7/27/14 by Matt C.

+-----------------------------------+


+----------------------------------------  Using MB_Utils  -----------------------------------------+


• link module MbUtils.mbo in your MapBasic .mbp project file:

	[LINK] Application = MyApplication.mbx
	Module = MbUtils.mbo
	Module = Module1.mbo
	Module = Module2.mbo
	...

• Include MbUtils.def in any .mb file using subs or functions that are declared in MbUtils.def:

	Include "MbUtils.def"

• Copy MbUtils.dll (and MbUtils.Progressbar.exe if using a progress bar) to the directory
  from which the MBX will be run. 


+----------------------------------------  Error Handling  -----------------------------------------+


MB_Utils has built-in error handling for all subs and functions declared in MbUtils.def.  Should a call 
to a function or sub fail, the user will be presented with a dialog box noting the details of the error 
that occured and the option to abort the program, retry execution of the code that failed, or ignore and 
continue execution of the program.  In addition to the error dialog on screen, full details of the error 
are dumped to a text file via a call to the internal _DumpException() method.  Dump files will be saved 
to the directory from which the MBX was run, and are named "MbUtils_error_" + datestamp.


+----------------------------  Functions and Subs Declared in MB_Utils  ----------------------------+


+---------------  General utils  --------------+


GetMbUtilsVer() Function

	Purpose: Get the version of the current MbUtils module
	Parameters: none
	Return value: String [the version number]
	Example:
	
		Dim ver As String
		ver = GetMbUtilsVersion()
		Print "MbUtils version = " + ver	'output: "MbUtils version = X.X"
		


GetUserName() Function

	Purpose: Get the Windows user name of currently logged in user
	Parameters: none
	Return value: String [Windows user name]
	Example: 
	
		Dim currentUser As String
		currentUser = GetUserName()		'userName will now be the Windows user name (no domain) ex: "JPage1"
							

Note2() Function
		
	Purpose: Provides a simple enhanced message box, adding several options to the default "Note" statement
	Parameters: (ByVal dialogTitle As String, ByVal dialogText As String, ByVal dialogType As String)
				[message box title, message to display, dialog type to display]
				* dialogType parameter values = { "OK", "OKCANCEL", "YESNO", "YESNOCANCEL", "RETRYCANCEL", "ABORTRETRYIGNORE" }
	Return value: String [the button the user selected]
				  * return values = { "ok", "cancel", "abort", "retry", "ignore", "yes", "no" }
	Example:
		Dim result As String
		result = Note2("My Application", "Critical error. Abort, retry, ignore?", "ABORTRETRYIGNORE")

		Do Case result
			Case "abort"
				Exit Sub
			Case "retry"
				Goto retry
			Case "ignore"
				Call Foo()
		End Case
		
	
PauseProgram() Sub

	Purpose: Pause execution of program for specified number of seconds
	Parameters: (seconds As Integer) [the number of seconds to pause]  
	Return value: None
	Example:
	
		'pause for 3 seconds if var equals -1
		If var = -1 Then
			Call PauseProgram(3)
		End If
		
		
QuickProgressbarOn() Sub
	
	Purpose: Display a marquee style (continuously scrolling) progress bar that will not freeze during a lengthy operation
	Parameters: (ByVal dialogTitle As String, ByVal messageText As String)
				[text for progress bar title bar, text for progress bar message]
	Return value: none
	Example:
		
		Call QuickProgressbarOn("My Application", "Doing important stuff...")
		
		'FooBar() represents a lengthy operation that may freeze up the MapInfo UI
		Call FooBar()
		
		Call QuickProgressbarOff()

	
		
QuickProgressbarOff() Sub
	
	Purpose: Display a marquee style (continuously scrolling) progress bar during a lengthy operation
	Parameters: none
	Return value: none
	Example: (see QuickProgressbarOn() Sub above)
	
	
+---------------  Array utils  ---------------+


ClearArray() Sub

	Purpose: Clear all index values of a string array with a specified value
	Parameters: (stringArray() As String, ByVal clearValue As String)
				[a string array of values to clear, the value to seat all array indexs equal to]
	Return value: none
	Example:
	
		Call ClearArray(values(), "none")		'all index values for values() will now be empty strings


		
CopyArray() Sub

	Purpose: Copy the contents of a string array to another string array
	Parameters: (sourceArray() As String, destinationArray() As String)
				[the array to copy, an array to populate with the values of sourceArray()]
	Return value: none
	Example:
	
		Dim values1(), values2() As String
		Dim i As Integr
		For i = 1 To 10
			ReDim values1(i)
			value1s(i) = i			
		Next
		
		Call CopyArray(values1(), values2())
		
		'values2() will now be the same length and contain the same values as values1()
		For i = 1 To 10
			Print values2(i)		
		Next


ForEachInArray() Sub

	Purpose: Interate through each string in a string array and a perform a command on each.

		
Declare Sub ForEachInArray(stringArray() As String, ByVal runCmd As String)





Declare Sub SortArray(stringArray() As String, sortOrder As String)

Declare Function ArrayToString(stringArray() As String) As String
Declare Function ArrayToDelimitedString(stringArray() As String, ByVal delimiter As String) As String
Declare Function IndexOf(stringArray() As String, ByVal searchString As String) As Integer	



+--------------  File I/O utils  -------------+


BrowseForFolder() Function

	Purpose: Prompts the user with a dialog box to select a folder
	Parameters: (ByVal startPath As String) [the folder that will be pre-selected in the dialog]
	Return value: String [folder selected by the user]
	Example:
	
		Dim savePath As String
		savePath = BrowseForFolder("C:\Projects")
		Print "savePath = " + savePath							'ex Print output: "C:\Projects\Master\all_sites"
		Commit Table sites1 As savePath + "\sites_new.tab"		
		
		
CopyFile() Sub
	
	Purpose: make a copy of a file
	Parameters: (ByVal filePathSource As String, ByVal filePathDest As String) [source file, destination file]
	Return value: none
	Example:
	
		If Not DoesFileExist("C:\Projects\master\Sites1.jpg") Then
			CopyFile("C:\pictures\Sites1.jpg", "C:\Projects\master\Sites1.jpg")
		End If
		

CreateFile() Sub

	Purpose: Create a new file
	Parameters: (ByVal filePath As String) [the full path and file name of the file to create]
	Return value: none
	Example:
	
		If Not DoesFileExist("C:\Temp\sites1.txt") Then
			Call CreateFile("C:\Temp\sites1.txt")
		End If
		
	
CopyFolder() Sub

	Purpose: copy a folder and its contents
	Parameters: (ByVal fullPathSource As String, ByVal fullPathDest As String)
				[the full path of the folder to copy, the full path of the destination location]
	Return value: none
	Example:
	
		'You can pass a string representing the folder path with or without a trailing slash 
	
		Call CopyFolder("C:\Projects\maser", "C:\Projects\backup\July\master")
				

CreateFolder() Sub

	Purpose: Create a new, empty folder
	Parameters: (ByVal folderPath As String) [the full path of the folder to be created]
	Return value: none
	Example:
	
		'You can pass a string representing the folder path with or without a trailing slash 
	
		Call CreateFolder("C:\Projects\Master\temp_sites")
		
		'same result:
		Call CreateFolder("C:\Projects\Master\temp_sites\")
		
		
DeleteFile() Sub

	Purpose: Delete a specified file
	Parameters: (ByVal filePath As String) [the full path and file name of file to delete]
	Return value: none
	Example:
	
		Call DeleteFile("C:\Projects\temp\log.txt")
		

DeleteFolder() Sub

	Purpose: Delete a folder
	Parameters: (ByVal folderPath As String) [the full path of the folder to be deleted]
	Return value: none
	Example:
	
		'You can pass a string representing the folder path with or without a trailing slash 
		Call DeleteFolder("C:\Projects\Master\temp_sites")
		
		'same result:
		Call DeleteFolder("C:\Projects\Master\temp_sites\")
		

DoesFileExist() Function

	Purpose: Check if a file exists
	Parameters: (ByVal fullFilePath As String) [the full path and file name]
	Return value: Logical [True if the file does exist]
	Example:
	
		If DoesFileExist("C:\Projects\Master\Sites2.txt") Then
			Call DeleteFile("C:\Projects\Master\Sites2.txt")
		End If
		

DoesFolderExist() Function

	Purpose: Check if a folder exists
	Parameters: (ByVal folderPath As String) [the full folder path]
	Return value: Logical [True if the folder does exist]
	Example:
	
		If Not DoesFolderExist("C:\Projects\Master\maps") Then
			Call CreateFolder("C:\Projects\Master\maps")			
		End If
		
		
GetFiles() Sub

	Purpose: Get a list of all files (not full path and filename) in a specified folder
	Parameters: (ByVal filePath As String, files() As String, ByVal searchExt As String, ByVal searchAllDirs As Logical)
				[full path of the folder to search,
				an array (passed by ref) to be populated with the list of file names,
				a file extension search pattern ex: "*.*" to search for for all files or "*.txt" for just text files,
				True to recursively search all subfolders within fullPath or False to search fullPath only]
			 
	Return value: none
	Example:
	
		Dim fileList() As String
		Call GetFiles("C:\Windows\Temp", fileList(), "*.*", False)

		'print all the files in specified folder, exlcuding files in subfolders
		Dim i As Integer
		For i = 1 To UBound(fileList())
			Print fileList(i)
		Next


GetFileCreationTime() Function
			
		Purpose: Get the creation time of a specified file
		Parameters: (ByVal fullFilePath As String) [the full path and filename]
		Return value: String [date and time ex: "04/20/2014 10:59:16"]
		Example:
		
			Dim createTime As String
			createTime = GetFileCreationTime(ApplicationDirectory$() + "Sites2.txt")
			
			
GetFileLastWriteTime() Function

	Purpose: Get the last write time of a specified file
	Parameters: (ByVal fullFilePath As String) [the full path and filename]
	Return value: String [date and time ex: "07/08/2014 22:45:07"]
	Example:
		
			Dim editTime As String
			editTime = GetFileLastWriteTime(ApplicationDirectory$() + "Sites2.txt")
			
			
GetFolders() Sub

	Purpose: Get a list of all subfolders (folder names only, not full paths) in a specified folder
	Parameters: (ByVal folderPath As String, folders() As String)
		    [full path of the folder to search,
		    an array (passed by ref) to be populated with the list of folder names]
	Return value: none
	Example:
	
		'You can pass a string representing the folder path with or without a trailing slash 
		
		Dim projectFolders() As String
		Call GetFolders("C:\Projects", projectFolders())

		'print all the subfolders in the specified folder
		Dim i As Integer
		For i = 1 To UBound(projectFolders())
			Print projectFolders(i)
		Next
		
		
IsTableOpen() Function

	Purpose: Check if a table is currently open.
	Parameters: (ByVal tableName As String) [the name of a table]
	Return value: Logical [True if the table is open in current environment]
	Example:
	
		If IsTableOpen("Sites1") Then
			Close Table Sites1
		End If	
		

KillTable() Sub

	Purpose: Delete a MapInfo table and any associated files*
	Parameters: (ByVal fullTablePath As String) [name of MapInfo table to delete completely]
	Return value: none
	Example:
	
		Close Table "Sites1"
		Call KillTable("C:\Windows\Temp\Sites1.tab")

		*any files of the same name with these extensions:
		{ .tab, .dat, .ind, .map, .id, .tda, .tin, .tma, .xls, .xlsx,
		.txt, .dbf, .csv, .mdb, .accdb, .shp, .shx, .prj, .sbn, .sbx,
		.fbn, .fbx, .ain, .aih, .ixs, .mxs, .atx, .shp, .xml, .xml, .cpg }
		

ListOpenTables() Sub

	Purpose: List all open tables in the current Mapinfo environment
	Parameters: (openTables() As String) [a string array (passed by ref) to be populated with the names of the open tables]
	Return value: none
	Example:
	
		Dim worTables() As String
		Call ListOpenTables(worTables())
		
		Dialog
			Title "Select Table"
		Control PopupMenu
			Title From Variable worTables()


WriteToLogFile() Sub

	Purpose: Write text to a log file. If the specifed path/file for logFilePath does not exist, it will be created.
	Parameters: (ByVal logFilePath As String, ByVal logMsg As String) [the full path and filename of log file, text to write]
	Return value: none
	Example:
	
		Dim logFile As Strinfg
		logFile = "C:\Projects\log.txt"

		If FileExists(logFile) Then
			DeleteLogFile(logFile)
		End If

		Call Foo()
		Call WriteToLogFile(logFile), "foo complete.")
		Call Bar()
		Call WriteToLogFile(logFile), "bar complete.")
		


+--------------  String utils  ---------------+
		
		

ReplaceInString() Function

	Purpose: Replace all occurances of a specified substirng within a string
	Parameters: (ByVal fullString As String, ByVal removeString As String, ByVal repalceString  As String)
				[the original string, the string to search for and remove, the string to replace removeString in fullString]
	Return value: String [string with the specified values replaced]
	Example:
	
		Dim stringOrig, stringNew As String
		stringOrig = "The car is red."
		stringNew = ReplaceInString(stringOrig, "car", "truck")
		Print stringNew		'output will be "The truck is red."
		

		