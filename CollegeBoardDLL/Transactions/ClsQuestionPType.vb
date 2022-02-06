'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exams
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 16-AUG-2006
'   FINAL BASELINE DATE               : 16-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsQuestionPType

#Region "Common Variables"
    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection

#End Region


#Region "Exam Type Single"

    Private Function QPTHead_Insert(ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal iEXAMBRANCHSLNO As Integer, ByVal QuePaperName As String, ByVal CourseSlno As Integer, ByVal Descr As String, ByVal iCOMACADEMICSLNO As Integer) As String

        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oCommand.CommandText = "F_INSERT_QPTYPE"

            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'Add In Parameter as Course iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add In Parameter as Exam Name
            oParameter = oCommand.Parameters.Add("iQPNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuePaperName

            'Add In Parameter as Course SLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'Add In Parameter as Description
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Descr

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally

        End Try

        Return strReturn

    End Function

    Private Function QPTHead_Update(ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal iEXAMBRANCHSLNO As Integer, ByVal iQpSlno As Integer, ByVal QuePaperName As String, ByVal Descr As String) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oCommand.CommandText = "F_QPTMT_UPDATE"

            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            ''Add In Parameter as Course iEXAMBRANCHSLNO
            'oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = iEXAMBRANCHSLNO

            'Add In Parameter As Quepaper Name
            oParameter = oCommand.Parameters.Add("iqueName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuePaperName

            'Add In Parameter As Description
            oParameter = oCommand.Parameters.Add("iDesc", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Descr

            'Add In Parameter Name as Exam Slno
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iQpSlno

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue

            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception

        End Try
        Return strReturn
    End Function


    Public Function QPTHeader_Save(ByVal iEXAMBRANCHSLNO As Integer, ByVal iQpSlno As Integer, ByVal quePaperName As String, ByVal courseSlno As Integer, ByVal Descr As String, ByVal iCOMACADEMICSLNO As Integer) As String
        Dim rtnString As String
        Dim resultSlNo As Integer

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction
            If iQpSlno = 0 Then
                rtnString = QPTHead_Insert(oConn, oTrans, iEXAMBRANCHSLNO, quePaperName, courseSlno, Descr, iCOMACADEMICSLNO)
            Else
                resultSlNo = iQpSlno
                rtnString = QPTHead_Update(oConn, oTrans, iEXAMBRANCHSLNO, resultSlNo, quePaperName, Descr)
            End If

            oTrans.Commit()

        Catch ex As Exception
            Throw ex
            oTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function          '''''USING WS


    Public Function QuestionPaper_Save(ByVal PdataSet As DataSet, ByVal iQpSlno As Integer) As String
        Dim rtnString As String
        Dim resultSlNo As Integer
        'Dim i As Integer

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction

            If Not IsNothing(PdataSet) Then
                ExmCouSubNaidu_Insert(PdataSet, iQpSlno, oConn, oTrans)
            End If
            oTrans.Commit()
            rtnString = "0-SUCCESS"
        Catch ex As Exception
            Throw ex
            oTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString
    End Function

    Private Function ExmCouSubNaidu_Insert(ByVal dsSet As DataSet, ByVal iQpSlno As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try
            Dim UCommand As New OracleCommand
            Dim DCommand As New OracleCommand

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            'For Inserting Command
            oCommand.Transaction = pTrans
            oCommand.CommandText = "M_INSERT_QPTYPEDT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure


            'For Updating Command
            UCommand.Transaction = pTrans
            UCommand.CommandText = "M_QPTYPEDT_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure


            'For Deleting Command
            DCommand.Transaction = pTrans
            DCommand.CommandText = "M_QPTYPEDT_DELETE"
            DCommand.Connection = pConn
            DCommand.CommandType = CommandType.StoredProcedure


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '****************************************INSERT***************************************'
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter as ExamSlno
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iQpSlno


            'Add In Parameter as SubjectSlno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'Add In Parameter as TrackSlno
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'Add In Parameter as TopicSlno
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add In Parameter as QuestionPaperTypeSlno
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'Add In Parameter as Number Of Questions
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'Add In Parameter as Correct Marks
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"


            'Add In Parameter as Negative Marks
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'Add In Parameter as Mini Marks
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"


            'Add In Parameter as COMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'oCommand.ExecuteNonQuery()
            oAdapter.InsertCommand = oCommand

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '****************************************UPDATE***************************************'
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Add In Parameter As ExmCourseSubSlno
            oParameter = UCommand.Parameters.Add("iqpdtslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTDTSLNO"

            'Add In Parameter As Subject Slno
            oParameter = UCommand.Parameters.Add("iSubjectSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'Add In Parameter Name as Track Slno
            oParameter = UCommand.Parameters.Add("iTrackSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'Add In Parameter Name as Topic Slno
            oParameter = UCommand.Parameters.Add("iTopicSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add In Parameter Name as ExamType Slno
            oParameter = UCommand.Parameters.Add("iExamTypeSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'Add In Parameter As Negative Marks
            oParameter = UCommand.Parameters.Add("iNoOfque", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'Add In Parameter As Correct Marks
            oParameter = UCommand.Parameters.Add("iCorrMark", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'Add In Parameter As No Of Negative Marks
            oParameter = UCommand.Parameters.Add("iNegMark", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"


            'Add In Parameter as Mini Marks
            oParameter = UCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"

            oAdapter.UpdateCommand = UCommand


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '****************************************DELETE***************************************'
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter As ExmCourseSubSlno
            oParameter = DCommand.Parameters.Add("iQPTDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTDTSLNO"

            oAdapter.DeleteCommand = DCommand

            oAdapter.Update(dsSet, "ExamType")

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function


    Public Function Qptdt_Fetch(ByVal Qptdtslno As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "M_QPTYPEDT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParameter = oCommand.Parameters.Add("iQPTDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Qptdtslno

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamType")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function           '''''''''USING WS


    Public Function Qptdt_Delete(ByVal Qptdtslno As Integer) As String
        Dim strReturn As String


        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "M_QPTYPEDT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParameter = oCommand.Parameters.Add("iQPTDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Qptdtslno

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function       '''''USING WS


    Public Function QPTMT_Delete(ByVal PSlNo As String, Optional ByVal strType As String = "", Optional ByVal COMACADEMICSLNO As Integer = 0) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If strType = "IIT" Then
                oCommand.CommandText = "F_IITQPTYPEMT_DELETE"
            Else
                oCommand.CommandText = "F_QPTYPEMT_DELETE"
            End If


            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            If strType = "IIT" Then
                'ADD IN PARAMETER NAME FOR COMACADEMICSLNO
                oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = COMACADEMICSLNO
            End If

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function           '''''''''USING STORED WS


#End Region

#Region "Exam Type Details"


    Public Function ExmTypeSingle_Fetch(ByVal QptSlno As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "M_COURSEWISEPAPERS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as ExamName
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QptSlno

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamType")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function      '''''Using WS

#End Region

#Region "DataSetFetch"


    Public Function dataSet_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "PARSE_SQLSTRING"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParameter = oCommand.Parameters.Add("iSqlString", OracleType.VarChar, 5000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSqlString

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


#End Region

#Region " Staff Question Type "

    Private Function Staff_QPTHead_Insert(ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal iEXAMBRANCHSLNO As Integer, ByVal QuePaperName As String, ByVal CourseSlno As Integer, ByVal Descr As String, ByVal iCOMACADEMICSLNO As Integer) As String

        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            'F_INSERT_QPTYPE
            oCommand.CommandText = "F_STAFF_QPTYPE"

            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'Add In Parameter as Course iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add In Parameter as Exam Name
            oParameter = oCommand.Parameters.Add("iQPNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuePaperName

            'Add In Parameter as Course SLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'Add In Parameter as Description
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Descr

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally

        End Try

        Return strReturn

    End Function

    Private Function Staff_QPTHead_Update(ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal iEXAMBRANCHSLNO As Integer, ByVal iQpSlno As Integer, ByVal QuePaperName As String, ByVal Descr As String) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            'F_QPTMT_UPDATE
            oCommand.CommandText = "STAFF_QPTMT_UPDATE"

            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            ''Add In Parameter as Course iEXAMBRANCHSLNO
            'oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = iEXAMBRANCHSLNO

            'Add In Parameter As Quepaper Name
            oParameter = oCommand.Parameters.Add("iqueName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuePaperName

            'Add In Parameter As Description
            oParameter = oCommand.Parameters.Add("iDesc", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Descr

            'Add In Parameter Name as Exam Slno
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iQpSlno

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue

            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception

        End Try
        Return strReturn
    End Function


    Public Function Staff_QPTHeader_Save(ByVal iEXAMBRANCHSLNO As Integer, ByVal iQpSlno As Integer, ByVal quePaperName As String, ByVal courseSlno As Integer, ByVal Descr As String, ByVal iCOMACADEMICSLNO As Integer) As String
        Dim rtnString As String
        Dim resultSlNo As Integer

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction
            If iQpSlno = 0 Then
                rtnString = Staff_QPTHead_Insert(oConn, oTrans, iEXAMBRANCHSLNO, quePaperName, courseSlno, Descr, iCOMACADEMICSLNO)
            Else
                resultSlNo = iQpSlno
                rtnString = Staff_QPTHead_Update(oConn, oTrans, iEXAMBRANCHSLNO, resultSlNo, quePaperName, Descr)
            End If

            oTrans.Commit()

        Catch ex As Exception
            Throw ex
            oTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function          '''''USING WS

    Public Function Staff_QPTMT_Delete(ByVal PSlNo As String, Optional ByVal strType As String = "", Optional ByVal COMACADEMICSLNO As Integer = 0) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If strType = "IIT" Then
                oCommand.CommandText = "STAFF_QPTYPEMT_DELETE"
            End If


            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            If strType = "IIT" Then
                'ADD IN PARAMETER NAME FOR COMACADEMICSLNO
                oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = COMACADEMICSLNO
            End If

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function           '''''''''USING STORED WS


    Public Function StaffExmTypeSingle_Fetch(ByVal QptSlno As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "STAFF_COURSEWISEPAPERS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as ExamName
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QptSlno

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamType")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    '=========> CHANDRA

    Public Function StaffQptdt_Fetch(ByVal Qptdtslno As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "STAFF_QPTYPEDT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParameter = oCommand.Parameters.Add("iQPTDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Qptdtslno

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamType")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function           '''''''''USING WS

    Public Function StaffQuestionPaper_Save(ByVal PdataSet As DataSet, ByVal iQpSlno As Integer) As String
        Dim rtnString As String
        Dim resultSlNo As Integer
        'Dim i As Integer

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction

            If Not IsNothing(PdataSet) Then
                StaffExmCouSubNaidu_Insert(PdataSet, iQpSlno, oConn, oTrans)
            End If
            oTrans.Commit()
            rtnString = "0-SUCCESS"
        Catch ex As Exception
            Throw ex
            oTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString
    End Function

    Private Function StaffExmCouSubNaidu_Insert(ByVal dsSet As DataSet, ByVal iQpSlno As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try
            Dim UCommand As New OracleCommand
            Dim DCommand As New OracleCommand

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            'For Inserting Command
            oCommand.Transaction = pTrans
            oCommand.CommandText = "STAFF_INSERT_QPTYPEDT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure


            'For Updating Command
            UCommand.Transaction = pTrans
            UCommand.CommandText = "STAFF_QPTYPEDT_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure


            'For Deleting Command
            DCommand.Transaction = pTrans
            DCommand.CommandText = "STAFF_QPTYPEDT_DELETE"
            DCommand.Connection = pConn
            DCommand.CommandType = CommandType.StoredProcedure


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '****************************************INSERT***************************************'
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter as ExamSlno
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iQpSlno


            'Add In Parameter as SubjectSlno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'Add In Parameter as TrackSlno
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'Add In Parameter as TopicSlno
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add In Parameter as QuestionPaperTypeSlno
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'Add In Parameter as Number Of Questions
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'Add In Parameter as Correct Marks
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"


            'Add In Parameter as Negative Marks
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'Add In Parameter as Mini Marks
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"


            'Add In Parameter as COMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'oCommand.ExecuteNonQuery()
            oAdapter.InsertCommand = oCommand

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '****************************************UPDATE***************************************'
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Add In Parameter As ExmCourseSubSlno
            oParameter = UCommand.Parameters.Add("iqpdtslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTDTSLNO"

            'Add In Parameter As Subject Slno
            oParameter = UCommand.Parameters.Add("iSubjectSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'Add In Parameter Name as Track Slno
            oParameter = UCommand.Parameters.Add("iTrackSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'Add In Parameter Name as Topic Slno
            oParameter = UCommand.Parameters.Add("iTopicSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add In Parameter Name as ExamType Slno
            oParameter = UCommand.Parameters.Add("iExamTypeSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'Add In Parameter As Negative Marks
            oParameter = UCommand.Parameters.Add("iNoOfque", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'Add In Parameter As Correct Marks
            oParameter = UCommand.Parameters.Add("iCorrMark", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'Add In Parameter As No Of Negative Marks
            oParameter = UCommand.Parameters.Add("iNegMark", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"


            'Add In Parameter as Mini Marks
            oParameter = UCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"

            oAdapter.UpdateCommand = UCommand


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '****************************************DELETE***************************************'
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter As ExmCourseSubSlno
            oParameter = DCommand.Parameters.Add("iQPTDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTDTSLNO"

            oAdapter.DeleteCommand = DCommand

            oAdapter.Update(dsSet, "ExamType")

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    Public Function StaffQPTMT_Delete(ByVal PSlNo As String, Optional ByVal strType As String = "", Optional ByVal COMACADEMICSLNO As Integer = 0) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If strType = "IIT" Then
                oCommand.CommandText = "STAFF_IITQPTYPEMT_DELETE"
            Else
                oCommand.CommandText = "STAFF_QPTYPEMT_DELETE"
            End If


            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            If strType = "IIT" Then
                'ADD IN PARAMETER NAME FOR COMACADEMICSLNO
                oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = COMACADEMICSLNO
            End If

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function           '''''''''USING STORED WS

    Public Function StaffQptdt_Delete(ByVal Qptdtslno As Integer) As String
        Dim strReturn As String


        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "STAFF_QPTYPEDT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParameter = oCommand.Parameters.Add("iQPTDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Qptdtslno

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function       '''''USING WS

    Public Function StaffQPTHeader_Save(ByVal iEXAMBRANCHSLNO As Integer, ByVal iQpSlno As Integer, ByVal quePaperName As String, ByVal courseSlno As Integer, ByVal Descr As String, ByVal iCOMACADEMICSLNO As Integer) As String
        Dim rtnString As String
        Dim resultSlNo As Integer

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction
            If iQpSlno = 0 Then
                rtnString = StaffQPTHead_Insert(oConn, oTrans, iEXAMBRANCHSLNO, quePaperName, courseSlno, Descr, iCOMACADEMICSLNO)
            Else
                resultSlNo = iQpSlno
                rtnString = StaffQPTHead_Update(oConn, oTrans, iEXAMBRANCHSLNO, resultSlNo, quePaperName, Descr)
            End If

            oTrans.Commit()

        Catch ex As Exception
            Throw ex
            oTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function          '''''USING WS

    Private Function StaffQPTHead_Insert(ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal iEXAMBRANCHSLNO As Integer, ByVal QuePaperName As String, ByVal CourseSlno As Integer, ByVal Descr As String, ByVal iCOMACADEMICSLNO As Integer) As String

        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oCommand.CommandText = "STAFF_INSERT_QPTYPE"

            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'Add In Parameter as Course iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add In Parameter as Exam Name
            oParameter = oCommand.Parameters.Add("iQPNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuePaperName

            'Add In Parameter as Course SLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'Add In Parameter as Description
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Descr

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally

        End Try

        Return strReturn

    End Function

    Private Function StaffQPTHead_Update(ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal iEXAMBRANCHSLNO As Integer, ByVal iQpSlno As Integer, ByVal QuePaperName As String, ByVal Descr As String) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oCommand.CommandText = "STAFF_QPTMT_UPDATE"

            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            ''Add In Parameter as Course iEXAMBRANCHSLNO
            'oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = iEXAMBRANCHSLNO

            'Add In Parameter As Quepaper Name
            oParameter = oCommand.Parameters.Add("iqueName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuePaperName

            'Add In Parameter As Description
            oParameter = oCommand.Parameters.Add("iDesc", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Descr

            'Add In Parameter Name as Exam Slno
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iQpSlno

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue

            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception

        End Try
        Return strReturn
    End Function

    '=========> CHANDRA

#End Region

#Region " Sub Batch"

    Public Function Subbatch(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal SqlString1 As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = SpName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString1

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output



            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Dset, DTable) '"Society")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Dset

    End Function

    Public Function Subbatch1(ByVal SqlString1 As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "PARSE_SQLSTRING1"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString1

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

            Return ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

#End Region

End Class
