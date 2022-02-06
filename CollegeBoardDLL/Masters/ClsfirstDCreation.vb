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

Public Class ClsfirstDCreation

#Region "Class Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As New Data.DataSet
    Private ObjConn As Connection
    Dim ReturnStr As String


#End Region

#Region "Exam Batch Mode Insertions"

    Public Function FirstDCreationsBatch_Insertions(ByRef PDataSet As DataSet, ByVal From As String) As String
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
            If From = "Caste" Then                    'For Section Master
                Cmd.CommandText = "M_BATCH_CASTE"
            ElseIf From = "Subsection" Then             'For Sub Section Master
                Cmd.CommandText = "M_BATCH_SUBSECTION"
            ElseIf From = "Subjects" Then               'For Subject Master
                Cmd.CommandText = "M_BATCH_SUBJECT"
            ElseIf From = "ExamTypes" Then              'For Exam Type Master
                Cmd.CommandText = "M_BATCH_EXAMTYPE"
            ElseIf From = "Tracks" Then                 'For Tracks Master
                Cmd.CommandText = "M_BATCH_TRACK"
            ElseIf From = "PreviousCourse" Then         'For Previous COurse Master
                Cmd.CommandText = "M_BATCH_PREVIOUSCOURSE"
                'MANI
            ElseIf From = "PreviousType" Then                    'For previous type Master
                Cmd.CommandText = "M_BATCH_PRETYPE"
            ElseIf From = "ExamSubBatch" Then
                Cmd.CommandText = "P_INSERT_EXAM_SUBBATCH"
            ElseIf From = "ExamUniversity" Then
                Cmd.CommandText = "P_INSERT_EXAM_UNIVERSITY"
            End If
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = Cmd.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'ADD IN PARAMETER NAME 
            oParameter = Cmd.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = Cmd
            adap.Update(PDataSet, "Client")
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

#Region "Caste Master"

    Public Function Caste_Fetch(ByVal PStatus As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_CASTE_SELECT_SLNO_NAME"
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

    Public Function Caste_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_INSERT_CASTE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

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


    Public Function Caste_Delete(ByVal PSlNo As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_CASTE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
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


    Public Function Caste_Update(ByVal PSlNo As String, ByVal PCode As String, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_CASTE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iID", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function CasteCode_Fetch(ByVal PCode As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_CASTE_SELECTCODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCode", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region "PreType Master"

    Public Function PreType_Fetch(ByVal PStatus As String) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_PRETYPE_SELECT_SLNO_NAME"
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

    Public Function PreType_Delete(ByVal PSlNo As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_PRETYPE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
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

    Public Function PRETYPE_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_INSERT_PRETYPE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

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

    Public Function PRETYPE_Update(ByVal PSlNo As String, ByVal PCode As String, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_PRETYPE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iID", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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

    Public Function PreviousTypeCode_Fetch(ByVal PCode As String) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_PREVIOUSTYPECODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCode", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region "Subsection Master"

    Public Function subSection_Fetch(ByVal PStatus As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_SUBSECTIONS_SELECT_SLNO_NAME"
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

    Public Function subSection_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_INSERT_SUBSECTION"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function subSection_Delete(ByVal PSlNo As String, ByVal PLogicalPhysical As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_SUBSECTION"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter Name
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo


            'Add In Parameter Name
            oParameter = oCommand.Parameters.Add("iDeleteFlag", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PLogicalPhysical

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

    Public Function subSection_Update(ByVal PSlNo As String, ByVal PCode As String, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_SUBSECTION"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iID", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function subSectionCode_Fetch(ByVal PCode As String) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_SUBSECTION_SUBSELECTCODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCode", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region "Subjects Master"


    Public Function Subjects_Fetch(ByVal PStatus As String) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_SUBJECT_SELECT_SLNO_NAME"
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


    Public Function subjects_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand.CommandText = "F_INSERT_SUBJECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function subjects_Delete(ByVal PSlNo As String, ByVal PLogicalPhysical As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_SUBJECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'Add IN Parameter
            oParameter = oCommand.Parameters.Add("iDeleteFlag", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PLogicalPhysical)

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


    Public Function subjects_Update(ByVal PSlNo As String, ByVal PCode As String, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_SUBJECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iID", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function subjectsCode_Fetch(ByVal PCode As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_SUBJECT_SUBJECTCODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCode", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region "Examtype Master"


    Public Function ExamTypes_Fetch(ByVal PStatus As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_EXAMTYPE_SELECT_SLNO_NAME"
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


    Public Function examType_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_INSERT_EXAMTYPE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function ExamTypes_Delete(ByVal PSlNo As String, ByVal PLogicalPhysical As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_EXAMTYPE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDeleteFlag", OracleType.Number, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PLogicalPhysical)

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


    Public Function examType_Update(ByVal PSlNo As String, ByVal PCode As String, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_EXAMTYPE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iID", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function examTypeCode_Fetch(ByVal PCode As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_EXAMTYPE_EXAMTYPECODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCode", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region "Tracks Master"


    Public Function Tracks_Fetch(ByVal PStatus As String) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_TRACKS_SELECT_SLNO_NAME"
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


    Public Function tracks_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_INSERT_TRACK"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function Tracks_Delete(ByVal PSlNo As String, ByVal PLogicalPhysical As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_TRACK"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDeleteFlag", OracleType.Number, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PLogicalPhysical)

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


    Public Function tracks_Update(ByVal PSlNo As String, ByVal PCode As String, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_TRACK"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iID", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function tracksCode_Fetch(ByVal PCode As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_TRACK_TRACKCODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCode", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region "Previous Course Master"


    Public Function PreviousCourse_Fetch(ByVal PStatus As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_PRECRSE_SELECT_SLNO_NAME"
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


    Public Function PreviousCourse_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_INSERT_PREVIOUSCOURSE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

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


    Public Function PreviousCourse_Delete(ByVal PSlNo As String, ByVal PLogicalPhysical As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_PREVIOUSCOURSE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDeleteFlag", OracleType.Number, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PLogicalPhysical)

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


    Public Function PreviousCourse_Update(ByVal PSlNo As String, ByVal PCode As String, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_PREVIOUSCOURSE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iID", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function PreviousCourseCode_Fetch(ByVal PCode As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_TRACK_PREVIOUSCOURSECODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCode", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region "Exam Type Wise Questions"


    Public Function Course_Fetch() As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "SP_COURSE_EXAM"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD OUT PARAMETER NAME IUSERID
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


    Public Function Subject_Fetch(ByVal iCourseslno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "SP_COURSESUBJECT_EXAM"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseslno

            'ADD OUT PARAMETER NAME IUSERID
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


    Public Function TopicsExam_Fetch(ByVal iCourseslno As Integer, ByVal iSubSlno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "SP_COURSESUBTOPIC_EXAM"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as Course slno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseslno

            'Add In Parameter as Subject slno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSubSlno

            'ADD OUT PARAMETER NAME IUSERID
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

#Region "ExamName Master"

    Public Function ExamName_Fetch(ByVal pSTATUS As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EXAMNAME_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTATUS

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


    Public Function ExamName_Insert(ByVal pEXAMNAME As String, ByVal pMAXMARKS As String, ByVal pQULMARKS As String, ByVal pDISCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EXAMNAME_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number, 3)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DBNull.Value

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iQULMARKS", OracleType.Number, 3)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DBNull.Value

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDISCRIPTION

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

    Public Function ExamName_Update(ByVal pEXAMSLNO As String, ByVal pEXAMNAME As String, ByVal pMAXMARKS As String, ByVal pQULMARKS As String, ByVal pDISCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EXAMNAME_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number, 3)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DBNull.Value

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iQULMARKS", OracleType.Number, 3)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DBNull.Value

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDISCRIPTION

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

    Public Function ExamName_Delete(ByVal pEXAMSLNO As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EXAMNAME_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

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

    Public Function ExamNameCode_Fetch(ByVal pEXAMSLNO As Integer) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EXAMNAME_SELECTCODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function ExamName_InsertBatch(ByVal PDataSet As DataSet) As String
        Dim strReturn As String
        Try
            'Dim OraTrans As OracleTransaction
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "EXAM_EXAMNAME_BATCHINSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number, 3)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAXMARKS"

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iQULMARKS", OracleType.Number, 3)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QULMARKS"

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(PDataSet, "Client")
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

#Region "Student HallTicket No"

    Public Function H_UserwiseExamBranch_Fill(ByVal pUSERID As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_USERWISEEXAMBRANCH_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iUSERID", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUSERID

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

    Public Function H_ExamBranchCourse_Fill(ByVal pBRANCHSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EBRANCH_COURSE_FILL"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBRANCHSLNO

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

    Public Function H_ExamBranchCourseSection_Fill(ByVal pBRANCHSLNO As Integer, ByVal pCOURSESLNO As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "HALLTICKET_SECTION_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBRANCHSLNO

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSESLNO

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

    Public Function H_ExamName_Fill(ByVal pSTATUS As Char) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "HALLTICKET_EXAMNAME_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTATUS

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

    Public Function HallTicket_Students_Fill(ByVal DsStudents As DataSet, ByVal pEXAMBRANCHSLNO As Integer, ByVal pCOURSESLNO As Integer, ByVal pSECTIONSLNO As Integer, ByVal pEXAMSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "HALLTICKET_STUDENTS_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSESLNO

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSECTIONSLNO

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME DATACUR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsStudents, "HallTicketNo")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return DsStudents
    End Function

    Public Function H_Students_Fill(ByVal pEXAMBRANCHSLNO As Integer, ByVal pCOURSESLNO As Integer, ByVal pSECTIONSLNO As Integer, ByVal pEXAMSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "H_STUDENTS_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSESLNO

            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSECTIONSLNO


            'ADD IN PARAMETER NAME AS iUSERID
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

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

    Public Function StudentHallTicket_Insert(ByVal PDataSet As DataSet) As String
        Dim strReturn As String
        Try
            Dim OraTrans As OracleTransaction
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            Dim UCommand As New OracleCommand

            'PDataSet.EnforceConstraints = False
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()

            oCommand.Transaction = OraTrans
            UCommand.Transaction = OraTrans

            oCommand.CommandText = "STUDENTHALLTICKET_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            UCommand.CommandText = "STUDENTHALLTICKET_UPDATE"
            UCommand.Connection = oConn
            UCommand.CommandType = CommandType.StoredProcedure

            '''INSERT ZONE

            'ADD IN PARAMETER NAME EXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME ADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'ADD IN PARAMETER NAME EXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER NAME APPLICATIONNO
            oParameter = oCommand.Parameters.Add("iAPPLICATIONNO", OracleType.Number, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "APPLICATIONNO"

            'ADD IN PARAMETER NAME HALLTICKETNO
            oParameter = oCommand.Parameters.Add("iHALLTICKETNO", OracleType.Number, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HALLTICKETNO"

            'ADD IN PARAMETER NAME REGNO
            oParameter = oCommand.Parameters.Add("iREGNO", OracleType.Number, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "REGNO"

            'ADD IN PARAMETER NAME TOTALMARKS
            oParameter = oCommand.Parameters.Add("iTOTMARKS", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOTALMARKS"

            'ADD IN PARAMETER NAME ISQUALIFY
            oParameter = oCommand.Parameters.Add("iISQUALIFY", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISQUALIFY"

            'ADD IN PARAMETER NAME REMARK
            oParameter = oCommand.Parameters.Add("iREMARK", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "REMARK"

            oAdapter.InsertCommand = oCommand

            '''UPDATE ZONE

            'ADD IN PARAMETER NAME EXAMBRANCHSLNO
            oParameter = UCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME ADMSLNO
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'ADD IN PARAMETER NAME EXAMSLNO
            oParameter = UCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER NAME APPLICATIONNO
            oParameter = UCommand.Parameters.Add("iAPPLICATIONNO", OracleType.Number, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "APPLICATIONNO"

            'ADD IN PARAMETER NAME HALLTICKETNO
            oParameter = UCommand.Parameters.Add("iHALLTICKETNO", OracleType.Number, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HALLTICKETNO"

            'ADD IN PARAMETER NAME REGNO
            oParameter = UCommand.Parameters.Add("iREGNO", OracleType.Number, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "REGNO"

            'ADD IN PARAMETER NAME TOTALMARKS
            oParameter = UCommand.Parameters.Add("iTOTMARKS", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOTALMARKS"

            'ADD IN PARAMETER NAME ISQUALIFY
            oParameter = UCommand.Parameters.Add("iISQUALIFY", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISQUALIFY"

            'ADD IN PARAMETER NAME REMARK
            oParameter = UCommand.Parameters.Add("iREMARK", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "REMARK"

            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(PDataSet, "HallTicketNo")
            OraTrans.Commit()
            Return 1

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

#End Region

#Region "ExamName"

    Public Function Exam_Details_Fetch(ByVal pSTATUS As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EXAMNAME_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTATUS

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
    Public Function ExammNameCode_Fetch(ByVal pEXAMSLNO As Integer) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAMNAME_SELECTCODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
    Public Function ExammName_Insert(ByVal pEXAMNAME As String, ByVal pDISCRIPTION As String, ByVal pEXAMTYPE As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAMNAME_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDISCRIPTION

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMTYPE

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
    Public Function ExammName_Delete(ByVal pEXAMSLNO As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAMNAME_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

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
    Public Function ExammName_Update(ByVal pEXAMSLNO As String, ByVal pEXAMNAME As String, ByVal pDISCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAMMNAME_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDISCRIPTION

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

    Public Function ExammName_InsertBatch(ByVal PDataSet As DataSet) As String
        Dim strReturn As String
        Try

            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "EXAMNAME_BATCHINSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DISCRIPTION"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(PDataSet, "Client")
            OraTrans.Commit()

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1
    End Function

    Public Function AccYCombiSave(ByVal iDset As DataSet, ByVal iCOMACADEMICSLNO As Integer) As String
        Try
            Dim UserSLNO As Integer

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            OraTrans = oConn.BeginTransaction()


            AccCombi_Delete(iCOMACADEMICSLNO, oConn, OraTrans)

            AccYCombi_Save(iDset, oConn, OraTrans)


            OraTrans.Commit()

            Return " Data Saved "

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Private Sub AccCombi_Delete(ByVal iCOMACADEMICSLNO As Integer, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction)
        Try

            oCommand = New OracleCommand("EXAM_ACCCOMBKEY_DELETE")
            oCommand.Connection = Conn
            oCommand.Transaction = Tran
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            oCommand.ExecuteNonQuery()

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AccYCombi_Save(ByVal iDset As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction)
        Try

            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand("EXAM_ACCCOMBKEY_INSERT")
            oCommand.Connection = Conn
            oCommand.Transaction = Tran
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(iDset, "ACCCOM")


        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "CExamName"
    Public Function CExam_Details_Fetch(ByVal pSTATUS As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "CEXAM_EXAMNAME_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTATUS

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

    Public Function CExamNameCode_Fetch(ByVal pEXAMSLNO As Integer) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "CEXAMNAME_SELECTCODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function CExamName_Insert(ByVal pEXAMNAME As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "CEXAMNAME_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

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

    Public Function CExamName_Update(ByVal pEXAMSLNO As String, ByVal pEXAMNAME As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "CEXAMMNAME_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

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

    Public Function CExamName_Delete(ByVal pEXAMSLNO As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "CEXAMNAME_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

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

    Public Function CExamName_InsertBatch(ByVal PDataSet As DataSet) As String
        Dim strReturn As String
        Try

            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "CEXAMNAME_BATCHINSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"


            oAdapter.InsertCommand = oCommand
            oAdapter.Update(PDataSet, "Client")
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

#Region "Subject Order"

    Public Function SUBJECTORDER_Fetch(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String) As DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = SpName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            oParameter = oCommand.Parameters.Add("DataCurMARORD", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Dset, DTable)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Dset
    End Function

    Public Function SUBmarksorder_update(ByVal Dsmarksorder As DataSet) As String
        Dim rtnString As String
        Try
            Dim OraTrans As OracleTransaction


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "STUDENTMARKS_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME SUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME REPORTORDER
            oParameter = oCommand.Parameters.Add("iREPORTORDER", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "REPORTORDER"

            'ADD IN PARAMETER NAME JRORDER
            oParameter = oCommand.Parameters.Add("iJRORDER", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "JRORDER"

            'ADD IN PARAMETER NAME SRORDER
            oParameter = oCommand.Parameters.Add("iSRORDER", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SRORDER"

            'ADD IN PARAMETER NAME SSCORDER
            oParameter = oCommand.Parameters.Add("iSSCORDER", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SSCORDER"

            ''ADD IN PARAMETER NAME ORDER1
            'oParameter = oCommand.Parameters.Add("iORDER1", OracleType.Number, 10)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "ORDER1"

            ''ADD IN PARAMETER NAME ORDER2
            'oParameter = oCommand.Parameters.Add("iORDER2", OracleType.Number, 10)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "ORDER2"

            ''ADD IN PARAMETER NAME ORDER3
            'oParameter = oCommand.Parameters.Add("iORDER3", OracleType.Number, 10)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "ORDER3"

            ''ADD IN PARAMETER NAME ORDER4
            'oParameter = oCommand.Parameters.Add("iORDER4", OracleType.Number, 10)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "ORDER4"

            ''ADD IN PARAMETER NAME ORDER5
            'oParameter = oCommand.Parameters.Add("iORDER5", OracleType.Number, 10)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "ORDER5"

            ''ADD IN PARAMETER NAME ORDER6
            'oParameter = oCommand.Parameters.Add("iORDER6", OracleType.Number, 10)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "ORDER6"

            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(Dsmarksorder, "SBJORDER")
            OraTrans.Commit()

            rtnString = "SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    Public Function splitorder_update(ByVal Dsmarksorder As DataSet) As String
        Dim rtnString As String
        Try
            Dim OraTrans As OracleTransaction


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "SPLITORDER_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME SUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iCATSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CATSLNO"

            'ADD IN PARAMETER NAME REPORTORDER
            oParameter = oCommand.Parameters.Add("iREPORTORDER", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "REPORTORDER"

            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(Dsmarksorder, "SPLITORDER")
            OraTrans.Commit()

            rtnString = "SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

#End Region

#Region "Exam SubBatch Master"


    Public Function ExamSubbatch_Fetch() As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_EXAM_SUBBATCH_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''ADD IN PARAMETER NAME IUSERID
            'oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Char, 1)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PSubbatchslno

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


    Public Function ExamSubbatch_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand.CommandText = "P_INSERT_EXAM_SUBBATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 25)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDescription

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function


    Public Function ExamSubbatch_Delete(ByVal pSUBBATCHSLNO As Integer) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_EXAM_SUBBATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBBATCHSLNO


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


    Public Function ExamSubbatch_Update(ByVal PSubbatchSlno As Integer, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_EXAM_SUBBATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSubbatchSlno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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


    Public Function ExamSubbatchCode_Select(ByVal PCode As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_SELECT_ESLNO_EXAM_SUBBATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region "Exam University Master"
    'written by y mahesh reddy
    Public Function ExamUniversity_Delete(ByVal pUNIVERSITYSLNO As Integer) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_EXAM_UNIVERSITY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUNIVERSITYSLNO


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

    Public Function ExamUniversity_Fetch() As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_EXAM_UNIVERSITY_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''ADD IN PARAMETER NAME IUSERID
            'oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Char, 1)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PSubbatchslno

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

    Public Function ExamUniversity_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand.CommandText = "P_INSERT_EXAM_UNIVERSITY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 25)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDescription

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function ExamUniversity_Update(ByVal PUNIVERSITYSlno As Integer, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_EXAM_UNIVERSITY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iUNIVERSITYSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PUNIVERSITYSlno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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

    Public Function ExamUniversityCode_Select(ByVal PCode As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_SELECT_ESLNO_EXAM_UNIVERSITY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iUNIVERSITYSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region "Exam Split Category And Range Master"
    'written by y mahesh reddy
    Public Function ExamSplitCategory_Delete(ByVal pUNIVERSITYSLNO As Integer) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_EXAM_UNIVERSITY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUNIVERSITYSLNO


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

    Public Function ExamSplitCategory_Fetch() As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_EXAM_UNIVERSITY_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''ADD IN PARAMETER NAME IUSERID
            'oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Char, 1)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PSubbatchslno

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

    Public Function ExamSplitCategory_Insert(ByVal PCategory As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand.CommandText = "P_INSERT_SPLITCATEGORY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iCATEGORY", OracleType.VarChar, 25)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCategory

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function ExamSplitCategory_Update(ByVal PCatSlno As Integer, ByVal PCategory As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_EXAM_SPLITCATEGORY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iUNIVERSITYSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCatSlno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCategory

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

    Public Function ExamSplitCategory_Select(ByVal PCode As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_SELECT_EXAM_SPLITCATEGORY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iUNIVERSITYSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function ExamSplitRange_Insert(ByVal pCOMBSLNO As Integer, ByVal pCATSLNO As Integer, ByVal pPERCENTAGE As Integer, ByVal pSTATUS As Char) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_INSERT_SPLITRANGES"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCOMBSLNO
            oParameter = oCommand.Parameters.Add("iCOMBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMBSLNO

            'ADD IN PARAMETER NAME iCATSLNO
            oParameter = oCommand.Parameters.Add("iCATSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCATSLNO

            'ADD IN PARAMETER NAME iPERCENTAGE
            oParameter = oCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pPERCENTAGE

            'ADD IN PARAMETER NAME Exam Name
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTATUS

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamSplitRange_Update(ByVal RSLNO As Long, ByVal pCOMBSLNO As Integer, ByVal pCATSLNO As Integer, ByVal pPERCENTAGE As Integer, ByVal pSTATUS As Char) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "F_UPDATE_SPLITRANGES"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME ESLNO
            oParameter = oCommand.Parameters.Add("iRSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = RSLNO



            'ADD IN PARAMETER NAME COURSE SLNo
            oParameter = oCommand.Parameters.Add("iCOMBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMBSLNO

            'ADD IN PARAMETER NAME Group slno
            oParameter = oCommand.Parameters.Add("iCATSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCATSLNO

            'ADD IN PARAMETER NAME Exam Name
            oParameter = oCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pPERCENTAGE

            'ADD IN PARAMETER NAME Group slno
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTATUS

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            Return strReturn

        Catch ex As Exception
            Throw ex
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamSplitRange_FetchBySLNo(ByVal pRSLNO As Integer) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "M_SELECT_RSLNO_SPLITRANGES"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME PLACE SLNO
            oParameter = oCommand.Parameters.Add("iRSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pRSLNO

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "SPLIT")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function ExamSplitRange_Delete(ByVal pRSLNO As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "F_DELETE_SPLITRANGES"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBASLNo
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pRSLNO

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

    Public Function ExamSplitRange_Fetch() As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_EXAM_SPLITRANGE_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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

#Region "Exam Special Batch Master"
    'written by y mahesh reddy
    Public Function ExamSplBatch_Delete(ByVal pSPLBATCHSLNO As Integer) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_DELETE_EXAM_SPLBATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSPLBATCHSLNO


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

    Public Function ExamSplBatch_Fetch() As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_EXAM_SPLBATCH_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''ADD IN PARAMETER NAME IUSERID
            'oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Char, 1)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PSubbatchslno

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

    Public Function ExamSplBatch_Insert(ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand.CommandText = "P_INSERT_EXAM_SPLBATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 25)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDescription

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function ExamSplBatch_Update(ByVal PSPLBATCHSlno As Integer, ByVal PName As String, ByVal PDescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_UPDATE_EXAM_SPLBATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSPLBATCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSPLBATCHSlno

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
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

    Public Function ExamSplBatchCode_Select(ByVal PCode As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_SELECT_ESLNO_EXAM_SPLBATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iSPLBATCHSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCode

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
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

#Region " Staff Exam Name"

    Public Function Staff_ENDetails_Fetch(ByVal pSTATUS As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "STAFF_EXAMNAME_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTATUS

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
    Public Function StaffENameCode_Fetch(ByVal pEXAMSLNO As Integer) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "STAFF_EXAMNAME_SELECTCODE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'oCommand.Parameters.Add(New OracleParameter("DataCur", OracleType.Cursor)).Direction = ParameterDirection.Output
            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
    Public Function Staff_ExammName_Insert(ByVal pEXAMNAME As String, ByVal pDISCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "STAFF_EXAMNAME_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDISCRIPTION

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
    Public Function Staff_ExammName_Delete(ByVal pEXAMSLNO As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "STAFF_EXAMNAME_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

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
    Public Function Staff_ExammName_Update(ByVal pEXAMSLNO As String, ByVal pEXAMNAME As String, ByVal pDISCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "STAFF_EXAMMNAME_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDISCRIPTION

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

    Public Function Staff_ExammName_InsertBatch(ByVal PDataSet As DataSet) As String
        Dim strReturn As String
        Try

            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "STAFF_EXAMNAME_BATCHINSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DISCRIPTION"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(PDataSet, "Client")
            OraTrans.Commit()

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1
    End Function

    Public Function Staff_AccYCombiSave(ByVal iDset As DataSet, ByVal iCOMACADEMICSLNO As Integer) As String
        Try
            Dim UserSLNO As Integer

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            OraTrans = oConn.BeginTransaction()


            Staff_AccCombi_Delete(iCOMACADEMICSLNO, oConn, OraTrans)

            Staff_AccYCombi_Save(iDset, oConn, OraTrans)


            OraTrans.Commit()

            Return " Data Saved "

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Private Sub Staff_AccCombi_Delete(ByVal iCOMACADEMICSLNO As Integer, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction)
        Try

            oCommand = New OracleCommand("STAFF_ACCCOMBKEY_DELETE")
            oCommand.Connection = Conn
            oCommand.Transaction = Tran
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            oCommand.ExecuteNonQuery()

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Staff_AccYCombi_Save(ByVal iDset As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction)
        Try

            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand("STAFF_ACCCOMBKEY_INSERT")
            oCommand.Connection = Conn
            oCommand.Transaction = Tran
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(iDset, "ACCCOM")


        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Course Wise Exams"

    Public Function E_CourseExam_Select(ByVal pEXAMTYPE As String) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "E_COUEXM_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMTYPE
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMTYPE

            'ADD OUT PARAMETER NAME DATACUR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

            Return ds

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function E_CourseExam_Insert(ByVal pEXAMTYPE As String, ByVal pCOURSEEXAM As String, ByVal pDISCRIPTION As String) As Byte
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "E_COUEXM_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iEXAMTYPE 
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMTYPE

            'ADD IN PARAMETER iCOURSEEXAM 
            oParameter = oCommand.Parameters.Add("iCOURSEEXAM", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSEEXAM

            'ADD IN PARAMETER iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDISCRIPTION

            oCommand.ExecuteNonQuery()
            OraTrans.Commit()
            Return 1

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function E_CourseExam_Update(ByVal pCREXSLNO As Integer, ByVal pEXAMTYPE As String, ByVal pCOURSEEXAM As String, ByVal pDESCRIPTION As String) As Byte

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "E_COUEXM_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iCREXSLNO  
            oParameter = oCommand.Parameters.Add("iCREXSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCREXSLNO

            'ADD IN PARAMETER iEXAMTYPE 
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMTYPE

            'ADD IN PARAMETER iCOURSEEXAM 
            oParameter = oCommand.Parameters.Add("iCOURSEEXAM", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSEEXAM

            'ADD IN PARAMETER iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            oCommand.ExecuteNonQuery()

            Return 1

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function E_CourseExam_Delete(ByVal pCREXSLNO As Integer) As Byte

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "E_COUEXM_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iCREXSLNO 
            oParameter = oCommand.Parameters.Add("iCREXSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCREXSLNO

            oCommand.ExecuteNonQuery()
            Return 1

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function E_CourseExamCombination_Update(ByVal pDS As DataSet) As Byte

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "E_COUEXMCOMB_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iSLNO  
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            'ADD IN PARAMETER iEXAMTYPE 
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPE"

            'ADD IN PARAMETER iCREXSLNO 
            oParameter = oCommand.Parameters.Add("iCREXSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CREXSLNO"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(pDS, "COUEXMCOMB")

            Return 1

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Parent Phone Followup"

    Public Function E_PARENT_PHONE_SAVE(ByVal pCOMACADEMICSLNO As Integer, ByVal pUNIQUENO As Integer, ByVal pPHONENO As String, ByVal pREMARKS As String, ByVal pFOLLOWUP As Integer, ByVal pUSERSLNO As Integer, ByVal pENTDATE As Date) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "E_PARENT_PHONE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER iUNIQUENO 
            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUNIQUENO

            'ADD IN PARAMETER iPHONENO
            oParameter = oCommand.Parameters.Add("iPHONENO", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pPHONENO

            'ADD IN PARAMETER iREMARKS
            oParameter = oCommand.Parameters.Add("iREMARKS", OracleType.VarChar, 4000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pREMARKS

            'ADD IN PARAMETER iFOLLOWUP     1.VC, 2.BRANCH, 3.ZONAL I/C
            oParameter = oCommand.Parameters.Add("iFOLLOWUP", OracleType.Number, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pFOLLOWUP

            'ADD IN PARAMETER iUSERSLNO     
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUSERSLNO

            'ADD IN PARAMETER iENTDATE     
            oParameter = oCommand.Parameters.Add("iENTDATE", OracleType.DateTime, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pENTDATE

            oCommand.ExecuteNonQuery()
            'OraTrans.Commit()
            strReturn = "Saved"

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

End Class
