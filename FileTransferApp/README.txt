FILE TRANSFER LAB TASK - C# WINDOWS FORMS APP
===============================================

WHAT THIS APP DOES
-------------------
- SourceForm: TextBox + Label + Browse/Copy/Cut buttons.
  - Browse lets you pick a FILE or a FOLDER.
  - Copy or Cut opens the Destination window and remembers your choice.
- DestinationForm: TextBox + Label + Browse/Paste buttons.
  - Browse lets you pick the destination folder.
  - Paste copies (or moves, if you chose Cut) the previously selected
    file/folder into that destination folder.

HOW TO RUN (Windows only - WinForms requires Windows)
-------------------------------------------------------
You need the .NET 8 SDK installed (free from https://dotnet.microsoft.com/download).

OPTION 1: Visual Studio
1. Open Visual Studio.
2. File -> Open -> Project/Folder -> select this folder (FileTransferApp).
3. Press F5 (or Ctrl+F5) to build and run.

OPTION 2: Command line
1. Open a terminal / Command Prompt in this folder.
2. Run:
       dotnet run
3. The Source window will open. Click Browse, then Copy or Cut,
   then in the Destination window click Browse and then Paste.

FILES INCLUDED
--------------
FileTransferApp.csproj      - project file (targets net8.0-windows, WinForms)
Program.cs                  - app entry point (starts SourceForm)
SourceForm.cs / .Designer.cs        - source window logic + layout
DestinationForm.cs / .Designer.cs   - destination window logic + layout

NOTES
-----
- If you cut a folder into itself/its own subfolder, the app blocks it
  with an error message (this is a common mistake to demo in a lab).
- Everything is done using System.IO (File.Copy, File.Move,
  Directory.Move and a recursive folder-copy helper) - no external
  NuGet packages required.
