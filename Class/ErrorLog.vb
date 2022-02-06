Imports System.IO
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports System.Xml
Imports System.Text
Imports System.Web.Services.Protocols
Imports System.Collections
Imports System.Web.HttpRequest
Imports System.Web.HttpServerUtility
Imports System.Web.HttpApplication
Imports System.Web.UI.Page


Public Class ErrorLog

#Region "Declarations"
    Private Shared ErrorNo As Integer = 1
    Private Shared _FileName As String = ""
    Public Shared Information = "Information"
    Public Shared FatalError = "FatalError"
    Public Shared Warning = "Warning"
#End Region

#Region "Properties"

    Public Shared Property FileName() As String

        Get
            If _FileName = "" Then
                Dim AppPath = ConfigurationSettings.AppSettings("ApplicationPath")
                'Dim AppPath = Server.MapPath
                _FileName = "ErrorLog - " + Format(Now(), "yyyy-MM-dd") + ".txt"
                _FileName = AppPath & "\Log\" + _FileName
            End If
            Return _FileName
        End Get

        Set(ByVal Value As String)
            Dim AppPath = ConfigurationSettings.AppSettings("ApplicationPath")
            _FileName = Value + " - " + Format(Now(), "yyyy-MM-dd") + ".txt"
            _FileName = AppPath & "\Log\" + _FileName
        End Set

    End Property

#End Region

#Region "Methods"


    Public Function asr()
        Try
            Directory.CreateDirectory(FileName())
        Catch ex As Exception

        End Try
    End Function

    Public Shared Sub Log(ByVal excep As Exception, ByVal Message As String)

        SyncLock GetType(ErrorLog)
            Try
                Dim FStream As FileStream
                Try
                    FStream = New FileStream(ErrorLog.FileName, FileMode.Append, FileAccess.Write)
                Catch ex As IOException
                    FStream = New FileStream(ErrorLog.FileName, FileMode.Append, FileAccess.Write)
                Catch ex As Exception
                    ErrorLog.Log(ex)
                End Try
                Dim timeStamp As String
                timeStamp = Format(Now(), "H:m:s")
                Dim wtr As New StreamWriter(FStream)
                wtr.WriteLine("")
                wtr.WriteLine("Error Number  : " + ErrorNo.ToString)
                ErrorNo = ErrorNo + 1
                wtr.WriteLine("")
                wtr.WriteLine("Time           : " + timeStamp)
                wtr.WriteLine("")
                wtr.WriteLine("Message        : " + Message)
                wtr.WriteLine("")
                wtr.WriteLine("ToString       : " + vbLf + vbLf + excep.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("Source         : " + excep.Source.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("StackTrace     : " + vbLf + vbLf + excep.StackTrace.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("TargetSite     : " + excep.TargetSite.ToString)
                wtr.WriteLine("-------------------------------------------------------------------------------------------------------------")
                wtr.Close()
                FStream.Close()
            Catch ex As Exception
                ErrorLog.Log(ex)
            End Try
        End SyncLock

    End Sub

    Public Shared Sub Log(ByVal excep As Exception)

        SyncLock GetType(ErrorLog)
            Try
                Dim FStream As FileStream
                Try
                    FStream = New FileStream(ErrorLog.FileName, FileMode.Append, FileAccess.Write)
                Catch ex As IOException
                    Dim d As Directory
                    d.CreateDirectory(ConfigurationSettings.AppSettings("ApplicationPath") & "\Log")
                    FStream = New FileStream(ErrorLog.FileName, FileMode.Append, FileAccess.Write)
                Catch ex As Exception
                    ErrorLog.Log(ex)
                End Try
                Dim timeStamp As String
                timeStamp = Format(Now(), "H:m:s")
                Dim wtr As New StreamWriter(FStream)
                wtr.WriteLine("")
                wtr.WriteLine("Error Number           : " + ErrorNo.ToString)
                ErrorNo = ErrorNo + 1
                wtr.WriteLine("")
                wtr.WriteLine("Time           : " + timeStamp)
                wtr.WriteLine("")
                wtr.WriteLine("Message        : " + excep.Message)
                wtr.WriteLine("")
                wtr.WriteLine("ToString       : " + vbLf + vbLf + excep.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("Source         : " + excep.Source.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("StackTrace     : " + vbLf + vbLf + excep.StackTrace.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("TargetSite     : " + excep.TargetSite.ToString)
                wtr.WriteLine("-------------------------------------------------------------------------------------------------------------")
                wtr.Close()
                FStream.Close()
            Catch ex As Exception
                ErrorLog.Log(ex)
            End Try
        End SyncLock

    End Sub

    Public Shared Sub Log(ByVal excep As OracleClient.OracleException)

        SyncLock GetType(ErrorLog)
            Try
                Dim FStream As FileStream
                Try
                    FStream = New FileStream(ErrorLog.FileName, FileMode.Append, FileAccess.Write)
                Catch ex As IOException
                    Dim d As Directory
                    d.CreateDirectory(ConfigurationSettings.AppSettings("ApplicationPath") & "\Log")
                    FStream = New FileStream(ErrorLog.FileName, FileMode.Append, FileAccess.Write)
                Catch ex As Exception
                    ErrorLog.Log(ex)

                End Try


                Dim timeStamp As String
                timeStamp = Format(Now(), "H:m:s")
                Dim wtr As New StreamWriter(FStream)
                wtr.WriteLine("")
                wtr.WriteLine("Error Number           : " + ErrorNo.ToString)
                ErrorNo = ErrorNo + 1
                wtr.WriteLine("")
                wtr.WriteLine("Time           : " + timeStamp)
                wtr.WriteLine("")
                'wtr.WriteLine("Number         : " + excep.Number.ToString)
                'wtr.WriteLine("")
                wtr.WriteLine("Message        : " + excep.Message.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("ToString       : " + vbLf + vbLf + excep.ToString)
                wtr.WriteLine("")
                'wtr.WriteLine("Procedure      : " + excep.Procedure.ToString)
                'wtr.WriteLine("")
                'wtr.WriteLine("Server         : " + excep.Server.ToString)
                'wtr.WriteLine("")
                wtr.WriteLine("StackTrace     : " + vbLf + vbLf + excep.StackTrace.ToString)
                wtr.WriteLine("")
                'wtr.WriteLine("LineNumber     : " + excep.LineNumber.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("Source         : " + excep.Source.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("TargetSite     : " + excep.TargetSite.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("State          : " + excep.StackTrace.ToString)
                wtr.WriteLine("")
                wtr.WriteLine("-------------------------------------------------------------------------------------------------------------")
                wtr.Close()
                FStream.Close()
            Catch ex As Exception
                ErrorLog.Log(ex)

            End Try
        End SyncLock

    End Sub

#End Region


End Class
