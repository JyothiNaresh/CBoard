Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsReservationStudents

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As New Data.DataSet
    Private ObjConn As Connection
#End Region

#Region "Single Mode Methods"

    Public Function ExamBranchWStudent_Delete(ByVal PSlNo As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "F_EXAM_EBSTUDENT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
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


    Public Function ExamBranchWStudent_Insert(ByVal dsResult As DataSet) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "M_EXAM_RESEBSTUDENT_INSERT"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS ADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RESSLNO"


            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(dsResult, "EBWS")

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function


    Public Function ExamBranchWStudent_Fetch(ByVal iCode As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "M_EXAM_RESEBSTUDENT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
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


    Public Function ExamBranchWStudent_Update(ByVal ADMSLNO As Integer, ByVal iExamBranchSlno As Integer) As String

        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            OraTrans = oConn.BeginTransaction
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ds = New Data.DataSet

            ''''''''''For Dummy Table Insertions
            ''''ExamBranchWStudent_DummyInsert(dsSet, oConn, OraTrans)


            strReturn = ExamBranchStu_Update(ADMSLNO, iExamBranchSlno, oConn, OraTrans)

            OraTrans.Commit()

        Catch ex As Exception
            Throw ex
            OraTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn

    End Function

    Private Function ExamBranchStu_Update(ByVal ADMSLNO As Integer, ByVal EBSlno As Integer, ByVal oConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Dim StrReturn As String

        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "F_EXAM_RESEBSTUDENT_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS Primary Key Slno
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EBSlno

            'ADD IN PARAMETER NAME AS Primary ADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ADMSLNO


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            StrReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        End Try

        Return StrReturn


    End Function


    
#End Region

#Region "Batch Mode Methods"

    Public Function FillDataset(ByVal pSqlString As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

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
            oAdapter.Fill(ds, "EBWS")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function ExamBranchWStudent_BatchInsert(ByRef PDataSet As DataSet) As String
        Dim adap As New OracleDataAdapter
        Dim Cmd As New OracleClient.OracleCommand
        Dim uCommand As New OracleClient.OracleCommand

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            OraTrans = oConn.BeginTransaction()

            Cmd.Transaction = OraTrans
            Cmd.CommandText = "M_EXAM_RESEBSTU_BATCHINSERT"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = OraTrans
            uCommand.CommandText = "P_EXAM_RESEBSTUDENT_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS COMACADMEICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'ADD IN PARAMETER NAME AS ADMSLNO
            oParameter = Cmd.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RESSLNO"

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            adap.InsertCommand = Cmd

            '''''''''UPDATEING'''''
            'ADD IN PARAMETER NAME AS COMACADMEICSLNO
            oParameter = uCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'ADD IN PARAMETER NAME AS ADMSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RESSLNO"

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = uCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            adap.UpdateCommand = uCommand
            adap.Update(PDataSet, "EBWS")
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

#Region "Search Criteria in Detail Page"


    Public Function EbStudent_Search(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand

            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim UserSlno As Integer
            Dim COMACADEMICSLNO As Integer

            strSplit = str.Split("~")

            AdmBranchSlno = strSplit(0)
            CourseSlno = strSplit(1)
            GroupSlno = strSplit(2)
            BatchSlno = strSplit(3)
            MediumSlno = strSplit(4)
            StuTypeSlno = strSplit(5)
            Gender = strSplit(6)
            ExamBranchSlno = strSplit(7)
            UserSlno = strSplit(8)
            COMACADEMICSLNO = strSplit(9)

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_RESEBSTUDENTSEARCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS ADMSLNO
            oParameter = Cmd.Parameters.Add("iADMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = AdmBranchSlno

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

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
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

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function

#End Region


End Class
