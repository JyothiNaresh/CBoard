Imports System.IO
Imports System.Data.OleDb
Imports System.Collections
Module LogModule

    Public Sub UpdateOraObjProcessLog(ByVal str As String)

        Try

            Dim stream As StreamWriter, fileName As String, appPath As String

            appPath = "d:\ObjProcessLog\" 'Application.ExecutablePath()
            If appPath.IndexOf("\") > 0 Then
                fileName = Left(appPath, appPath.LastIndexOf("\"))
            Else
                fileName = Left(appPath, appPath.LastIndexOf("/"))
            End If

            'fileName = "F:"

            If Not Directory.Exists(fileName & "\ObjProcessLog") Then
                Directory.CreateDirectory(fileName & "\ObjProcessLog")
            End If

            stream = File.AppendText(fileName & "\ObjProcessLog\ProcessLog" & Format(Today, "dd-MM-yyyy") & ".TXT")
            stream.WriteLine(str)
            stream.Close()

        Catch ex As Exception
        End Try

    End Sub
    Public Sub UpdateObjProcessLog(ByVal str As OracleClient.OracleException)

        Try

            Dim stream As StreamWriter, fileName As String, appPath As String

            appPath = "d:\ObjProcessLog\" 'Application.ExecutablePath()
            If appPath.IndexOf("\") > 0 Then
                fileName = Left(appPath, appPath.LastIndexOf("\"))
            Else
                fileName = Left(appPath, appPath.LastIndexOf("/"))
            End If

            'fileName = "F:"

            If Not Directory.Exists(fileName & "\ObjProcessLog") Then
                Directory.CreateDirectory(fileName & "\ObjProcessLog")
            End If

            stream = File.AppendText(fileName & "\ObjProcessLog\ERRORLOG" & Format(Today, "dd-MM-yyyy") & ".TXT")
            stream.WriteLine(str)
            stream.Close()

        Catch ex As Exception
        End Try

    End Sub

    Public Sub UpdateObjProcessLog(ByVal str As Exception)

        Try

            Dim stream As StreamWriter, fileName As String, appPath As String

            appPath = "d:\ObjProcessLog\" 'Application.ExecutablePath()
            If appPath.IndexOf("\") > 0 Then
                fileName = Left(appPath, appPath.LastIndexOf("\"))
            Else
                fileName = Left(appPath, appPath.LastIndexOf("/"))
            End If

            'fileName = "F:"

            If Not Directory.Exists(fileName & "\ObjProcessLog") Then
                Directory.CreateDirectory(fileName & "\ObjProcessLog")
            End If

            stream = File.AppendText(fileName & "\ObjProcessLog\ProcessLog" & Format(Today, "dd-MM-yyyy") & ".TXT")
            stream.WriteLine(str)
            stream.Close()

        Catch ex As Exception
        End Try

    End Sub
End Module
