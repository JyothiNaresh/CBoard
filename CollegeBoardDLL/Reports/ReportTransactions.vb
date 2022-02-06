' FIELE CREATED BY          : J.HIMAVANTHARAO
' PURPOSE                   : USING IN E-MAIL PROGRESS CARD
' DATE                      : 31-AUG-2009

Imports System.Data
Imports System.Data.OracleClient

Public Class ReportTransactions

#Region "Class Variables"

    Private oConn As OracleConnection  'Connection Object Declaration.
    Private oComm As OracleCommand  'Command Object Declaration.
    Private oAdap As OracleDataAdapter  'Adapter Object Declaration.
    Private oParam As OracleParameter  'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private oTrans As OracleTransaction

#End Region

#Region "Email Progress Card and Errorlist "

    Public Function Email_Save(ByVal PCMDDset As DataSet, ByVal EDS As DataSet) As String
        Dim rtnString As String
        Dim RtnVal As Integer
        Try
            Dim setResult As String

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(PCMDDset) AndAlso PCMDDset.Tables(0).Rows.Count > 0 Then

                RtnVal = eMail_Sent_Save(PCMDDset, oConn, oTrans)
                If RtnVal = 1 Then
                    RtnVal = eMail_Sent_Exam_Save(EDS, oConn, oTrans)
                    rtnString = 1
                    oTrans.Commit()
                    rtnString = "Record Saved"
                Else
                    oTrans.Rollback()
                    rtnString = "Record Not Saved"
                End If

            End If

            

        Catch ex As Exception
            oTrans.Rollback()
            'rtnString = ex.Message.ToString
            Throw ex
            'rtnString = "Set Not Saved"
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnString
    End Function

    Private Function eMail_Sent_Save(ByVal pDs As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Integer
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand
            oParam = New OracleClient.OracleParameter

            Dim iCommand As New OracleClient.OracleCommand




            oComm.CommandText = "EXAM_EMAILSENT"
            oComm.Connection = pConn
            oComm.Transaction = pTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMBINATIONKEY"

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ADMSLNO"

            oParam = oComm.Parameters.Add("iEMAIL", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EMAIL"

            oParam = oComm.Parameters.Add("iEXAMDESCRIPTION", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EXAMDESCRIPTION"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oParam = oComm.Parameters.Add("iISERRORLIST", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ISERRORLIST"

            oParam = oComm.Parameters.Add("iISPROGRESS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ISPROGRESS"

            oAdap.InsertCommand = oComm
            oAdap.Update(pDs, pDs.Tables(0).TableName)

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function eMail_Sent_Exam_Save(ByVal pDs As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Integer
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand
            oParam = New OracleClient.OracleParameter

            Dim iCommand As New OracleClient.OracleCommand




            oComm.CommandText = "EXAM_EXAMWISEEMAIL_UPDATE"
            oComm.Connection = pConn
            oComm.Transaction = pTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "DEXAMSLNO"

            oParam = oComm.Parameters.Add("iEPROGRESS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EPROGRESS"


            oParam = oComm.Parameters.Add("iEERRORLIST", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EERRORLIST"

            oAdap.InsertCommand = oComm
            oAdap.Update(pDs, pDs.Tables(0).TableName)

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function SMS_Save(ByVal PCMDDset As DataSet, ByVal Dexamslno As Integer) As String
        Dim rtnString As String
        Dim RtnVal As Integer
        Try
            Dim setResult As String

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(PCMDDset) AndAlso PCMDDset.Tables(0).Rows.Count > 0 Then

                RtnVal = SMS_Sent_Save(PCMDDset, oConn, oTrans)

            End If

            rtnString = 1
            oTrans.Commit()
            rtnString = "Record Saved"

        Catch ex As Exception
            oTrans.Rollback()
            'rtnString = ex.Message.ToString
            Throw ex
            'rtnString = "Set Not Saved"
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnString
    End Function

    Public Function SMS_Save(ByVal PCMDDset As DataSet, ByVal Dexamslno As Integer, ByVal PUpdSlno As Integer) As String
        Dim rtnString As String
        Dim RtnVal As Integer
        Try
            Dim setResult As String

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(PCMDDset) AndAlso PCMDDset.Tables(0).Rows.Count > 0 Then

                RtnVal = SMS_Sent_Save(PCMDDset, oConn, oTrans)
                SMS_EXAM_Save(Dexamslno, oConn, oTrans)

            End If

            rtnString = 1
            oTrans.Commit()
            rtnString = "Record Saved"

        Catch ex As Exception
            oTrans.Rollback()
            'rtnString = ex.Message.ToString
            Throw ex
            'rtnString = "Set Not Saved"
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnString
    End Function
    Private Function SMS_EXAM_Save(ByVal pDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oComm = New OracleCommand
            oComm.CommandText = "SMS_UPDATE_EXAMDEFINE"
            oComm.Connection = pConn
            oComm.CommandType = CommandType.StoredProcedure
            oComm.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParam = oComm.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pDEXAMSLNO



            oComm.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function SMS_Sent_Save(ByVal pDs As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Integer
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand
            oParam = New OracleClient.OracleParameter

            Dim iCommand As New OracleClient.OracleCommand

            oComm.CommandText = "SMS_PROGRESSINSERT"
            oComm.Connection = pConn
            oComm.Transaction = pTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMBINATIONKEY"

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ADMSLNO"

            oParam = oComm.Parameters.Add("iMOBILE", OracleType.Number, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MOBILE"

            oParam = oComm.Parameters.Add("iEXAMDESCRIPTION", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EXAMDESCRIPTION"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oParam = oComm.Parameters.Add("iSMS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SMS"

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "NAME"

            oParam = oComm.Parameters.Add("iMARKS", OracleType.VarChar, 200)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MARKS"

            oParam = oComm.Parameters.Add("iEDATE", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EDATE"

            oParam = oComm.Parameters.Add("iCREXAM", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "CREXAM"

            oAdap.InsertCommand = oComm
            oAdap.Update(pDs, pDs.Tables(0).TableName)

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Progress_Print_Save(ByVal pQuery As String) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()


            rtnString = Progress_Print_ExamSave(pQuery, oConn, oTrans)
            oTrans.Commit()




        Catch ex As Exception
            oTrans.Rollback()
            'rtnString = ex.Message.ToString
            Throw ex
            'rtnString = "Set Not Saved"
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnString
    End Function

    Private Function Progress_Print_ExamSave(ByVal pDEXAMSLNO As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oComm = New OracleCommand
            oComm.CommandText = "EXAM_PRGSENT_UPD"
            oComm.Connection = pConn
            oComm.CommandType = CommandType.StoredProcedure
            oComm.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParam = oComm.Parameters.Add("iQUERY", OracleType.VarChar, 500)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pDEXAMSLNO



            oComm.ExecuteNonQuery()
            Return 1
        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

End Class
