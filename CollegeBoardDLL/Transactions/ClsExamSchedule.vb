'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Middle layer for Exam Schedule
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 28-JUL-2006
'   FINAL BASELINE DATE               : 28-JUL-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------

Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsExamSchedule

#Region " Class Variables "
    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private oTrans As OracleTransaction
    Private ObjConn As Connection
    Private ReturnStr As String
    Dim Ds As New DataSet

#End Region

#Region "Methods"

    Public Function ResultUpload(ByVal iDEXAMSLNO As Integer, ByVal EXAMBRANCHSLNO As Integer) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection

            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()


            If iDEXAMSLNO <> 0 Then

                oCommand = New OracleClient.OracleCommand
                oParameter = New OracleClient.OracleParameter

                oCommand.CommandText = "RESULTUPLOAD_CURSORE"
                oCommand.Connection = oConn
                oCommand.CommandType = CommandType.StoredProcedure
                oCommand.Transaction = oTrans

                'ADD IN PARAMETER NAME iDEXAMSLNO
                oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = iDEXAMSLNO

                oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = EXAMBRANCHSLNO


                oCommand.ExecuteNonQuery()

            End If

            oTrans.Commit()
            rtnString = "Result Uploaded"

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

#End Region

#Region " Exam Lock"

    Public Function ExamLock_Unlock(ByVal FORLOCK As String, ByVal iDEXAMSLNO As Integer, ByVal EbArrlst As ArrayList) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            If Not EbArrlst Is Nothing Then
                If FORLOCK = "LOCK" Then
                    For I = 0 To EbArrlst.Count - 1
                        ExamLock(iDEXAMSLNO, Val(EbArrlst(I).ToString), oConn, oTrans)
                    Next
                Else
                    For I = 0 To EbArrlst.Count - 1
                        ExamUnLock(iDEXAMSLNO, Val(EbArrlst(I).ToString), oConn, oTrans)
                    Next
                End If

            End If

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Sub ExamLock(ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "EXAM_EXAMLOCK"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExamUnLock(ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "EXAM_EXAMUNLOCK"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ExamLevelLock(ByVal iDEXAMSLNO As Integer, ByVal iLockStatus As String) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "EXAM_TOTALEXAMLOCK"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iLOCKSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iLockStatus

            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ObjectiveTempDataDelete(ByVal iDEXAMSLNO As Integer) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "EXAM_OBJTEMPDATA_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

          
            oCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return " Data Deleted Successfully "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamUpdateWithoutLock(ByVal iDexamslno As Integer, ByVal iComacademicslno As Integer)
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "SUPER_EXAM_REFRESH_TABLES"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDexamslno
            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iComacademicslno

            oCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return " ExamMass Update Successfully "
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " Govt ExamBRanches Lock"       'Written By kssr for GovtExambranches Lock And UnLock view case

    Public Function GovtExamLock_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "P_INSERT_GOVTEXAMSLOCK"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME course
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'ADD IN PARAMETER NAME exam name
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER subject
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "BCS")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function GovtExamLock_DeleteBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "P_DELETE_GOVTEXAMSLOCK"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME course
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'ADD IN PARAMETER NAME exam name
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER subject
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            adap.InsertCommand = oCommand
            adap.DeleteCommand = oCommand
            adap.Update(PDataSet, "BCS")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Sheduler Home Fetch"


    Public Function DefinedExamSchedule_Fatch(ByVal pCourseSLNo As Integer, ByVal pPeriodicity As String, ByVal pExamTypeSLNo As Integer, ByVal pExamLevel As String, ByVal pBranchSLNo As Integer, ByVal pFromDate As Date, ByVal pToDate As Date, ByVal pStatus As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_EXAMSCHEDULE_DEFINED_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCourseSLNo

            'ADD IN PARAMETER NAME iPERIODICITY
            oParameter = oCommand.Parameters.Add("iPERIODICITY", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = pPeriodicity
            oParameter.Value = System.DBNull.Value

            'ADD IN PARAMETER NAME iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = pExamTypeSLNo
            oParameter.Value = System.DBNull.Value

            'ADD IN PARAMETER NAME iEXAMLEVEL
            oParameter = oCommand.Parameters.Add("iEXAMLEVEL", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = pExamLevel
            oParameter.Value = System.DBNull.Value

            'ADD IN PARAMETER NAME iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = pBranchSLNo
            oParameter.Value = System.DBNull.Value

            'ADD IN PARAMETER NAME iFROMDATE
            oParameter = oCommand.Parameters.Add("iFROMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = pFromDate
            oParameter.Value = System.DBNull.Value

            'ADD IN PARAMETER NAME iSetSlno
            oParameter = oCommand.Parameters.Add("iTODATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = pToDate
            oParameter.Value = System.DBNull.Value

            'ADD IN PARAMETER NAME iSTATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = pStatus
            oParameter.Value = System.DBNull.Value

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds, "Students")
        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function

#End Region

#Region "QPT Uplod"


    Public Function ExamDefine_DateOver_Status_Update(ByVal pStatus As String) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oCommand = New OracleCommand

            oCommand.CommandText = "M_UPDATE_EXAM_DATEOVER_STATUS"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            'ADD IN PARAMETER NAME iSTATUS 1
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pStatus

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function QPTTailor_Fetch(ByVal pDEXAMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_QPTTAILOR_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds, "QPTTailor")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function ExamQPTUpload_Save(ByVal dsComp As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()

            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsComp) Then

                'For Objective
                If Not IsNothing(dsComp.Tables("Objective")) AndAlso dsComp.Tables("Objective").Rows.Count > 0 Then
                    ExamQPTUpload_Save(dsComp.Tables("Objective"), oConn, oTrans)
                    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                Else
                    ExamDefine_Status_Update(pDEXAMSLNO, "RESULTSCOMPARIED", oConn, oTrans)
                End If

                'For Descriptive 
                If Not IsNothing(dsComp.Tables("Descriptive")) AndAlso dsComp.Tables("Descriptive").Rows.Count > 0 Then
                    ExamQPTUpload_Save(dsComp.Tables("Descriptive"), oConn, oTrans)
                    ExamDefine_DesStatus_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                Else
                    ExamDefine_DesStatus_Update(pDEXAMSLNO, "RESULTSCOMPARIED", oConn, oTrans)
                End If

                'Delete from temporory table
                ExamQPTUpload_Temp_Delete(pDEXAMSLNO, 0, oConn, oTrans)

            End If

            oTrans.Commit()
            rtnString = "QPT Saved"


        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function ExamQPTUpload_Save(ByVal dtUpload As DataTable, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand
            oCommand.CommandText = "M_INSERT_QPTUPLOAD"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            'ADD IN PARAMETER NAME iCORRECTANSWER 11
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            'ADD IN PARAMETER NAME iCORRECTANSWER 12
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            'ADD IN PARAMETER NAME iCORRECTANSWER 13
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            'ADD IN PARAMETER NAME iCORRECTANSWER 14
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            'ADD IN PARAMETER NAME iCORRECTANSWER 15
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            'ADD IN PARAMETER NAME iCORRECTANSWER 16
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 7)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            'ADD IN PARAMETER NAME iCORRECTMARK 17
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 18
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTATUS 19
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(dtUpload)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ExamQPTUpload_Update(ByVal dtUpload As DataTable, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand
            oCommand.CommandText = "M_UPLOAD_QPTUPLOAD"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iQPTUPLOADSLNO 0
            oParameter = oCommand.Parameters.Add("iQPTUPLOADSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'ADD IN PARAMETER NAME iCORRECTMARK 11
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 12
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTATUS 13
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dtUpload)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Function ExamQPTUpload_Temp_Delete(ByVal pDEXAMSLNO As Integer, ByVal pEXAMTYPESLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "M_QPT_TEMP_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iEXAMTYPESLNO1
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMTYPESLNO

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function ExamQPTUpload_Delete(ByVal pDEXAMSLNO As Integer, ByVal pExamTypeSLNo As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "M_QPT_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iEXAMTYPESLNO 2
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pExamTypeSLNo

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Function ExamDefine_Status_Update(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "M_UPDATE_EXAMDEFINE_STATUS"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iSTATUS 2
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pStatus

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function ExamDefine_DesStatus_Update(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "M_UPDATE_EXAMDEFINE_DESSTATUS"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iSTATUS 2
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pStatus

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Public Function QPTUpload_Fetch(ByVal pDEXAMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_QPTUPLOAD_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function

    Public Function QPTUpload_tts(ByVal pDEXAMSLNO As Integer, ByVal SPName As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = SPName '"M_SUBJECTWISE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function

    Public Function QPTCopies_Fetch(ByVal pDEXAMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_EXAMQPT_COPIES_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function

    Public Function QPTUpload_Temp_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pCopyNo As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_QPTUPLOAD_TEMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCopyNo

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function QPTUpload_Temp_Comp_Fetch(ByVal pDEXAMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_QPT_TEMP_COMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function QPTUpload_Temp_NextCopyNo_Fetch(ByVal pDEXAMSLNO As Integer) As Integer
        Dim iNextCopyNo As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "M_QPT_TEMP_NEXTCOPYNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME oCOPYNO
            oParameter = oCommand.Parameters.Add("oCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oCommand.ExecuteNonQuery()

            iNextCopyNo = oCommand.Parameters("oCOPYNO").Value


        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return iNextCopyNo

    End Function


    Public Function ExamQPTUpload_Temp_Save(ByVal dsUpload As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then


                '''For Descriptive 
                ''If Not IsNothing(dsUpload.Tables("Descriptive")) AndAlso dsUpload.Tables("Descriptive").Rows.Count > 0 Then

                ''    If Not IsNothing(dsUpload.Tables("Descriptive").GetChanges(DataRowState.Added)) Then 'Descriptive Questions Save
                ''        ExamQPTUpload_Temp_Save(dsUpload.Tables("Descriptive").GetChanges(DataRowState.Added), oConn, oTrans)
                ''    End If

                ''    If Not IsNothing(dsUpload.Tables("Descriptive").GetChanges(DataRowState.Modified)) Then 'Descriptive Question Update
                ''        ExamQPTUpload_Temp_Update(dsUpload.Tables("Descriptive").GetChanges(DataRowState.Modified), oConn, oTrans)
                ''    End If

                ''End If

                'For Objective
                If Not IsNothing(dsUpload.Tables("Objective")) AndAlso dsUpload.Tables("Objective").Rows.Count > 0 Then

                    If Not IsNothing(dsUpload.Tables("Objective").GetChanges(DataRowState.Added)) Then  'Objecive Question Save
                        ExamQPTUpload_Temp_Save(dsUpload.Tables("Objective").GetChanges(DataRowState.Added), oConn, oTrans)
                    End If

                    If Not IsNothing(dsUpload.Tables("Objective").GetChanges(DataRowState.Modified)) Then 'Objecive Question Update
                        ExamQPTUpload_Temp_Update(dsUpload.Tables("Objective").GetChanges(DataRowState.Modified), oConn, oTrans)
                    End If

                End If

                If pStatus <> "" Then
                    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                End If

            End If

            oTrans.Commit()
            rtnString = "QPT Temp Saved"


        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function ExamQPTUpload_Temp_Save(ByVal dtUpload As DataTable, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand
            oCommand.CommandText = "M_INSERT_QPTUPLOAD_TEMP"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iCOPYNO 0
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("COPYNO")

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("DEXAMSLNO")

            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("SUBJECTSLNO")

            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("TOPICSLNO")

            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("TRACKSLNO")

            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("EXAMTYPESLNO")

            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("NOOFQUESTIONS")

            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QUESTIONSLNO")

            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QUESTIONNO")

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("CORRECTANSWER")

            'ADD IN PARAMETER NAME iCORRECTANSWER 11
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            'ADD IN PARAMETER NAME iCORRECTANSWER 12
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            'ADD IN PARAMETER NAME iCORRECTANSWER 13
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            'ADD IN PARAMETER NAME iCORRECTANSWER 14
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            'ADD IN PARAMETER NAME iCORRECTANSWER 15
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            'ADD IN PARAMETER NAME iCORRECTANSWER 16
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 7)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"



            'ADD IN PARAMETER NAME iCORRECTMARK 18
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("CORRECTMARK")

            'ADD IN PARAMETER NAME iNEGATIVEMARK 19
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("NEGATIVEMARK")

            'ADD IN PARAMETER NAME iSTATUS 20
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("STATUS")


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO 21
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("STATUS")

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(dtUpload)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function ExamQPTUpload_Temp_Update(ByVal dtUpload As DataTable, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand
            oCommand.CommandText = "M_UPDATE_QPTUPLOAD_TEMP"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iCOPYNO -1
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"

            'ADD IN PARAMETER NAME iQPTUPLOADTEMPSLNO 0
            oParameter = oCommand.Parameters.Add("iQPTUPLOADTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            'ADD IN PARAMETER NAME iCORRECTANSWER 11
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            'ADD IN PARAMETER NAME iCORRECTANSWER 12
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            'ADD IN PARAMETER NAME iCORRECTANSWER 13
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            'ADD IN PARAMETER NAME iCORRECTANSWER 14
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            'ADD IN PARAMETER NAME iCORRECTANSWER 16
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"


            'ADD IN PARAMETER NAME iCORRECTANSWER 17
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 7)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            'ADD IN PARAMETER NAME iCORRECTMARK 1
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 12
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTATUS 13
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dtUpload)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ExamQPTUpload_Temp_Comp_Save(ByVal dsUpload As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then

                'For Objective
                If Not IsNothing(dsUpload.Tables("Objective")) AndAlso dsUpload.Tables("Objective").Rows.Count > 0 Then

                    If Not IsNothing(dsUpload.Tables("Objective").GetChanges(DataRowState.Modified)) Then 'Objecive Question Update
                        ExamQPTUpload_Temp_Comp_Update(dsUpload.Tables("Objective").GetChanges(DataRowState.Modified), oConn, oTrans)
                    End If

                End If

                If pStatus <> "" Then
                    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                End If

            End If

            oTrans.Commit()
            rtnString = "QPT Temp Saved"


        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function ExamQPTUpload_Temp_Comp_Update(ByVal dtUpload As DataTable, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand
            oCommand.CommandText = "M_UPDATE_QPTUPLOAD_COMP_TEMP"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"

            'ADD IN PARAMETER NAME iQUESTIONSLNO 3
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'ADD IN PARAMETER NAME iQUESTIONNO 4
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 5
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            'ADD IN PARAMETER NAME iCORRECTANSWER 6
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            'ADD IN PARAMETER NAME iCORRECTANSWER 7
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            'ADD IN PARAMETER NAME iCORRECTANSWER 8
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            'ADD IN PARAMETER NAME iCORRECTANSWER 9
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            'ADD IN PARAMETER NAME iCORRECTANSWER 5
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'ADD IN PARAMETER NAME iCORRECTANSWER 11
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 7)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            'ADD IN PARAMETER NAME iSTATUS 6
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dtUpload)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ExamQPTUpload_Delete(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()

            'Delete from temporory table
            ExamQPTUpload_Temp_Delete(pDEXAMSLNO, 1, oConn, oTrans)

            'Delete from main table
            ExamQPTUpload_Delete(pDEXAMSLNO, 1, oConn, oTrans)

            'Update status of Define Table
            ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)

            oTrans.Commit()
            rtnString = "QPT Deleted"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    ' ''WHEN COPY NO 2 IS ENTER THAT TIME READ DATA FROM RESUL TEMP TABLE i.e
    ' <WebMethod(Description:="Fetch the data from Question Upload details ")> _
    'Public Function QPTUpload_Fetch(ByVal pDEXAMSLNO As Integer) As DataSet
    '     Try
    '         oConn = ObjConn.GetConnection
    '          

    '         oCommand = New OracleClient.OracleCommand
    '         oParameter = New OracleClient.OracleParameter
    '         oAdapter = New OracleClient.OracleDataAdapter
    '         ds = New Data.DataSet

    '         oCommand.CommandText = "M_QPTUPLOAD_SELECT"
    '         oCommand.Connection = oConn
    '         oCommand.CommandType = CommandType.StoredProcedure

    '         'ADD IN PARAMETER NAME DataCur
    '         oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
    '         oParameter.Direction = ParameterDirection.Output

    '         'ADD IN PARAMETER NAME iDEXAMSLNO
    '         oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
    '         oParameter.Direction = ParameterDirection.Input
    '         oParameter.Value = pDEXAMSLNO

    '         oAdapter.SelectCommand = oCommand
    '         oAdapter.Fill(ds)

    '     Catch ex As Exception
    '         Throw EX
    '     Finally
    '        If Not ObjConn Is Nothing Then ObjConn.Free()
    '     End Try
    '     Return ds

    ' End Function

#End Region

#Region "Staff QPT Upload "
    Public Function StaffExamQPTUpload_Save(ByVal dsComp As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()

            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsComp) Then

                'For Objective
                If Not IsNothing(dsComp.Tables("Objective")) AndAlso dsComp.Tables("Objective").Rows.Count > 0 Then
                    StaffExamQPTUpload_Save(dsComp.Tables("Objective"), oConn, oTrans)
                    StaffExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                Else
                    StaffExamDefine_Status_Update(pDEXAMSLNO, "RESULTSCOMPARIED", oConn, oTrans)
                End If

                'For Descriptive 
                If Not IsNothing(dsComp.Tables("Descriptive")) AndAlso dsComp.Tables("Descriptive").Rows.Count > 0 Then
                    StaffExamQPTUpload_Save(dsComp.Tables("Descriptive"), oConn, oTrans)
                    StaffExamDefine_DesStatus_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                Else
                    StaffExamDefine_DesStatus_Update(pDEXAMSLNO, "RESULTSCOMPARIED", oConn, oTrans)
                End If

                'Delete from temporory table
                StaffExamQPTUpload_Temp_Delete(pDEXAMSLNO, 0, oConn, oTrans)

            End If

            oTrans.Commit()
            rtnString = "QPT Saved"


        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function StaffExamQPTUpload_Save(ByVal dtUpload As DataTable, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand
            oCommand.CommandText = "STAFF_INSERT_QPTUPLOAD"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            'ADD IN PARAMETER NAME iCORRECTANSWER 11
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            'ADD IN PARAMETER NAME iCORRECTANSWER 12
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            'ADD IN PARAMETER NAME iCORRECTANSWER 13
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            'ADD IN PARAMETER NAME iCORRECTANSWER 14
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            'ADD IN PARAMETER NAME iCORRECTANSWER 15
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            'ADD IN PARAMETER NAME iCORRECTANSWER 16
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 7)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            'ADD IN PARAMETER NAME iCORRECTMARK 17
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 18
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTATUS 19
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(dtUpload)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function StaffExamDefine_Status_Update(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "STAFF_UPDATE_EXAMDEFINE_STATUS"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iSTATUS 2
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pStatus

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function StaffExamDefine_DesStatus_Update(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "STAFF_UPDATE_EXAMDEFINE_DES"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iSTATUS 2
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pStatus

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function StaffExamQPTUpload_Temp_Delete(ByVal pDEXAMSLNO As Integer, ByVal pEXAMTYPESLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "STAFF_QPT_TEMP_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iEXAMTYPESLNO1
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMTYPESLNO

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function StaffExamQPTUpload_Delete(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()

            'Delete from temporory table
            ExamQPTUpload_Temp_Delete(pDEXAMSLNO, 1, oConn, oTrans)

            'Delete from main table
            ExamQPTUpload_Delete(pDEXAMSLNO, 1, oConn, oTrans)

            'Update status of Define Table
            ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)

            oTrans.Commit()
            rtnString = "QPT Deleted"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function StaffExamQPTUpload_Delete(ByVal pDEXAMSLNO As Integer, ByVal pExamTypeSLNo As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "STAFF_QPT_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iEXAMTYPESLNO 2
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pExamTypeSLNo

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function StaffQPTUpload_Fetch(ByVal pDEXAMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "STAFF_QPTUPLOAD_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function

    Public Function StaffQPTUpload_Temp_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pCopyNo As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "STAFF_QPTUPLOAD_TEMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCopyNo

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function

    Public Function StaffDefine_DateOver_Status_Update(ByVal pStatus As String) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oCommand = New OracleCommand

            oCommand.CommandText = "S_UPDATE_EXAM_DATEOVER_STATUS"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            'ADD IN PARAMETER NAME iSTATUS 1
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pStatus

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function
#End Region

#Region "QP Key Update"

    Public Function QPKey_Fetch(ByVal pDEXAMSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "P_QPKEYUPDATE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds, "Objective")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function



    Public Function QPKeyUpdate_Save(ByVal dsUpload As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then
                QPKeyUpdateSave(dsUpload, "Objective", pDEXAMSLNO, oConn, oTrans)
                ExamStatusUpdate(pDEXAMSLNO, oConn, oTrans)
            End If

            oTrans.Commit()
            rtnString = "Ques.Key Updated"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function QPKeyUpdateSave(ByVal dsupload As DataSet, ByVal DTable As String, ByVal pDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand


            UCommand.CommandText = "P_QPK_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iQPTUPLOADSLNO
            oParameter = UCommand.Parameters.Add("iQPTUPLOADSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iQPTTSLNO 
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNO"

            'ADD IN PARAMETER NAME iDEXAMSLNO 
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iQUESTIONSLNO
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'ADD IN PARAMETER NAME iQUESTIONNO 
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 
            oParameter = UCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            'ADD IN PARAMETER NAME iCORRECTANSWER 
            oParameter = UCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            'ADD IN PARAMETER NAME iCORRECTANSWER 
            oParameter = UCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            'ADD IN PARAMETER NAME iCORRECTANSWER 
            oParameter = UCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            'ADD IN PARAMETER NAME iCORRECTANSWER 
            oParameter = UCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            'ADD IN PARAMETER NAME iCORRECTANSWER 
            oParameter = UCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"


            'ADD IN PARAMETER NAME iCORRECTANSWER 
            oParameter = UCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"


            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsupload, "Objective")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'When Ques.Paper Key is Updated then Changing Exam Status i.e in EXAM_DFINEEXAM Table Status='
    Private Function ExamStatusUpdate(ByVal pDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand
            oCommand = New OracleClient.OracleCommand

            UCommand.CommandText = "P_QKUDFINEEXAMSTATUS_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            UCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Reslut UpLoad"


    Public Function ResultNextCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal iADMSLNO As Integer) As Integer
        Dim iNextCopyNo As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_NEXTCOPYNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME oCOPYNO
            oParameter = oCommand.Parameters.Add("oCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Output

            oCommand.ExecuteNonQuery()

            iNextCopyNo = oCommand.Parameters("oCOPYNO").Value

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return iNextCopyNo

    End Function



    Public Function ResultCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pADMSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "RESULT_COPIES_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function ResultTemp_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal CopyNo As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then
                ResultTempSave(dsUpload, "Descriptive", pADMSLNO, oConn, oTrans)
                If CopyNo = 2 Then ResultAutoCompare(pADMSLNO, pDEXAMSLNO, oConn, oTrans)
                'For Descriptive 
                'If Not IsNothing(dsUpload.Tables("Descriptive")) AndAlso dsUpload.Tables("Descriptive").Rows.Count > 0 Then

                'End If

                ''For Objective
                'If Not IsNothing(dsUpload.Tables("Objective")) AndAlso dsUpload.Tables("Objective").Rows.Count > 0 Then
                '    ResultTempSave(dsUpload, "Objective", pADMSLNO, oConn, oTrans)
                'End If

                'If pStatus <> "" Then
                '    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                'End If
                ResultTTSSave(dsUpload, "TTS", pADMSLNO, oConn, oTrans)
            End If

            oTrans.Commit()
            rtnString = "Result Temp Saved"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function ResultTempSave(ByVal dsupload As DataSet, ByVal DTable As String, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "RESULT_TEMP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            UCommand.CommandText = "RESULT_TEMP_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 0
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 7)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'ADD IN PARAMETER NAME iCORRECTMARK 11
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 12
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = oCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = oCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = oCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = oCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = oCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 19
            oParameter = oCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 20
            oParameter = oCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"


            'ADD IN PARAMETER NAME iSTUMARKS 21
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'ADD IN PARAMETER NAME iSTATUS 22
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand

            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 12
            oParameter = UCommand.Parameters.Add("iSTUANS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns"

            'ADD IN PARAMETER NAME iSTUMARKS 13
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'ADD IN PARAMETER NAME iSTATUS 14
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'oAdapter.Update(dsupload, DTable)
            oAdapter.Update(dsupload, "Descriptive")
            oAdapter.Update(dsupload, "Objective")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Function ResultTTSSave(ByVal dsupload As DataSet, ByVal DTable As String, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "RESULT_TTSTEMP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            UCommand.CommandText = "RESULT_TTSTEMP_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 0
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'ADD IN PARAMETER NAME iCORRECTMARK 11
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 12
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTUANS 13
            oParameter = oCommand.Parameters.Add("iSTUANS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns"

            'ADD IN PARAMETER NAME iSTUMARKS 14
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'ADD IN PARAMETER NAME iSTATUS 15
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand

            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 12
            oParameter = UCommand.Parameters.Add("iSTUANS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns"

            'ADD IN PARAMETER NAME iSTUMARKS 13
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'ADD IN PARAMETER NAME iSTATUS 14
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'oAdapter.Update(dsupload, DTable)
            oAdapter.Update(dsupload, "TTS")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Function ResultAutoCompare(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "AUTOMATICRESULTCOMP_CURSORE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function ResultTemp_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pCopyNo As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection



            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "RESULT_TEMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCopyNo


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function


    Public Function ResultTTTS_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pCopyNo As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "RESULT_TTTS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCopyNo


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function



    Public Function ResultTempComp_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "RESULT_TEMP_COMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function


    Public Function ResultTempComp_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then

                ResultTempCompSave(dsUpload, pADMSLNO, oConn, oTrans)

                'If pStatus <> "" Then
                '    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                'End If

            End If

            oTrans.Commit()
            rtnString = "Result Temp Saved"


        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function ResultTempCompSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand


            UCommand.CommandText = "RESULTComp_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 12
            oParameter = UCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"


            'ADD IN PARAMETER NAME iSTUANS 13
            oParameter = UCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = UCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = UCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = UCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = UCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = UCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 19
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'ADD IN PARAMETER NAME iSTATUS 20
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'oAdapter.Update(dsupload, DTable)
            If Not dsupload.Tables("Descriptive") Is Nothing Then oAdapter.Update(dsupload, "Descriptive")
            If Not dsupload.Tables("Objective") Is Nothing Then oAdapter.Update(dsupload, "Objective")
        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function ResultForFinal_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "RESULTFORFINAL_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function



    Public Function ResultFinal_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then


                'For Descriptive 

                ResultFinalSave(dsUpload, pADMSLNO, oConn, oTrans)


                If pStatus <> "" Then
                    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                End If

            End If

            oTrans.Commit()
            rtnString = "Final Result Saved"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function


    Private Function ResultFinalSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "RESULT_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"



            'ADD IN PARAMETER NAME iQPTTSLNO 3
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 4
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 5
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 6
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 7
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 8
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 10
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 11
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'ADD IN PARAMETER NAME iCORRECTMARK 12
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 13
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = oCommand.Parameters.Add("iSTUANS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns"

            'ADD IN PARAMETER NAME iSTUMARKS 15
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'ADD IN PARAMETER NAME iSTATUS 16
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand


            'oAdapter.Update(dsupload, DTable)
            oAdapter.Update(dsupload, "Descriptive")
            oAdapter.Update(dsupload, "Objective")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try


    End Function




#End Region

#Region "Results Update"

    Public Function ResultUpdate_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "RESULTUPDATE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function


    Public Function ResultUpdate_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then
                ResultUpdateSave(dsUpload, pADMSLNO, oConn, oTrans)
                ExamStatusUpdate(pDEXAMSLNO, oConn, oTrans)

            End If

            oTrans.Commit()
            rtnString = "Result updated"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function ResultUpdateSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand



            UCommand.CommandText = "P_RESULTS_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans




            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iADMSLNO 
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iRESULTSLNO
            oParameter = UCommand.Parameters.Add("iRESULTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RESULTSLNO"


            'ADD IN PARAMETER NAME iQPTTSLNO
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNO"

            'ADD IN PARAMETER NAME iQUESTIONSLNO
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iCORRECTANSWER
            oParameter = UCommand.Parameters.Add("iCORRECTANSWER", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"


            'ADD IN PARAMETER NAME iCORRECTMARK
            oParameter = UCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK
            oParameter = UCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTUANS1
            oParameter = UCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUANS1"

            'ADD IN PARAMETER NAME iSTUANS1
            oParameter = UCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUANS2"

            'ADD IN PARAMETER NAME iSTUANS3
            oParameter = UCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUANS3"

            'ADD IN PARAMETER NAME iSTUANS4
            oParameter = UCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUANS4"

            'ADD IN PARAMETER NAME iSTUANS5
            oParameter = UCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUANS5"

            'ADD IN PARAMETER NAME iSTUANS6
            oParameter = UCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUANS6"

            'ADD IN PARAMETER NAME iSTUANS7
            oParameter = UCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUANS7"



            'ADD IN PARAMETER NAME iSTUMARKS
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUMARKS"

            'ADD IN PARAMETER NAME iSTUSTATUS
            oParameter = UCommand.Parameters.Add("iSTUSTATUS", OracleType.Char)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            oAdapter.UpdateCommand = UCommand

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'oAdapter.Update(dsupload, DTable)
            oAdapter.Update(dsupload, "Descriptive")
            oAdapter.Update(dsupload, "Objective")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Student Search"


    Public Function StudentSearch(ByVal SPName As String, ByVal pDEXAMSLNO As Integer, ByVal pADMNO As String, ByVal USERSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            ' "STUDENTDETAILS_SELECT" sp for getting result 
            '"STUCOMPDETAILS_SELECT"  sp for getting result comp
            oCommand.CommandText = SPName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = USERSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iADMNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function



    Public Function Students_Select(ByVal SqlStr As String, ByVal pDEXAMSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "STUDENTSEARCH_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iStr
            oParameter = oCommand.Parameters.Add("iStr", OracleType.VarChar, 5000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlStr


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function SdSearch(ByVal SPName As String, ByVal pDEXAMSLNO As Integer, ByVal pBRANCHSLNO As Integer, ByVal pADMSNO As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = SPName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBRANCHSLNO

            'ADD IN PARAMETER NAME iADMSNO
            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)


        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function



    Public Function Student_Search(ByVal SPName As String, ByVal iEXAMBRANCHSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer, ByVal iADMSNO As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = SPName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iADMSNO
            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function

#End Region

#Region "SearchForTransDirectMenu"


    Public Function SearchOnExamName(ByVal ExamName As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet


            oCommand.CommandText = "DE_SELECTONENAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamName


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function SearchOnSetExamName(ByVal ExamName As String, ByVal SetName As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet


            oCommand.CommandText = "SET_SELECTONENAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamName

            'ADD IN PARAMETER NAME iSET
            oParameter = oCommand.Parameters.Add("iSET", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetName

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function


    Public Function SearchOnQuesPaperExamName(ByVal ExamName As String, ByVal QuesPapertName As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet


            oCommand.CommandText = "QUESPAPER_SELECTONENAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamName

            'ADD IN PARAMETER NAME iQUESPAPERNAME
            oParameter = oCommand.Parameters.Add("iQUESPAPERNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuesPapertName

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function

#End Region

#Region " Objective Exams Evaluation "

    Public Function ObjExamEvaluation(ByVal iDEXAMSLNO As Integer, ByVal EbArrlst As ArrayList) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            If Not EbArrlst Is Nothing Then

                For I = 0 To EbArrlst.Count - 1
                    UpdateOraObjProcessLog(" Exam : " & iDEXAMSLNO.ToString & "    " & " Exam Branch  : " & EbArrlst(I).ToString & "    " & " Evaluation Start DATE  : : " & DateTime.Now.ToString)
                    ExamEvaluation(iDEXAMSLNO, Val(EbArrlst(I).ToString), oConn, oTrans)
                    UpdateOraObjProcessLog(" Exam : " & iDEXAMSLNO.ToString & "    " & " Exam Branch  : " & EbArrlst(I).ToString & "    " & " Evaluation End DATE    : : " & DateTime.Now.ToString)
                Next

            End If

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Sub ExamEvaluation(ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "EXAM_OBJLLINE_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObjExamMarksPosting(ByVal iDEXAMSLNO As Integer, ByVal EbArrlst As ArrayList) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            If Not EbArrlst Is Nothing Then

                For I = 0 To EbArrlst.Count - 1
                    UpdateOraObjProcessLog(" Exam : " & iDEXAMSLNO.ToString & "    " & " Exam Branch  : " & EbArrlst(I).ToString & "    " & " Marks Posting Start DATE  : : " & DateTime.Now.ToString)
                    ExamMarksPosting(iDEXAMSLNO, Val(EbArrlst(I).ToString), oConn, oTrans)
                    UpdateOraObjProcessLog(" Exam : " & iDEXAMSLNO.ToString & "    " & " Exam Branch  : " & EbArrlst(I).ToString & "    " & " Marks Posting End DATE    : : " & DateTime.Now.ToString)
                Next

            End If

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Sub ExamMarksPosting(ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "EXAM_OBJRES_FINALRESULT_ENTRY"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO


            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObjExamDataPosting(ByVal iDEXAMSLNO As Integer, ByVal EbArrlst As ArrayList) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            If Not EbArrlst Is Nothing Then

                For I = 0 To EbArrlst.Count - 1
                    UpdateOraObjProcessLog(" Exam : " & iDEXAMSLNO.ToString & "    " & " Exam Branch  : " & EbArrlst(I).ToString & "    " & " Data Posting Start DATE  : : " & DateTime.Now.ToString)
                    ExamDataPosting(iDEXAMSLNO, Val(EbArrlst(I).ToString), oConn, oTrans)
                    UpdateOraObjProcessLog(" Exam : " & iDEXAMSLNO.ToString & "    " & " Exam Branch  : " & EbArrlst(I).ToString & "    " & " Data Posting End DATE    : : " & DateTime.Now.ToString)
                Next

            End If

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Sub ExamDataPosting(ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "EXAM_GRADE_ACTUAL_RESULTENTRY1"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO


            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " IIT Results "


    Public Function IIT_ResultCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pADMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "IIT_RESULT_COPIES_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function

    Public Function IIT_ResultNextCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal iADMSLNO As Integer) As Integer
        Dim iNextCopyNo As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "IIT_RESULT_NEXTCOPYNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME oCOPYNO
            oParameter = oCommand.Parameters.Add("oCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Output

            oCommand.ExecuteNonQuery()

            iNextCopyNo = oCommand.Parameters("oCOPYNO").Value

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return iNextCopyNo

    End Function


    Public Function IIT_ResultTemp_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pCopyNo As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "IIT_RESULT_TEMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCopyNo


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function IIT_ResultTempComp_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "IIT_RESULT_TEMP_COMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function




    Public Function IIT_ResultTempComp_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then

                IIT_ResultTempCompSave(dsUpload, pADMSLNO, oConn, oTrans)

                'If pStatus <> "" Then
                '    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                'End If

            End If

            oTrans.Commit()
            rtnString = "Result Temp Saved"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function IIT_ResultTempCompSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand


            UCommand.CommandText = "IIT_RESULTComp_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 12
            oParameter = UCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"


            'ADD IN PARAMETER NAME iSTUANS 13
            oParameter = UCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = UCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = UCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = UCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = UCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = UCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 19
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'ADD IN PARAMETER NAME iSTATUS 20
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'oAdapter.Update(dsupload, DTable)
            If Not dsupload.Tables("Descriptive") Is Nothing Then oAdapter.Update(dsupload, "Descriptive")
            If Not dsupload.Tables("Objective") Is Nothing Then oAdapter.Update(dsupload, "Objective")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function IIT_ResultUpload(ByVal iDEXAMSLNO As Integer) As String
        Dim rtnString As String

        Try


            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            If iDEXAMSLNO <> 0 Then

                oCommand = New OracleClient.OracleCommand
                oParameter = New OracleClient.OracleParameter

                oCommand.CommandText = "IIT_RESULTUPLOAD_CURSORE"
                oCommand.Connection = oConn
                oCommand.CommandType = CommandType.StoredProcedure
                oCommand.Transaction = oTrans

                'ADD IN PARAMETER NAME iDEXAMSLNO
                oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = iDEXAMSLNO

                oCommand.ExecuteNonQuery()

            End If

            oTrans.Commit()
            rtnString = "Result Uploaded"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

#End Region

#Region " AIEEE Results "


    Public Function AIE_ResultCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pADMSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "AIE_RESULT_COPIES_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function


    Public Function AIE_ResultNextCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal iADMSLNO As Integer) As Integer
        Dim iNextCopyNo As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "AIE_RESULT_NEXTCOPYNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME oCOPYNO
            oParameter = oCommand.Parameters.Add("oCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Output

            oCommand.ExecuteNonQuery()

            iNextCopyNo = oCommand.Parameters("oCOPYNO").Value


        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return iNextCopyNo

    End Function


    Public Function AIE_ResultTemp_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pCopyNo As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "AIE_RESULT_TEMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCopyNo


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function AIE_ResultTempComp_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "IIT_RESULT_TEMP_COMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function




    Public Function AIE_ResultTempComp_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then

                AIE_ResultTempCompSave(dsUpload, pADMSLNO, oConn, oTrans)

                'If pStatus <> "" Then
                '    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                'End If

            End If

            oTrans.Commit()
            rtnString = "Result Temp Saved"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function AIE_ResultTempCompSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand


            UCommand.CommandText = "IIT_RESULTComp_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 12
            oParameter = UCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"


            'ADD IN PARAMETER NAME iSTUANS 13
            oParameter = UCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = UCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = UCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = UCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = UCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = UCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 19
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'ADD IN PARAMETER NAME iSTATUS 20
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'oAdapter.Update(dsupload, DTable)
            If Not dsupload.Tables("Descriptive") Is Nothing Then oAdapter.Update(dsupload, "Descriptive")
            If Not dsupload.Tables("Objective") Is Nothing Then oAdapter.Update(dsupload, "Objective")

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function AIE_ResultUpload(ByVal iDEXAMSLNO As Integer) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            If iDEXAMSLNO <> 0 Then

                oCommand = New OracleClient.OracleCommand
                oParameter = New OracleClient.OracleParameter

                oCommand.CommandText = "IIT_RESULTUPLOAD_CURSORE"
                oCommand.Connection = oConn
                oCommand.CommandType = CommandType.StoredProcedure
                oCommand.Transaction = oTrans

                'ADD IN PARAMETER NAME iDEXAMSLNO
                oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = iDEXAMSLNO

                oCommand.ExecuteNonQuery()

            End If

            oTrans.Commit()
            rtnString = "Result Uploaded"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

#End Region

#Region " EMACET Results "

    Public Function ECET_ResultCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pADMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "ECET_RESULT_COPIES_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function ECET_ResultNextCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal iADMSLNO As Integer) As Integer
        Dim iNextCopyNo As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "ECET_RESULT_NEXTCOPYNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME oCOPYNO
            oParameter = oCommand.Parameters.Add("oCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Output

            oCommand.ExecuteNonQuery()

            iNextCopyNo = oCommand.Parameters("oCOPYNO").Value

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return iNextCopyNo

    End Function


    Public Function ECET_ResultTemp_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pCopyNo As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "ECET_RESULT_TEMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCopyNo


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function ECET_ResultTempComp_Fetch(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "ECET_RESULT_TEMP_COMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function




    Public Function ECET_ResultTempComp_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then

                ECET_ResultTempCompSave(dsUpload, pADMSLNO, oConn, oTrans)

                'If pStatus <> "" Then
                '    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, oTrans)
                'End If

            End If

            oTrans.Commit()
            rtnString = "Result Temp Saved"

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function ECET_ResultTempCompSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand


            UCommand.CommandText = "ECET_RESULTComp_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 12
            oParameter = UCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"


            'ADD IN PARAMETER NAME iSTUANS 13
            oParameter = UCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = UCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = UCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = UCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = UCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = UCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 19
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'ADD IN PARAMETER NAME iSTATUS 20
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'oAdapter.Update(dsupload, DTable)
            If Not dsupload.Tables("Descriptive") Is Nothing Then oAdapter.Update(dsupload, "Descriptive")
            If Not dsupload.Tables("Objective") Is Nothing Then oAdapter.Update(dsupload, "Objective")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ECET_ResultUpload(ByVal iDEXAMSLNO As Integer) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction()


            If iDEXAMSLNO <> 0 Then

                oCommand = New OracleClient.OracleCommand
                oParameter = New OracleClient.OracleParameter

                oCommand.CommandText = "ECET_RESULTUPLOAD_CURSORE"
                oCommand.Connection = oConn
                oCommand.CommandType = CommandType.StoredProcedure
                oCommand.Transaction = oTrans

                'ADD IN PARAMETER NAME iDEXAMSLNO
                oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = iDEXAMSLNO

                oCommand.ExecuteNonQuery()

            End If

            oTrans.Commit()
            rtnString = "Result Uploaded"

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

#End Region

#Region "Website Data Posting"
    Public Function ExamDataPost(ByVal iDEXAMSLNO As Integer, ByVal iExamType As String) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "EXAM_PARENTMARKS_SCH_CURINSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iExamType


            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamDataDelete(ByVal iDEXAMSLNO As Integer) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "EXAM_PARENTMARKS_COL_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function
#End Region

#Region "STAFF SearchForTransDirectMenu"


    Public Function Staff_SearchOnExamName(ByVal ExamName As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            'DE_SELECTONENAME
            oCommand.CommandText = "STAFF_SELECTONENAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamName


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function


    Public Function Staff_SearchOnSetExamName(ByVal ExamName As String, ByVal SetName As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet


            'SET_SELECTONENAME
            oCommand.CommandText = "STAFF_SET_SELECTONENAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamName

            'ADD IN PARAMETER NAME iSET
            oParameter = oCommand.Parameters.Add("iSET", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetName

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function


    Public Function Staff_SearchOnQuesPaperExamName(ByVal ExamName As String, ByVal QuesPapertName As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            'QUESPAPER_SELECTONENAME
            oCommand.CommandText = "STAFF_QPSELECTONENAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamName

            'ADD IN PARAMETER NAME iQUESPAPERNAME
            oParameter = oCommand.Parameters.Add("iQUESPAPERNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuesPapertName

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds

    End Function

#End Region

#Region " Staff Exam Lock"

    Public Function Staff_ExamLock_Unlock(ByVal FORLOCK As String, ByVal iDEXAMSLNO As Integer, ByVal EbArrlst As ArrayList) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            If Not EbArrlst Is Nothing Then
                If FORLOCK = "LOCK" Then
                    For I = 0 To EbArrlst.Count - 1
                        Staff_ExamLock(iDEXAMSLNO, Val(EbArrlst(I).ToString), oConn, oTrans)
                    Next
                Else
                    For I = 0 To EbArrlst.Count - 1
                        Staff_ExamUnLock(iDEXAMSLNO, Val(EbArrlst(I).ToString), oConn, oTrans)
                    Next
                End If

            End If

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Sub Staff_ExamLock(ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            'EXAM_EXAMLOCK
            oCommand.CommandText = "STAFF_EXAMLOCK"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Staff_ExamUnLock(ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            'EXAM_EXAMUNLOCK
            oCommand.CommandText = "STAFF_EXAMUNLOCK"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Staff_ExamLevelLock(ByVal iDEXAMSLNO As Integer, ByVal iLockStatus As String) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            'EXAM_TOTALEXAMLOCK
            oCommand.CommandText = "STAFF_TOTALEXAMLOCK"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iLOCKSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iLockStatus

            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Staff_ObjectiveTempDataDelete(ByVal iDEXAMSLNO As Integer) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            'EXAM_OBJTEMPDATA_DELETE
            oCommand.CommandText = "STAFF_OBJTEMPDATA_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO


            oCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return " Data Deleted Successfully "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Employee Mapping To Question's"

    Public Function P_EmpQesAvg_Insert(ByVal Arr As ArrayList) As Integer

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oCommand.CommandText = "EXAM_EMPQESAVG_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iEMPSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iQUESTIONS
            oParameter = oCommand.Parameters.Add("iQUESTIONS", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            'ADD IN PARAMETER NAME iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            'ADD IN PARAMETER NAME iQUERY1
            oParameter = oCommand.Parameters.Add("iQUERY1", OracleType.VarChar, 25000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            'ADD IN PARAMETER NAME iQUERY2
            oParameter = oCommand.Parameters.Add("iQUERY2", OracleType.VarChar, 25000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "OQBMapping"
    Public Function OQBEXAMMAPPING_Save(ByVal iDEXAMSLNO As Integer, ByVal iQPTMTSLNO As Integer, ByVal iOQPSLNO As Integer)
        Try

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EXAMOQBMAP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iAGSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO


            'ADD IN PARAMETER NAME iAGTNAME 
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iQPTMTSLNO


            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iOQPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iOQPSLNO


            oCommand.ExecuteNonQuery()

            ReturnStr = 1
            Return ReturnStr


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function
#End Region

#Region " Sub BRanches Lock"

    Public Function SubBatchExamLock_Insert(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "SUBBATCHSLOCK_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBBATCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "SUBBAT")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function SubBatchExamLock_Delete(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "SUBBATCHSLOCK_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBBATCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            adap.InsertCommand = oCommand
            adap.DeleteCommand = oCommand
            adap.Update(PDataSet, "SUBBAT")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region " Sub Sections Lock"

    Public Function SubSectionExamLock_Insert(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "SUBSECTIONSLOCK_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBSECTIONSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "SUBSEC")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function SubSectionExamLock_Delete(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "SUBSECTIONSLOCK_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBSECTIONSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.DeleteCommand = oCommand
            adap.Update(PDataSet, "SUBSEC")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region " Area Combination Mapping"

    Public Function Area_Comb_Map_Insert(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "AREA_COMB_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iCOMBAREASLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBAREASLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "COMBMAP")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Area_Comb_Map_Delete(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "AREA_COMB_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iCOMBAREASLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBAREASLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.DeleteCommand = oCommand
            adap.Update(PDataSet, "COMBMAP")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region " ExamType Combination Mapping"

    Public Function ExamType_Comb_Map_Insert(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "EXAMTYPE_COMB_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iEXAMTYPECOMBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPECOMBSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "COMBMAP")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamType_Comb_Map_Delete(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "EXAMTYPE_COMB_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iEXAMTYPECOMBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPECOMBSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.DeleteCommand = oCommand
            adap.Update(PDataSet, "COMBMAP")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region " Area ExamBranches Mapping"

    Public Function Area_ExamBranch_Map_Insert(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "AREA_EXAMBRANCH_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iAREAEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AREAEXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "EBMAP")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Area_ExamBranch_Map_Delete(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "AREA_EXAMBRANCH_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iAREAEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AREAEXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.DeleteCommand = oCommand
            adap.Update(PDataSet, "EBMAP")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region " Dean Exambranch Wise Mapping "

    Public Function Branchsave(ByVal iEXAMBRANCHSLNO As Integer, ByVal iEXAMREGIONSLNO As Integer, ByVal iUSERSLNO As Integer) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "Branchdivisionsave"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMREGIONSLNO

            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO


            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

End Class
