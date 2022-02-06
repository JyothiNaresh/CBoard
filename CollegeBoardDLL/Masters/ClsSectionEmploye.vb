'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Section Wise Emp.
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 19-AUG-2006
'   FINAL BASELINE DATE               : 19-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Imports CommonDLL

Public Class ClsSectionEmploye

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As New Data.DataSet
    Private ObjConn As Connection

#End Region

#Region "FillMethod"


    Public Function SectionWiseEmp_Fill(ByVal iBranchSlno As Integer, ByVal iCourseSlno As Integer, ByVal iExamBranchSlno As Integer, ByVal iGroupSlno As Integer, ByVal iBatchslno As Integer, ByVal From As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            If From = "Section" Then
                ''''oCommand.CommandText = "SECTIONEMP_FETCH"
                oCommand.CommandText = "STUSECTION_FETCH"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "STUSUBSECTION_FETCH"
                '''oCommand.CommandText = "SUBSECTIONEMP_FETCH"
            End If

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


    Public Function Employee_Fetch(ByVal PStatus As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_EMP_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME IUSERID
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

#Region "SingleMode Methods"

    Public Function SectionEmp_Code(ByVal iCode As Integer, ByVal From As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "M_SECTIONEMP_FETCH"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "M_SUBSECTIONEMP_FETCH"
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

    Public Function SectionEmp_Update(ByVal PKeySlno As Integer, ByVal From As String, ByVal BranchSlno As Integer, ByVal CourseSlno As Integer, ByVal ExamBranchSlno As Integer, ByVal GroupSlno As Integer, ByVal BatchSlno As Integer, ByVal iSlno As Integer, ByVal EmpSlno As Integer, ByVal Descr As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "F_SECTIONEMP_UPDATE"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "F_SUBSECTIONEMP_UPDATE"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BCEGBSSLNO
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PKeySlno

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

            'ADD IN PARAMETER NAME SECTION SLNO or subsection slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSlno

            'ADD IN PARAMETER NAME Empslno
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EmpSlno

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

    Public Function SectionEmp_Insert(ByVal BranchSlno As Integer, ByVal From As String, ByVal CourseSlno As Integer, ByVal ExamBranchSlno As Integer, ByVal GroupSlno As Integer, ByVal BatchSlno As Integer, ByVal iSlno As Integer, ByVal EmpSlno As Integer, ByVal Descr As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "F_SECTIONEMP_INSERT"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "F_SUBSECTIONEMP_INSERT"
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
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSlno

            'ADD IN PARAMETER NAME EMPSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EmpSlno

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

    Public Function SectionEmp_Delete(ByVal PSlNo As String, ByVal From As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "Section" Then
                oCommand.CommandText = "F_SECTIONEMP_DELETE"
            ElseIf From = "SubSection" Then
                oCommand.CommandText = "F_SUBSECTIONEMP_DELETE"
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

    Public Function SectionEmp_BatchInsert(ByRef PDataSet As DataSet, ByVal From As String) As String
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
                Cmd.CommandText = "M_SECTIONEMP_BATCHINSERT"
            ElseIf From = "SubSection" Then
                Cmd.CommandText = " M_SUBSECTIONEMP_BATCHINSERT"
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

            'ADD IN PARAMETER NAME AS Section Cum Subsection
            oParameter = Cmd.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"


            'ADD IN PARAMETER NAME AS EMPSLNO
            oParameter = Cmd.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            'ADD IN PARAMETER NAME 
            oParameter = Cmd.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = Cmd
            adap.Update(PDataSet, "EMPLOYEE")
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



End Class
