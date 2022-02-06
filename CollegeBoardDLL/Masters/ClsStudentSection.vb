'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exams Branch Wise Students
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 16-AUG-2006
'   FINAL BASELINE DATE               : 16-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsStudentSection
#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As Data.DataSet
    Dim ObjConn As Connection


#End Region

#Region "Fill Method For Section Under Branchslno,CourseSlno,GroupSlno,BatchSlno,ExamBranchsLSno"


    Public Function Section_Fill(ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer, ByVal iBatchslno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "STUSECTION_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure




            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno


            'Add in parameter as Group slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

            'Add in parameter as Batch Slno
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBatchslno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function Section_Fill_New(ByVal iCOMACADEMICSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer, ByVal iBatchslno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "STUSECTION_FETCHNEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("IEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'Add in parameter as Group slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

            'Add in parameter as Batch Slno
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBatchslno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function AssignedSection_Fill(ByVal iEXAMBRANCHSLNO As Integer, ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer, ByVal iBatchslno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "ASSIGNEDSECTION_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno


            'Add in parameter as Group slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

            'Add in parameter as Batch Slno
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBatchslno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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


    Public Function AssignedSubSection_Fill(ByVal iEXAMBRANCHSLNO As Integer, ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer, ByVal iComacademicslno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "ASSIGNEDSUBSECTION_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno


            'Add in parameter as Group slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

            'Add in parameter as Batch Slno
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iComacademicslno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function GetEmployeByEmpNo(ByVal iEmpNo As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "EMPLOYEEBYEMPNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iEMPNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEmpNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function GetSubSecIncharege(ByVal iCOMACADEMICSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iGROUPSLNO As Integer, ByVal iSUBSECTIONSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "GETSUBSECTIONINCHARGE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSESLNO

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGROUPSLNO

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSUBSECTIONSLNO


            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function AssignSection_Fill(ByVal iBranchSlno As Integer, ByVal iCourseSlno As Integer, ByVal iExamBranchSlno As Integer, ByVal iGroupSlno As Integer, ByVal iBatchslno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "ASSIGNSTUSECTION_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add in parameter as Branch slno
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBranchSlno

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'Add in parameter as ExamBranchSlno
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iExamBranchSlno

            'Add in parameter as Group slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

            'Add in parameter as Batch Slno
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBatchslno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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


    Public Function SectionTTS_Fill(ByVal iBranchSlno As Integer, ByVal iCourseSlno As Integer, ByVal iExamBranchSlno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "SECTIONTTS_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add in parameter as Branch slno
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBranchSlno

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'Add in parameter as ExamBranchSlno
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iExamBranchSlno


            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function Section_Fill(ByVal iBranchSlno As Integer, ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer, ByVal iBatchslno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "EBSTUSECTION_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBranchSlno

            'Add in parameter as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno


            'Add in parameter as Group slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

            'Add in parameter as Batch Slno
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBatchslno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

#Region "Single Mode Methods"



    Public Function StudentSection_Code(ByVal iCode As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_STUSECTION_FETCH"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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


    Public Function StudentSection_Delete(ByVal Admslno As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "F_STUDENTSECTION_DELETE"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS PRIMARY KEYSLNO
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Admslno

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function


    Public Function StudentSectionSingle_Insert(ByVal dsSet As DataSet) As String
        Dim strReturn As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter



            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "F_STUDENTSECTION_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(dsSet, "STUSECTION")

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            OraTrans.Commit()

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn

    End Function


    Public Function StudentSection_Update(ByVal Admslno As Integer, ByVal iStuSecSlno As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            OraTrans = oConn.BeginTransaction

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ds = New Data.DataSet

            ''''''''''''For Dummy Table Insertions
            ''''''StudentSection_DummyInsert(dsSet, oConn, OraTrans)


            strReturn = StudentSection_Update(Admslno, iStuSecSlno, oConn, OraTrans)

            OraTrans.Commit()

        Catch ex As Exception
            Throw ex
            OraTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn

    End Function

    ''For Original Table Updations
    Private Function StudentSection_Update(ByVal Admslno As Integer, ByVal iStuSecSlno As Integer, ByVal oConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Dim StrReturn As String

        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "F_STUDENTSECTION_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS Primary Key Slno
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Admslno

            'ADD IN PARAMETER NAME AS Primary Key Slno
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iStuSecSlno

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            StrReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception

        End Try

        Return StrReturn


    End Function

    ''''''''''For Dummy Table Insertions
    '''''Private Sub StudentSection_DummyInsert(ByVal PDataSet As DataSet, ByVal oConn As OracleConnection, ByVal pTrans As OracleTransaction)

    '''''    Try
    '''''        oCommand = New OracleClient.OracleCommand
    '''''        oParameter = New OracleClient.OracleParameter
    '''''        oAdapter = New OracleDataAdapter


    '''''        oCommand.Transaction = pTrans
    '''''        oCommand.CommandText = "M_EXAM_STUSECTIONDUMMY_INSERT"
    '''''        oCommand.Connection = oConn
    '''''        oCommand.CommandType = CommandType.StoredProcedure

    '''''        'ADD IN PARAMETER NAME AS ADMSLNO
    '''''        oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
    '''''        oParameter.Direction = ParameterDirection.Input
    '''''        oParameter.SourceColumn = "ADMSLNO"

    '''''        'ADD IN PARAMETER NAME AS BRANCHSLNO
    '''''        oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
    '''''        oParameter.Direction = ParameterDirection.Input
    '''''        oParameter.SourceColumn = "BRANCHSLNO"

    '''''        'ADD IN PARAMETER NAME AS COURSESLNO
    '''''        oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
    '''''        oParameter.Direction = ParameterDirection.Input
    '''''        oParameter.SourceColumn = "COURSESLNO"

    '''''        'ADD IN PARAMETER NAME AS GROUPSLNO
    '''''        oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
    '''''        oParameter.Direction = ParameterDirection.Input
    '''''        oParameter.SourceColumn = "GROUPSLNO"

    '''''        'ADD IN PARAMETER NAME AS BATCHSLNO
    '''''        oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
    '''''        oParameter.Direction = ParameterDirection.Input
    '''''        oParameter.SourceColumn = "BATCHSLNO"


    '''''        'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
    '''''        oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
    '''''        oParameter.Direction = ParameterDirection.Input
    '''''        oParameter.SourceColumn = "EXAMBRANCHSLNO"

    '''''        'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
    '''''        oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
    '''''        oParameter.Direction = ParameterDirection.Input
    '''''        oParameter.SourceColumn = "SECTIONSLNO"

    '''''        'ADD IN PARAMETER NAME AS DESCRIPTION
    '''''        oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
    '''''        oParameter.Direction = ParameterDirection.Input
    '''''        oParameter.SourceColumn = "DESCRIPTION"

    '''''        oAdapter.InsertCommand = oCommand
    '''''        oAdapter.Update(PDataSet, "STUSECTION")

    '''''    Catch ex As Exception

    '''''        Throw New SoapException(ex.Message, SoapException.ClientFaultCode, ex.Message)

    '''''    Finally

    '''''    End Try

    '''''End Sub

#End Region

#Region "Batch Mode Methods"

    Public Function Exam_SectionChange_Save(ByVal Ds1 As DataSet) As String
        Dim rtnString As String
        Dim RtnVal1, RtnVal2 As Integer
        Try
            Dim setResult As String
            Dim Ds2 As DataSet

            Ds2 = Ds1.Copy
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()

            If Not IsNothing(Ds1) AndAlso Ds1.Tables(0).Rows.Count > 0 Then
                RtnVal1 = StudentSectionChange_Insert(Ds2)
                RtnVal2 = StudentSectionBatch_Insert(Ds1)
                If RtnVal1 = 1 AndAlso RtnVal1 = 1 Then
                    OraTrans.Commit()
                Else
                    OraTrans.Rollback()
                    rtnString = "Record Not Saved"
                End If
                rtnString = "Record Saved"
            End If

            Return 1

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function StudentSectionBatch_Insert(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "M_STUSECTION_BATCHINSERT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            uCommand.CommandText = "P_STUDENTSECTION_UPDATE"
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Connection = oConn
            ''uCommand.Transaction = OraTrans


            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            oAdapter.InsertCommand = oCommand


            'ADD IN PARAMETER NAME AS Primary SSSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'ADD IN PARAMETER NAME AS Primary Key Slno
            oParameter = uCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(dsSet, "STUSECTION")



        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1

    End Function

    Public Function StudentSectionChange_Insert(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "EXAM_SECTIONCHANGE_INSERT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "USERSLNO"


            oAdapter.InsertCommand = oCommand
            oAdapter.UpdateCommand = oCommand

            oAdapter.Update(dsSet, "STUSECTION")


        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1

    End Function

    Private Function DeleteBatchTimetable(ByVal BCEGBSSLNO As Integer, ByVal pEXAMBRANCHSLNO As Integer, ByVal TTFromDate As Date, ByVal TTToDate As Date, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "M_TTBATCH_DELETE"
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBCEGBSSLNO
            oParameter = oCommand.Parameters.Add("iBCEGBSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BCEGBSSLNO

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO 
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMBRANCHSLNO


            'ADD IN PARAMETER NAME iFROMDATE
            oParameter = oCommand.Parameters.Add("iFROMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TTFromDate

            'ADD IN PARAMETER NAME iTODATE
            oParameter = oCommand.Parameters.Add("iTODATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DBNull.Value

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''CREATED BY:-AMARENDRA
    ''DATE:-30-11-2005
    ''PURPOSE:Section Change Students are insert into Attendance table in batchupdate mode

    Public Function ChangeSectionStudent_Insert_Atnd(ByVal TOBCEGBSSLNO As Integer, ByVal FROMBCEGBSSLNO As Integer, ByVal TTFROMDATE As Date, ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            oCommand.CommandText = "NEW_TTADDSTUDENTSECTION"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iTOBCEGBSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TOBCEGBSSLNO

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iFROMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TTFROMDATE

            oParameter = oCommand.Parameters.Add("iFROMBCEGBSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = FROMBCEGBSSLNO

            'dsSet.GetChanges(DataRowState.Added)
            'dsSet.GetChanges(DataRowState.Modified)
            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dsSet, dsSet.Tables(0).TableName)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1

    End Function

    ''CREATED BY:-AMARENDRA
    ''DATE:-5-12-2005
    ''PURPOSE:Section Change Students are insert into Attendance table in single, batch mode

    Public Function ChangeSectionStudent_Single_Insert_Atnd(ByVal TOBCEGBSSLNO As Integer, ByVal TTFROMDATE As Date, ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "NEW_TTADDSTUDENTSECTION"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iTOBCEGBSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TOBCEGBSSLNO

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iFROMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TTFROMDATE

            oParameter = oCommand.Parameters.Add("iFROMBCEGBSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DBNull.Value

            'dsSet.GetChanges(DataRowState.Added)
            'dsSet.GetChanges(DataRowState.Modified)
            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dsSet, dsSet.Tables(0).TableName)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1

    End Function

#End Region

#Region "Search Criterias"


    Public Function studentSectionDetail_Search(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet


            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim SectionSlno As Integer
            Dim UserSlno As Integer
            Dim COMACADEMICSLNO As Integer


            strSplit = str.Split("~")

            'AdmBranchSlno = strSplit(0)
            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            SectionSlno = strSplit(7)
            UserSlno = strSplit(8)
            COMACADEMICSLNO = strSplit(9)

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSECTIONSEARCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS iCOURSESLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSlno

            'ADD IN PARAMETER NAME AS userslno
            oParameter = Cmd.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UserSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function


    Public Function studentSectionDetail_SearchNEW(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet


            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim SubBatchSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim SectionSlno As Integer
            Dim UserSlno As Integer
            Dim COMACADEMICSLNO As Integer


            strSplit = str.Split("~")

            'AdmBranchSlno = strSplit(0)
            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            SubBatchSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            SectionSlno = strSplit(7)
            UserSlno = strSplit(8)
            COMACADEMICSLNO = strSplit(9)

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSECTIONSEARCHNEW"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS iCOURSESLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubBatchSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSlno

            'ADD IN PARAMETER NAME AS userslno
            oParameter = Cmd.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UserSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function


    Public Function StudentSectionSingle_Fetch(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet

            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim COMACADEMICSLNO As Integer

            strSplit = str.Split("~")

            'AdmBranchSlno = strSplit(0)
            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            COMACADEMICSLNO = strSplit(7)


            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSECTIONFETCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME AS STUDENTSLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function


#End Region

#Region "DatasetFetch"


    Public Function dataSet_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
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
            oAdapter.Fill(ds, "STUSECTION")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


#End Region


End Class
