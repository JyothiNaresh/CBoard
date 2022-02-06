'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exams Question Paper Tailoring
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 16-AUG-2006
'   FINAL BASELINE DATE               : 16-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsQPTTailor

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Dim ObjConn As Connection

#End Region

#Region "QPTTAILOR"

    Private Function DfineExam_Insert(ByVal oConn As OracleConnection, ByVal oTrans As OracleTransaction, ByVal QName As String, ByVal CourseSlno As Integer, ByVal Desc As String)
        Dim Result As Integer
        Try
            oCommand = New OracleCommand
            oCommand.CommandText = ""

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'Add In Parameter as Exam Name
            oParameter = oCommand.Parameters.Add("iQPNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QName

            'Add In Parameter as Course SLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno

            'Add In Parameter as Description
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Desc

            oCommand.Parameters.Add(New OracleParameter("rtnID", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Result = oCommand.Parameters("rtnID").Value

            Return Result

        Catch ex As Exception

        End Try

    End Function

    Private Function DfineExam_Update(ByVal oConn As OracleConnection, ByVal oTrans As OracleTransaction, ByVal QPTTailrSlno As Integer, ByVal QName As String, ByVal Descr As String)
        Try
            oCommand = New OracleClient.OracleCommand
            oCommand.CommandText = "M_QPTMT_UPDATE"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add In Parameter As Quepaper Name
            oParameter = oCommand.Parameters.Add("iqueName", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QName

            'Add In Parameter As Description
            oParameter = oCommand.Parameters.Add("iDesc", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Descr

            'Add In Parameter Name as Exam Slno
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QPTTailrSlno

            oCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try

    End Function

    ''Public Function quePaperTypeTailor_Save(ByVal QDataSet As DataSet, ByVal iQPTTSLNO As Integer) As String

    Public Function quePaperTypeTailor_Save(ByVal QDataSet As DataSet) As String
        Dim rtnString As String
        Dim resultSlno As Integer

        ObjConn = New Connection
        oConn = ObjConn.GetConnection

        oTrans = oConn.BeginTransaction

        Try
            If Not IsNothing(QDataSet) Then
                'If iQPTTSLNO = 0 Then
                '    resultSlno = DfineExam_Insert(oConn, oTrans, quePaperName, courseSlno, Descr)
                'Else
                '    resultSlno = iQPTTSLNO
                '    'DfineExam_Update(oConn, oTrans, resultSlno, quePaperName, Descr)
                'End If
                ''QPTTAILOR_Insert_Update_delete(oConn, oTrans, QDataSet,iQPTTSLNO)

                QPTTAILOR_Insert_Update_delete(oConn, oTrans, QDataSet)
                oTrans.Commit()
                rtnString = "0-SUCCESS"
            End If

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    '''Private Function QPTTAILOR_Insert_Update_delete(ByVal oConn As OracleConnection, ByVal oTrans As OracleTransaction, ByVal QDataSet As DataSet, ByVal QPTTailorSlno As Integer)
    Private Function QPTTAILOR_Insert_Update_delete(ByVal oConn As OracleConnection, ByVal oTrans As OracleTransaction, ByVal QDataSet As DataSet)
        Try
            Dim UCommand As New OracleCommand
            Dim DCommand As New OracleCommand
            oCommand = New OracleCommand


            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            'For Inserting Command
            oCommand.Transaction = oTrans
            oCommand.CommandText = "M_INSERT_QPTTAILOR"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'For Updating Command
            UCommand.Transaction = oTrans
            UCommand.CommandText = "M_QPTTAILOR_UPDATE"
            UCommand.Connection = oConn
            UCommand.CommandType = CommandType.StoredProcedure


            'For Deleting Command
            DCommand.Transaction = oTrans
            DCommand.CommandText = "M_QPTTAILOR_DELETE"
            DCommand.Connection = oConn
            DCommand.CommandType = CommandType.StoredProcedure


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '****************************************INSERT***************************************'
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter as ExamSlno
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            ''oParameter.Value = QPTTailorSlno
            oParameter.SourceColumn = "DEXAMSLNO"


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

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'oCommand.ExecuteNonQuery()
            oAdapter.InsertCommand = oCommand

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '****************************************UPDATE***************************************'
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter As ExmCourseSubSlno
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'Add In Parameter As ExmCourseSubSlno
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNO"

            'Add In Parameter As Subject Slno
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'Add In Parameter Name as Track Slno
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'Add In Parameter Name as Topic Slno
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add In Parameter Name as ExamType Slno
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'Add In Parameter As Negative Marks
            oParameter = UCommand.Parameters.Add("iNOOFQUE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'Add In Parameter As Correct Marks
            oParameter = UCommand.Parameters.Add("iCORMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'Add In Parameter As No Of Negative Marks
            oParameter = UCommand.Parameters.Add("iNEGMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"


            'Add In Parameter as Mini Marks
            oParameter = UCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = UCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            oAdapter.UpdateCommand = UCommand


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '****************************************DELETE***************************************'
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Add In Parameter As ExmCourseSubSlno
            oParameter = DCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNO"

            oAdapter.DeleteCommand = DCommand

            oAdapter.Update(QDataSet, "QPTTAILOR")

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function


    Public Function QptTailor_Fetch(ByVal Qpttslno As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "M_QPTTAILOR_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Qpttslno

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "QPTTAILOR")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function


    Public Function QPTT_Fetch(ByVal DExamSlno As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "M_QPTT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as ExamName
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSlno

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "QPTTAILOR")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    '<WebMethod(Description:="Fetchs the data With Respect to Define Exam Slno Into Grid")> _
    'Public Function QPTT_Get(ByVal DExamSlno As Integer) As DataSet
    '       Try
    '           oConn = GetConnection()
    '           oConn.Open()

    '           oCommand = New OracleClient.OracleCommand
    '           oParameter = New OracleClient.OracleParameter
    '           oAdapter = New OracleClient.OracleDataAdapter

    '           ds = New DataSet

    '           oCommand.CommandText = "M_QPTT_GET"
    '           oCommand.Connection = oConn
    '           oCommand.CommandType = CommandType.StoredProcedure

    '           'Add In Parameter as ExamName
    '           oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
    '           oParameter.Direction = ParameterDirection.Input
    '           oParameter.Value = DExamSlno

    '           oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
    '           oParameter.Direction = ParameterDirection.Output

    '           oAdapter.SelectCommand = oCommand
    '           oAdapter.Fill(ds)

    '       Catch ex As Exception
    '           Throw New SoapException("", SoapException.ClientFaultCode, ex.Message)
    '       Finally
    '           oConn.Close()
    '       End Try
    '       Return ds
    '   End Function


    Public Function QPTT_Search(ByVal iQueName As String, ByVal iExamName As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "M_QPTT_EQSEARCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iQueName", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iQueName

            oParameter = oCommand.Parameters.Add("iExamName", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iExamName

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function


    Public Function EXAM_QPTTTAILOR_DELETE(ByVal iQPTTSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As String
        Dim returnStr As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.CommandText = "M_QPTTAILOR_DELETE"
            oCommand.Connection = oConn
            oCommand.Transaction = oTrans

            'Add In Parameter As QpttSlno
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iQPTTSLNO

            'Add In Parameter As Dexamslno
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'Add In Parameter As iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            returnStr = oCommand.ExecuteNonQuery()
            returnStr = "Record Delete Successfully"
            oTrans.Commit()

        Catch ex As Exception
            Throw ex
            oTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return returnStr

    End Function

    Public Function EXAM_IITQPAPERMAPPING(ByVal IMAINQPTSLNO As Integer, ByVal ICOPYQPTSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As String
        Dim returnStr As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oTrans = oConn.BeginTransaction
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.CommandText = "IIT_QPAPERMAPPING"
            oCommand.Connection = oConn
            oCommand.Transaction = oTrans

            'Add In Parameter As QpttSlno
            oParameter = oCommand.Parameters.Add("IMAINQPTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IMAINQPTSLNO

            'Add In Parameter As Dexamslno
            oParameter = oCommand.Parameters.Add("ICOPYQPTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ICOPYQPTSLNO

            'Add In Parameter As iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            returnStr = oCommand.ExecuteNonQuery()
            returnStr = "Record Delete Successfully"
            oTrans.Commit()

            Return " Question Paper Mapped Successfully..!"

        Catch ex As Exception
            Throw ex
            oTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return returnStr

    End Function

#End Region
End Class
