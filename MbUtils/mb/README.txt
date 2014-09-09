
+------------------------------------------+
|                                          |
|  MbUtils.mbo							   |
|  MbUtils.dll							   |
|										   |
|  MapBaisc utility functions and methods  |
|                                          |
|  updated: 6/29/14 by Matt C.             |
|                                          |
+------------------------------------------+

+------------------- Functions, Subs, and Global vars declared in MbUtils.def ------------------+

'General utils
	Declare Sub PauseProgram(ByVal seconds As Integer)

	Declare Function GetUserName() As String
	Declare Function ReplaceInString(ByVal fullString As String, ByVal removeString As String, ByVal replacementString As String) As String

'File I/O utils
	Declare Sub ListFiles(ByVal path As String, files() As String)
	Declare Sub ListFolders(ByVal path As String, folders() As String)
	Declare Sub KillTable(ByVal fullFilePath As String) As Logical
	Declare Sub CreateFolder(ByVal fullPath As String)

	Declare Function IsTableOpen(ByVal tableName As String) As Logical
	Declare Function DoesFileExist(ByVal fullFilePath As String) As Logical
	Declare Function DoesFolderExist(ByVal fullPath As String) As Logical
	Declare Function BrowseForFolder(ByVal startPath As String) As String

'Log file utils
	Declare Sub CreateLogFile(ByVal logFilePath As String)
	Declare Sub DeleteLogFile(ByVal logFilePath As String)
	Declare Sub WriteToLogFile(ByVal logFilePath As String, ByVal logMsg As String)
	

'Global vars
	Global userName As String




+---------------------------------------- General utils ----------------------------------------+

	GetUserName() Function

		Purpose: Get the Windows user name of currently logged in user
		Parameters: none
		Return value: String [Windows user name]
		Example: 
			Dim currentUser As String
			currentUser = GetUserName()		'userName will now be the Windows user name (no domain) ex: "AHSmith""
			
	PauseProgram() Sub

		Purpose: Pause execution of program for specified number of seconds
		Parameters: (seconds As Integer) [the number of seconds to pause]  
		Return value: None
		Example:
			'pause for 3 seconds if var equals -1
			If var = -1 Then
				Call PauseProgram(3)
			End If	

	ReplaceInString() Function

		Purpose: 
		Parameters: (ByVal fullString As String, ByVal removeString As String, ByVal replacementString As String)
					[the original string, the string to search for and remove, the string to replace remoteString in fullString]
		Return value: string [string with the specified values replaced]
		Example:
			Dim s, sNew As String
			s = "The car is red."
			sNew = ReplaceInString()

+--------------------------------------- File I/O utils ----------------------------------------+

	ListFiles() Sub

		Purpose: Get a list of all files in a specified folder, excluding subfolders
		Parameters: (ByVal path As String, files() As String) [full path of the folder to search, an array (passed by ref) to be populated with the list of file names]
		Return value: none
		Example:
			Dim projectFiles() As String
			ListFiles("C:\Projects\Master", projectFiles())

			'print all the files in specified folder
			Dim i As Integer
			For i = 1 To UBound(projectFiles())
				Print projectFiles(i)
			Next

	ListFolders() Sub

		Purpose: Get a list of all subfolders in a specified folder
		Parameters: (ByVal path As String, folders() As String) [full path of the folder to search, an array (passed by ref) to be populated with the list of folder names]
		Return value: none
		Example:
			Dim projectFolders() As String
			ListFiles("C:\Projects", projectFolders())

			'print all the subfolders in the specified folder
			Dim i As Integer
			For i = 1 To UBound(projectFolders())
				Print projectFolders(i)
			Next

	KillOpenTable() Sub

		Purpose: Delete a MapInfo table and any associated files*
		Parameters: (ByVal tableName As String) [name of currently open table to delete]
		Return value: none
		Example:
			KillTable("Sites1")

			*any files of the same name with these extensions:
			.tab, .dat, .ind, .map, .id, .tda, .tin, .tma, .xls, .xlsx,
			.txt, .dbf, .csv, .mdb, .accdb, .shp, .shx, .prj, .sbn, .sbx,
			.fbn, .fbx, .ain, .aih, .ixs, .mxs, .atx, .shp, .xml, .xml, .cpg

	DeleteFile() Sub

		Purpose: Delete a specified file
		Parameters: (ByVal fullFilePath As String) [the full path and file name of file to delete]
		Return value: none
		Example:
			DeleteFile("C:\Projects\log.txt")

	CreateFolder() Sub

		Purpose: Create a new folder
		Parameters: (ByVal fullPath As String) [the full path of the folder to be created]
		Return value: none
		Example:
			CreateFolder("C:\Projects\Master\temp_sites")

	DeleteFolder() Sub

		Purpose: Delete a folder
		Parameters: (ByVal fullPath As String) [the full path of the folder to be deleted]
		Return value: none
		Example:
			DeleteFolder("C:\Projects\Master\temp_sites")

	IsTableOpen() Function

		Purpose: Check if a table is currently open.
		Parameters: none
		Return value: Logical [True if the table is open in curren environment]
		Example:
			If IsTableOpen("US_States") Then
				Close Table US_States
			End If	

	DoesFileExist() Function
	
		Purpose: Check if a file exists
		Parameters: fullFilePath As String (the full path and file name, ex: "C:\Temp\Table1.TAB"
		Return value: Logical [True if the file does exist]
		Example:			
			If DoesFileExist("C:\Projects\Master\Sites2.tab") Then
				Open Table "C:\Projects\Master\Sites2.tab" As tempTable
			End If

	DoesFolderExist() Function

		Purpose: Check if a folder exists
		Parameters: fullPath As String (the full path, ex: "C:\Temp\"
		Return value: Logical [True if the folder does exist]
		Example:
			If Not DoesFolderExist("C:\Projects\Master\maps") Then
				CreateFolder("C:\Projects\Master\maps")
			End If

	BrowseForFolder() Function

		Purpose: Prompts the user with a dialog box to select a folder
		Parameters: (ByVal startPath As String) [the folder that will be pre-selected in the dialog]
		Return value: String [folder selected by the user]
		Example:
			Dim savePath As String
			savePath = BrowseForFolder("C:\Projects")

+--------------------------------------- Log file utils ----------------------------------------+

	CreateLogFile() Sub

		Purpose: Cretae a new text log file
		Parameters: (ByVal logFilePath As String) [the full path and filename of log file to be created]
		Return value: none
	
	DeleteLogFile() Sub

		Purpose: Delete a log file
		Parameters: (ByVal logFilePath As String) [the full path and filename of log file to be deleted]
		Return value: none

	WriteToLogFile() Sub

		Purpose: Write text to a log file
		Parameters: (ByVal logFilePath As String, ByVal logMsg As String) [the full path and filename of log file, text to write]
		Return value: none

		Example:			
			Dim logFile As Strinfg
			logFile = "C:\Projects\log.txt"

			If FileExists(logFile) Then
				DeleteLogFile(logFile)
			End If

			CreateLogFile(logFile)
			Call Foo()
			WriteToLogFile(logFile), "foo complete.")
			Call Bar()
			WriteToLogFile(logFile), "bar complete.")





