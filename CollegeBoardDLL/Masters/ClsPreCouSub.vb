'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Previous Course Subjects
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 19-AUG-2006
'   FINAL BASELINE DATE               : 19-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsPreCouSub

#Region "Class Variables"

    Private oConn As OracleClient.OracleConnection
    Dim Con As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private OraTrans As OracleTransaction
    Private ObjConn As Connection

#End Region

#Region "DropDown Methods"

    Public Function PreCourseSubject_Fetch(ByVal PStatus As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_PRECOURSESUB_DRP"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
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

    Public Function Subject_Fetch(ByVal PStatus As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_SUBJECT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
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

    Public Function PreviousCourse_Fetch(ByVal PStatus As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_PRECOURSE_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
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

#Region "Previous Course"

    Public Function PrevioucCourseSubject_BatchInsert(ByRef PDataSet As DataSet) As String
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

            Cmd.CommandText = "M_BATCH_PRECOURSESUBJECT"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = Cmd.Parameters.Add("iPRECOUSUBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PVCOURSESLNO"

            'ADD IN PARAMETER NAME 
            oParameter = Cmd.Parameters.Add("iSUBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME 
            oParameter = Cmd.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAXMARKS"

            'ADD IN PARAMETER NAME 
            oParameter = Cmd.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = Cmd
            adap.Update(PDataSet, "PRECOUSUBJECT")
            OraTrans.Commit()
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1
    End Function

    Public Function PreviousCourseSub_Code(ByVal iCode As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_PRECOUSUB_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCode

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

    Public Function PreCouSubject_Update(ByVal PSlNo As Integer, ByVal preCouSlno As Integer, ByVal SubSlno As Integer, ByVal MaxMarks As Integer, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "F_UPDATE_PRECOUSUBJECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iPRECOURSESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = preCouSlno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubSlno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MaxMarks

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDescription

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

    Public Function PrevioucCourseSubject_Insert(ByVal PreCouSlno As Integer, ByVal SubjectSlno As Integer, ByVal MaxMarks As Integer, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "F_INSERT_PRECOUSUB"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iPRECOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PreCouSlno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubjectSlno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MaxMarks


            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDescription

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

    Public Function PrevioucCourseSubject_Delete(ByVal PSlNo As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "F_PRECOUSUBJECT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
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

    Public Function PreviousCourseSubject_Fetch(ByVal PStatus As String) As Data.DataSet

        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_PRECOURSESUB_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iStatus  'Either A-active
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME Cursor
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
