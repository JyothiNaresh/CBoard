Imports System.Data
Imports System.Data.OracleClient

Public Class UserIPBlock

#Region "Class Variables"

    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String 'Result of the return type.

#End Region

#Region "Select Methods"

    Public Function UserWiseIpBlock_Select(ByVal PSLNO As Long, ByVal PADMEXAM As Char) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "M_USERWISEIPBLOCK_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PSLNO

            oParam = oComm.Parameters.Add("iADMEXAM", OracleType.Char)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PADMEXAM

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region "Insert Update Delete Methods"

    Public Function UserWiseIPBlock_Insert(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("M_USERIPNO_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iADMEXAM", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iIPADDR", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function UserWiseIPBlock_Update(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("M_USERWISEIPBLOCK_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iGWUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iIPADDR", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function UserWiseIPBlock_Delete(ByVal PGWUSERSLNO As Long, ByVal PUSERSLNO As Long, ByVal PCOUNT As Long, ByVal PADMOREXAM As Char) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("M_USERWISEIPBLOCK_DELETE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iGWUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PGWUSERSLNO

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PUSERSLNO

            oParam = oComm.Parameters.Add("iUCOUNT", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PCOUNT

            oParam = oComm.Parameters.Add("iADMOREXAM", OracleType.Char, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PADMOREXAM

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function BankStatement_TransCancel(ByVal PBANKSTATEMENTSLNO As Long, ByVal PUSERSLNO As Long) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("M_BANKSTATEMENT_TRANSCANCEL")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iBANKSTATEMENTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PBANKSTATEMENTSLNO

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PUSERSLNO

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

#End Region

End Class
