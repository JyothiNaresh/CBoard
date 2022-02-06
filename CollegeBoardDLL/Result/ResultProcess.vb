'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS EXAMINATION 2.0
'   OBJECTIVE                         : THIS IS MIDDLE LAYER FOR RESULTS PROCESS
'   ACTIVITY                          : ALL
'   AUTHOR                            : HEMANTH
'   INITIAL BASELINE DATE             : 01-04-2010
'   FINAL BASELINE DATE               : 
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ResultProcess

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oComm As OracleClient.OracleCommand
    Private oParm As OracleClient.OracleParameter
    Private oAdap As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ResConn As ResultConn
    Private ReturnStr As String

#End Region

#Region "Methods"

    Public Sub QryExec(ByVal QryStr As String)
        Try
            ResConn = New ResultConn
            oConn = ResConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand(QryStr)
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.Text

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            ReturnStr = "SUCCESS"

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ResConn Is Nothing Then ResConn.Free()
        End Try

    End Sub

    Public Sub Delete_TempFiles()
        Try
            ResConn = New ResultConn
            oConn = ResConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("TEMPDELETE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oComm.ExecuteNonQuery()

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ResConn Is Nothing Then ResConn.Free()
        End Try

    End Sub

    Public Sub Create_TempFiles()
        Try
            ResConn = New ResultConn
            oConn = ResConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("TEMPCREATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oComm.ExecuteNonQuery()

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ResConn Is Nothing Then ResConn.Free()
        End Try

    End Sub

    Public Sub PrepareHallticketGrade(ByVal pHtnoperline As Integer, ByVal pRESSLNO As Integer)
        Try
            ResConn = New ResultConn
            oConn = ResConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("HTNOINSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParm = oComm.Parameters.Add("iNOCOL", OracleType.Number)
            oParm.Direction = ParameterDirection.Input
            oParm.Value = pHtnoperline

            oParm = oComm.Parameters.Add("iRESSLNO", OracleType.Number)
            oParm.Direction = ParameterDirection.Input
            oParm.Value = pRESSLNO

            oComm.ExecuteNonQuery()

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ResConn Is Nothing Then ResConn.Free()
        End Try

    End Sub

#End Region

End Class
