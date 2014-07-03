
+---------------------------------------+                                     
|                                       |                                     
|  MbUtils.mbo                          |                                     
|  MbUtils.def                          |                                     
|  MbUtils.dll                          |                                     
|                                       |                                     
|	   * MB_Utils *			|
|					|                                     
|  MapBaisc utility functions and subs  |                                     
|                                       |                                     
|  updated: 7/3/14 by Matt C.           |                                     
|                                       | 
+---------------------------------------+------------------------------------+
|                                                                            |
|  To use MB_Utils:                                                          |
|                                                                            |
|  	- link module MbUtils.mbo in your MapBasic .mbp project file:        |
|  		[LINK] Application = FooBar.mbx                              |
|  		Module = MbUtils.mbo                                         |
|  		Module = Module1.mbo                                         |
|  		...                                                          |
|  			                                                     |
|  	- Include MbUtils.def in any .mb file using subs or functions	     |
|	  that are declared in MbUtils.def:				     |
|  		Include "MbUtils.def"                                        |
|                                                                            |
|  	- Copy MbUtils.dll, MbUtils.mbo, and MbUtils.def to the directory    |
|	  from which the MBX will be run.				     |
|                                                                            |
+----------------------------------------------------------------------------+

+--------- Functions, Subs, and Global vars declared in MbUtils.def ---------+

+--------------------------- General utils ----------------------------------+

GetUserName() Function

	Purpose: Get the Windows user name of currently logged in user
	Parameters: none
	Return value: String [Windows user name]
	Example: 
	
		Dim currentUser As String
		currentUser = GetUserName()	'userName will now be the
						'Windows user name (no domain)
						'ex: "AHSmith""
						
		'Optionally, use GetUserName() with Globally scoped userName
		'String variable declared in MbUtils.def
		
		userName = GetUserName()	'userName is now visible in all modules

Note2() Function
		
		Purpose: Provides an enhanced message box, adding several options to the default "Note" statement
		Parameters: (ByVal dialogTitle As String, ByVal messageText As String, iconButtons As Integer)
			        [message box title, message to display, icon and button set to display]
					iconButtons parameter values: MB_OK, MB_OKCANCEL, MB_ABORTRETRYIGNORE, MB_YESNOCANCEL, MB_YESNO, MB_RETRYCANCEL,
												  MB_ICONHAND, MB_ICONSTOP, MB_ICONQUESTION, MB_ICONEXCLAMATION, MB_ICONASTERISK, MB_ICONINFORMATION
		Reutn value: String [the button the user selected] returns: ok, cancel, abort, retry, ignore, yes, no
		Example:
			
			Dim dialogParam As Integer
			diaLogParam = MB_ABORTRETRYIGNORE + MB_ICONINFORMATION

			Dim result As String
			result = Note2("My Application", "Critical failure. Abort, retry, ignore?", dialogParam)

			Do Case result
				Case "abort"
					Exit Sub
				Case "retry"
					Call Foo()
				Case "ignore"
					Call Bar()
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

ReplaceInString() Function

	Purpose: Replace a substring with another string, from within a string
	Parameters: (ByVal fullString As String, ByVal removeString As String, ByVal replacementString As String)
		    [the original string, the string to search for and remove, the string to replace remoteString in fullString]
	Return value: string [string with the specified values replaced]
	Example:
	
		Dim s, sNew As String
		s = "The car is red."
		sNew = ReplaceInString()

WindowRemoveCloseButton()

	Purpose: Remove the close [X] button on a custon dialog box
	Parameters: (ByVal winId As Integer) [the window ID of dialog to modfiy]
	Return value: none
	Example:

		Call WindowRemoveCloseButton(FrontWindow())

+----------------------------- File I/O utils -------------------------------+

BrowseForFolder() Function

	Purpose: Prompts the user with a dialog box to select a folder
	Parameters: (ByVal startPath As String) [the folder that will be pre-selected in the dialog]
	Return value: String [folder selected by the user]
	Example:
	
		Dim savePath As String
		savePath = BrowseForFolder("C:\Projects")

CreateFolder() Sub

	Purpose: Create a new folder
	Parameters: (ByVal fullPath As String) [the full path of the folder to be created]
	Return value: none
	Example:
	
		Call CreateFolder("C:\Projects\Master\temp_sites")

DeleteFile() Sub

	Purpose: Delete a specified file
	Parameters: (ByVal fullFilePath As String) [the full path and file name of file to delete]
	Return value: none
	Example:
	
		Call DeleteFile("C:\Projects\temp\log.txt")

DeleteFolder() Sub

	Purpose: Delete a folder
	Parameters: (ByVal fullPath As String) [the full path of the folder to be deleted]
	Return value: none
	Example:
	
		Call DeleteFolder("C:\Projects\Master\temp_sites")

DoesFileExist() Function

	Purpose: Check if a file exists
	Parameters: fullFilePath As String (the full path and file name, ex: "C:\Temp\Table1.TAB"
	Return value: Logical [True if the file does exist]
	Example:
	
		If DoesFileExist("C:\Projects\Master\Sites2.txt") Then
			Open Table "C:\Projects\Master\Sites2.txt" As tempTable
		End If

DoesFolderExist() Function

	Purpose: Check if a folder exists
	Parameters: fullPath As String (the full path, ex: "C:\Temp\"
	Return value: Logical [True if the folder does exist]
	Example:
	
		If Not DoesFolderExist("C:\Projects\Master\maps") Then
			Call CreateFolder("C:\Projects\Master\maps")
		End If
		
IsTableOpen() Function

	Purpose: Check if a table is currently open.
	Parameters: none
	Return value: Logical [True if the table is open in curren environment]
	Example:
	
		If IsTableOpen("US_States") Then
			Close Table US_States
		End If	

KillOpenTable() Sub

	Purpose: Delete a MapInfo table and any associated files*
	Parameters: (ByVal tableName As String) [name of currently open table to delete]
	Return value: none
	Example:
	
		Call KillOpenTable("Sites1")

		*any files of the same name with these extensions:
		.tab, .dat, .ind, .map, .id, .tda, .tin, .tma, .xls, .xlsx,
		.txt, .dbf, .csv, .mdb, .accdb, .shp, .shx, .prj, .sbn, .sbx,
		.fbn, .fbx, .ain, .aih, .ixs, .mxs, .atx, .shp, .xml, .xml, .cpg

ListFiles() Sub

	Purpose: Get a list of all files (file name + extension only, not full path) in a specified folder, excluding subfolders
	Parameters: (ByVal path As String, files() As String)
		    [full path of the folder to search, 
		     an array (passed by ref) to be populated with the list of file names]
	Return value: none
	Example:
	
		Dim projectFiles() As String
		Call ListFiles("C:\Projects\Master", projectFiles())

		'print all the files in specified folder
		Dim i As Integer
		For i = 1 To UBound(projectFiles())
			Print projectFiles(i)
		Next

ListFolders() Sub

	Purpose: Get a list of all subfolders (folder names only, not full paths) in a specified folder
	Parameters: (ByVal path As String, folders() As String)
		    [full path of the folder to search,
		    an array (passed by ref) to be populated with the list of folder names]
	Return value: none
	Example:
	
		Dim projectFolders() As String
		Call ListFolders("C:\Projects", projectFolders())

		'print all the subfolders in the specified folder
		Dim i As Integer
		For i = 1 To UBound(projectFolders())
			Print projectFolders(i)
		Next

+------------------------------ Log file utils ------------------------------+

WriteToLogFile() Sub

	Purpose: Write text to a log file. 
	Parameters: (ByVal logFilePath As String, ByVal logMsg As String)
		    [the full path and filename of log file, text to write]
		    *If the specifed path/file for logFilePath does not exist, it will be created.
	Return value: none

	Example:
	
		Dim logFile As Strinfg
		logFile = "C:\Projects\log.txt"

		If FileExists(logFile) Then
			DeleteLogFile(logFile)
		End If

		CreateLogFile(logFile)
		Call Foo()
		Call WriteToLogFile(logFile), "foo complete.")
		Call Bar()
		Call WriteToLogFile(logFile), "bar complete.")

+--------------------------------- Global vars -------------------------------+

Global userName As String
	
	Purpose: To expose the Windows username application-wide.  Use with GetUserName() Function.
	Example:
		
		userName = GetUserName()	'variable already declared in MbUtils.def



