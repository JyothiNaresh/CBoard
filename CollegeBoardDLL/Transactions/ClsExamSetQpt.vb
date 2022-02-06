'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exam Category
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 11-OCT-2006
'   FINAL BASELINE DATE               : 11-OCT-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsExamSetQpt

#Region "Common Variables"
    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private Result As String
    Private ObjConn As Connection

#End Region


#Region "ComboFilling"

    Public Function FillGridCombos(ByVal StrStoreProcedure As String, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOMBINATIONKEY As String, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter
            oCommand.CommandText = StrStoreProcedure
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSTR
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iCOMBINATIONKEY
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMBINATIONKEY

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

#End Region

#Region "ExamSetQpt"


    Public Function ExamSetQpt_SELECT(ByVal STRSQL As String) As DataSet
        Try
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "ESQPTMT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iSTR
            oParameter = oCommand.Parameters.Add("iSTR", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            If STRSQL Is Nothing Then STRSQL = ""
            oParameter.Value = STRSQL

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function


    Public Function ExamSetQptEDITSELECT(ByVal iESQPTSLNO As Integer) As DataSet
        Try
            ds = New DataSet


            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "ESQPTMTEDITSELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iESQPTSLNO
            oParameter = oCommand.Parameters.Add("iESQPTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iESQPTSLNO


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamCatsetQpt")

            Return ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function


    Public Function ExamSetQpt_Save(ByVal ValuesDset As DataSet) As String
        Dim rtnString As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            rtnString = ExamSetQpt_Insert(ValuesDset, oConn, oTrans)
            oTrans.Commit()
            rtnString = "Record Saved"

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            'rtnString = "Fail"
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function ExamSetQpt_Insert(ByVal ValuesDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "ESQPTMT_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            uCommand.CommandText = "ESQPTMT_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = pTrans



            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iEXAMCATESLNO
            oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMCATESLNO"


            'ADD IN PARAMETER NAME iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MTSETSLNO"

            'ADD IN PARAMETER NAME iQPTMTSLNO
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            oAdapter.InsertCommand = oCommand


            'ADD IN PARAMETER NAME iESQPTSLNO
            oParameter = uCommand.Parameters.Add("iESQPTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ESQPTSLNO"

            'ADD IN PARAMETER NAME iEXAMCATESLNO
            oParameter = uCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMCATESLNO"

            'ADD IN PARAMETER NAME iMTSETSLNO
            oParameter = uCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MTSETSLNO"

            'ADD IN PARAMETER NAME iQPTMTSLNO
            oParameter = uCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(ValuesDset, "ExamCatsetQpt")

            Result = "Records Saved"
            Return Result

        Catch ex As Exception
            Throw ex
            'Result = "Fail"
        Finally

        End Try

    End Function


    Public Function ExamSetQpt_Delete(ByVal iESQPTSLNO As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "ESQPTMT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSTR
            oParameter = oCommand.Parameters.Add("iESQPTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iESQPTSLNO

            oCommand.ExecuteNonQuery()

            Return "Record Deleted"

        Catch ex As Exception
            Throw ex
        Catch ex As Exception
            '' Throw ex
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
#End Region

End Class
