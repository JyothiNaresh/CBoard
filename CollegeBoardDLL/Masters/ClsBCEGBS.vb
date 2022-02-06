'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating TOPICS
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 11-OCT-2006
'   FINAL BASELINE DATE               : 11-OCT-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsBCEGBS


#Region "Class Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection

#End Region

#Region "Fill Methods"

    Public Function Branch_Fill(ByVal PStatus As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "BCEGBS_BRANCH_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME IUSERID
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


    Public Function Course_Fill(ByVal iBranchSlno As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "BCEGBS_COURSE_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBranchSlno


            'ADD IN PARAMETER NAME AS DATACUR
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


    Public Function ExamBranch_Fill(ByVal iBranchSlno As Integer, ByVal iCourseSlno As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "BCEGBS_EXAMBRANCH_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBranchSlno

            'ADD IN PARAMETER NAME COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Group_Fill(ByVal iCourseSlno As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "BCEGBS_GROUP_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'ADD IN PARAMETER NAME DATACUR
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


    Public Function Batch_Fill(ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "BCEGBS_BATCH_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'ADD IN PARAMETER NAME GROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

            'ADD IN PARAMETER NAME DATACUR
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


    Public Function Section_Fill(ByVal PStatus As String, ByVal From As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "BCEGBS_SECTION_FETCH"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "BCEGBS_SUBSECTION_FETCH"
            End If
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME STATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DATACURSOR
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


    Public Function EbSectionName_Fetch(ByVal iBranchSlno As Integer, ByVal iCourseSlno As Integer, ByVal iExamBranchSlno As Integer, ByVal From As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "M_BCEGBS_SNAME"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "M_BCEGBSS_FETCH"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBranchSlno


            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iExamBranchSlno


            'ADD IN PARAMETER NAME IUSERID
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


    Public Function BCEGBS_Code(ByVal iCode As Integer, ByVal From As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "M_BCEGBS_FETCH"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "M_BCEGBSS_FETCH"
            End If


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

    Public Function BCEGBS_Update(ByVal Slno As Integer, ByVal From As String, ByVal BranchSlno As Integer, ByVal CourseSlno As Integer, ByVal ExamBranchSlno As Integer, ByVal GroupSlno As Integer, ByVal BatchSlno As Integer, ByVal SectionSlno As Integer, ByVal EBSecName As String, ByVal Descr As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "F_BCEGBS_UPDATE"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "F_BCEGBSS_UPDATE"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BCEGBSSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Slno

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BranchSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno

            'ADD IN PARAMETER NAME EXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME BATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME SECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSlno

            'ADD IN PARAMETER NAME EBSECTIONNAME
            oParameter = oCommand.Parameters.Add("iEBSECTIONNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EBSecName


            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Descr

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

    Public Function BCEGBS_Insert(ByVal BranchSlno As Integer, ByVal From As String, ByVal CourseSlno As Integer, ByVal ExamBranchSlno As Integer, ByVal GroupSlno As Integer, ByVal BatchSlno As Integer, ByVal SectionSlno As Integer, ByVal EbSecName As String, ByVal Descr As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "F_INSERT_EXAM_BCEGBS"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "F_INSERT_EXAM_BCEGBSS"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BranchSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno

            'ADD IN PARAMETER NAME EXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME BATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME SECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSlno

            'ADD IN PARAMETER NAME SECTIONSLNO
            oParameter = oCommand.Parameters.Add("iEBSECTIONNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EbSecName

            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Descr


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

    Public Function BCEGBS_Delete(ByVal PSlNo As String, ByVal From As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "F_CGBSECTION_DELETE"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "F_BCEGBSS_DELETE"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

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

#End Region

#Region "BatchMode Methods"

    Public Function BCEGBS_BatchInsert(ByVal PDataSet As DataSet, ByVal From As String) As String
        Dim strReturn As String
        Dim PName As String
        Dim PDescription As String
        Dim drow As DataRow
        Dim dSet As DataSet
        Dim dTable As DataTable
        Dim i As Integer
        Dim Trans As OracleTransaction
        Dim adap As New OracleDataAdapter
        Dim Cmd As New OracleClient.OracleCommand
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            Cmd.Transaction = OraTrans

            If From = "Section" Then
                Cmd.CommandText = "M_BCEGBS_BATCHINSERT"
            ElseIf From = "SubSection" Then
                Cmd.CommandText = "M_BCEGBSS_BATCHINSERT"
            End If

            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANCHSLNO"


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"



            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iSECTION", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTION"


            'ADD IN PARAMETER NAME SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iEBSECTIONNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EBSECTIONNAME"




            'ADD IN PARAMETER NAME 
            oParameter = Cmd.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"



            adap.InsertCommand = Cmd
            adap.Update(PDataSet, "BCEGBS")
            OraTrans.Commit()
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1
    End Function


#End Region

#Region "Section Ranges"

    Public Function SaveSectionRanges(ByVal Dset As DataSet, ByVal InsertFor As String) As String
        Dim rtnString As String
        Try
            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            If InsertFor = "Section" Then
                oCommand.CommandText = "P_EXAM_CGBSECTION_INSERT"
            Else
                oCommand.CommandText = "P_EXAM_BCEGBSS_INSERT"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'uCommand.CommandText = "DEFINEEXAM_UPDATE"
            'uCommand.Connection = oConn
            'uCommand.CommandType = CommandType.StoredProcedure
            'uCommand.Transaction = oTrans


            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'ADD IN PARAMETER NAME iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'ADD IN PARAMETER NAME iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"

            'ADD IN PARAMETER NAME iSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTION", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTION"

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            oAdapter.InsertCommand = oCommand


            oAdapter.Update(Dset, "BCEGBS")
            oTrans.Commit()

            rtnString = "Record Saved"

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = "Fail"
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

#End Region


    Public Function SubBatch_Fill(ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer, ByVal iEXAMBRANCHSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "BCEGBS_SUBBATCH_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno


            'ADD IN PARAMETER NAME GROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

            'ADD IN PARAMETER NAME EXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO


            'ADD IN PARAMETER NAME DATACUR
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

    Public Function ExamTarget_Fill(ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer, ByVal iSUBBATCHSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "BCEGBS_EXAMTARGET_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno


            'ADD IN PARAMETER NAME GROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

            'ADD IN PARAMETER NAME SUBBATCHSLNO
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSUBBATCHSLNO

            'ADD IN PARAMETER NAME DATACUR
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

#Region "Faculty Recurement Mapping "

    Public Function FRMAP_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "FRMAP_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            oCommand.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function FRMAP_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet


            oCommand.CommandText = "FRMAP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function FRMAP_Insert(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "FRMAP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)


            oParameter = oCommand.Parameters.Add("iJL_TEACH", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iJL_CONC", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iSL_TEACH", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iSL_CONC", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)


            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oCommand.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function FRMAP_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "FRMAP_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)


            oParameter = oCommand.Parameters.Add("iJL_TEACH", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iJL_CONC", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iSL_TEACH", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iSL_CONC", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)


            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oCommand.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function Subject_Fill(ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "BCEGBS_SUBJECT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno


            'ADD IN PARAMETER NAME GROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno


            'ADD IN PARAMETER NAME DATACUR
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

End Class
