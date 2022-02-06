'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS EXAMINATION 2.0
'   OBJECTIVE                         : THIS IS MIDDLE LAYER FOR RESULTS PROCESS-
'   ACTIVITY                          : ALL
'   AUTHOR                            : HEMANTH
'   INITIAL BASELINE DATE             : 23-04-2010
'   FINAL BASELINE DATE               : 
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class IpeProcess

#Region "Class Variables"


    Private oConn As OracleClient.OracleConnection
    Private oComm As OracleClient.OracleCommand
    Private oParm As OracleClient.OracleParameter
    Private oAdap As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private Conn As Connection
    Private ReturnStr As String

#End Region

#Region "Ipe-Grades Posting"

    Public Sub IpeGradesPosting(ByVal pRESSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer, ByVal pSTATUS As Integer)
        Try
            Conn = New Connection
            oConn = Conn.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("IPEGRADESPOSTING")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParm = oComm.Parameters.Add("iRESSLNO", OracleType.Number)
            oParm.Direction = ParameterDirection.Input
            oParm.Value = pRESSLNO

            oParm = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParm.Direction = ParameterDirection.Input
            oParm.Value = pCOMACADEMICSLNO

            oParm = oComm.Parameters.Add("iSTATUS", OracleType.Number)
            oParm.Direction = ParameterDirection.Input
            oParm.Value = pSTATUS


            oComm.ExecuteNonQuery()

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not Conn Is Nothing Then Conn.Free()
        End Try

    End Sub


    Public Sub IpeMarksPosting(ByVal pRESSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer, ByVal pSTATUS As Integer)
        Try
            Conn = New Connection
            oConn = Conn.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("ipemarksposting")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParm = oComm.Parameters.Add("iRESSLNO", OracleType.Number)
            oParm.Direction = ParameterDirection.Input
            oParm.Value = pRESSLNO

            oParm = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParm.Direction = ParameterDirection.Input
            oParm.Value = pCOMACADEMICSLNO

            oParm = oComm.Parameters.Add("iSTATUS", OracleType.Number)
            oParm.Direction = ParameterDirection.Input
            oParm.Value = pSTATUS


            oComm.ExecuteNonQuery()

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not Conn Is Nothing Then Conn.Free()
        End Try

    End Sub
#End Region
End Class
