Imports System.Data.OracleClient
Imports System.Configuration
Imports System.Web.HttpContext

Public Class ResultConn

#Region "Constructors"

    Sub New()
        Try
            Dim conStr As String
            Con = New OracleConnection
            'conStr = ConfigurationSettings.AppSettings("ConnectionString")
            'conStr = "Data Source=ORCL;User ID=RESULT;PASSWORD=NESINDIA;"
            conStr = "Data Source=ORCL;User ID=COL_RESULT;PASSWORD=narayana;  Max Pool Size=500;"
            'conStr = "Data Source=ORCL;User ID=SCH_RESULT;PASSWORD=sch;"
            Con.ConnectionString = conStr
            Con.Open()



        Catch sex As OracleException
            Throw sex
        End Try
    End Sub

#End Region

#Region "Class Variables"
    Dim Con As OracleConnection
#End Region

#Region "Methods"

    Public Function GetConnection() As OracleConnection
        Try
            Return Con
        Catch sex As OracleException
            Throw sex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Free()
        Try
            Con.Close()

            'added by prakash on nov 16'07
            'Current.Application.Lock()
            'Current.Application("ConClose") = Current.Application("ConClose") + 1
            'Current.Application.UnLock()

        Catch sex As OracleException
            Throw sex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
