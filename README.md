MB_Utils
=======

A MapBasic module that provides additional functionality by wrapping .NET and Windows API calls in easy to use mb functions and subs.


Contact:
mfcallaha@gmail.com

Documentation:

List of available functions, subs, and global vars in MB_Utils:

General utils"
Declare Sub PauseProgram(ByVal seconds As Integer)

Declare Function GetUserName() As String
Declare Function ReplaceInString(ByVal fullString As String, ByVal removeString As String, ByVal replacementString As String) As String

File I/O utils:
Declare Sub ListFiles(ByVal path As String, files() As String)
Declare Sub ListFolders(ByVal path As String, folders() As String)
Declare Sub KillTable(ByVal fullFilePath As String) As Logical

Declare Function IsTableOpen(ByVal tableName As String) As Logical
Declare Function DoesFileExist(ByVal fullFilePath As String) As Logical
Declare Function DoesFolderExist(ByVal fullPath As String) As Logical
Declare Function BrowseForFolder(ByVal startPath As String) As String

Log file utils"
Declare Sub CreateLogFile(ByVal logFilePath As String)
Declare Sub DeleteLogFile(ByVal logFilePath As String)
Declare Sub WriteToLogFile(ByVal logFilePath As String, ByVal logMsg As String)


Global vars:
Global userName As String


