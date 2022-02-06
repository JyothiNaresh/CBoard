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

Public Class ClsCGWS

#Region "Class Variables"

    Private oConn As OracleClient.OracleConnection
    Dim Con As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private OraTrans As OracleTransaction
    Private ObjConn As Connection
    Private ReturnStr As String
    Private ReturnNum As Integer

#End Region

#Region "FillMethod"

    Public Function CWGROUP_FETCH(ByVal iCourseSlno) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_COURSEWISEGROUP_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

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
    Public Function CWGROUPGOVTEXAMS_FETCH(ByVal iCourseSlno) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_CGEWISEGOVTEXAMS_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER COURSE
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

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
    Public Function CWGROUPGOVTEXAMSUBJ_FETCH(ByVal iCourseSlno, ByVal iGroupSlno) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_CGEWISEGOVTSUBJECTS_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGroupSlno

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
    Public Function GovtSubjMap_Search(ByVal iCourseSlno As Integer, ByVal IGroupSlno As Integer, ByVal iEXAMSLNO As Integer) As DataSet
        Try
            Dim adap As New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "GOVTEXAM_CGSSEARCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'ADD IN PARAMETER NAME as Groupslno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IGroupSlno

            'ADD IN PARAMETER NAME as ExamSlNo
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMSLNO

            ''ADD IN PARAMETER NAME as SUBJECTSlNo
            'oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = iSUBJECTSLNO


            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = oCommand
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds
    End Function
    Public Function CGS_Search(ByVal iCourseSlno As Integer, ByVal IGroupSlno As Integer) As DataSet
        Try
            Dim adap As New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_CGSSEARCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME as CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'ADD IN PARAMETER NAME as Groupslno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IGroupSlno

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = oCommand
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds
    End Function

#End Region

#Region "Batch Mode Methods"


    Public Function CGSUBJECT_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim strReturn As String
        Dim pcourseslno As Integer
        Dim pgroupsLNo As Integer
        Dim psubject As Integer
        'Dim pRegionSLNo As Integer
        'Dim pAddressSLNo As Integer
        'Dim pName As String
        Dim pDescription As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans
            oCommand.CommandText = "M_INSERT_CGS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME Company slno
            oParameter = oCommand.Parameters.Add("isubjectSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME Zone SLNo
            oParameter = oCommand.Parameters.Add("icourseSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'ADD IN PARAMETER NAME Region slno
            oParameter = oCommand.Parameters.Add("igroupSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "BCS")

            OraTrans.Commit()
            strReturn = "0-SUCCESS"

        Catch ex As Exception

            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

#End Region

#Region "Single Mode Methods"


    Public Function CGS_Insert(ByVal pSUBJECTSLNO As Integer, ByVal pCOURSESLNO As Long, ByVal pGROUPSLNO As Long, ByVal pdescription As String) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_INSERT_CGS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME Company slno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO

            'ADD IN PARAMETER NAME Zone SLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSESLNO

            'ADD IN PARAMETER NAME Region slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGROUPSLNO

            ''ADD IN PARAMETER NAME 
            'oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = pName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdescription

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

    Public Function CGS_Update(ByVal PCGSSLNo As Long, ByVal PSUBJECTSLNO As Long, ByVal PCOURSESLNO As Long, ByVal PGROUPSLNO As Long, ByVal Pdescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "F_UPDATE_CGS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME Company slno
            oParameter = oCommand.Parameters.Add("iCGSSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCGSSLNo



            'ADD IN PARAMETER NAME Company slno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSUBJECTSLNO

            'ADD IN PARAMETER NAME Zone SLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOURSESLNO

            'ADD IN PARAMETER NAME Region slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PGROUPSLNO

            ''ADD IN PARAMETER NAME 
            'oParameter = oCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = pName

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pdescription


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            Return strReturn

        Catch ex As Exception
            Throw ex
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function CGWS_FetchBySLNo(ByVal pCGSSLNo As Integer, ByVal PStatus As String) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "M_CGWS_SELECT_CYSLNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME PLACE SLNO
            oParameter = oCommand.Parameters.Add("iCGSSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCGSSLNo

            'ADD IN PARAMETER NAME iStatus  'Either A-active
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "CGS")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function CGS_Delete(ByVal pCGSSLNo As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "F_CGS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBASLNo
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCGSSLNo

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

#Region "SubjectMapping"

    Public Function SUBJECTMAPPING_SEARCH(ByVal iSubjectSlno As Integer) As DataSet
        Try
            Dim adap As New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_SUBMAPSEARCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME as CourseSlno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSubjectSlno

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = oCommand
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds
    End Function

    Public Function SUBJECTMAP_InsertBatch(ByRef PDataSet As DataSet) As String
        Dim strReturn As String
        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans
            oCommand.CommandText = "M_SUBMAPINSERT_BATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME SUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME SUBJECTMAPSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTMAPSLNO"


            'ADD IN PARAMETER DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "SUBJECTMAPPING")

            OraTrans.Commit()
            strReturn = "0-SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function SUBJECTMAP_Insert(ByVal pSUBJECTSLNO As Integer, ByVal pSUBJECTMAPSLNO As Integer, ByVal pdescription As String) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "M_SUBMAPINSERT_BATCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME Company slno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO

            'ADD IN PARAMETER NAME Zone SLNo
            oParameter = oCommand.Parameters.Add("iSUBJECTMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTMAPSLNO


            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdescription

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

    Public Function SUBJECTMAP_Delete(ByVal pSLNo As Integer) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "SUBJECTMAPPING_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBASLNo
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNo

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

    Public Function SUBJECTMAP_Update(ByVal SLNO As Integer, ByVal pSUBJECTSLNO As Integer, ByVal pSUBJECTMAPSLNO As Integer, ByVal pDESCRIPTION As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "F_UPDATE_SUBJECTMAP"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME ESLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SLNO


            'ADD IN PARAMETER NAME SUBJECT slno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO

            'ADD IN PARAMETER NAME SUBJECT slno
            oParameter = oCommand.Parameters.Add("iSUBJECTMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTMAPSLNO

            'ADD IN PARAMETER NAME SUBJECT slno
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            Return strReturn

        Catch ex As Exception
            Throw ex
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function SUBJECTMAP_FetchBySLNo(ByVal pSLNO As Integer) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "M_SELECT_SLNO_SUBJECTMAP"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME PLACE SLNO
            oParameter = oCommand.Parameters.Add("iSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            ''ADD IN PARAMETER NAME iStatus  'Either A-active
            'oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PStatus

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "SUBJMAP")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

#End Region

#Region "GovtSubjMapping"

#Region "GovtSubjSingle"

    Public Function GovtSubjMap_Insert(ByVal pCOURSESLNO As Long, ByVal pGROUPSLNO As Long, ByVal pEXAMNAME As Long, ByVal pSUBJECTSLNO As Integer, ByVal pMAXMARKS As Integer, ByVal pMINMARKS As Integer) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_INSERT_GOVTEXAMSUB"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME Zone SLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSESLNO

            'ADD IN PARAMETER NAME Group slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGROUPSLNO

            'ADD IN PARAMETER NAME Exam Name
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

            'ADD IN PARAMETER NAME Group slno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMAXMARKS

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iMINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMINMARKS

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function GovtSubjMap_Update(ByVal ESLNO As Long, ByVal pCOURSESLNO As Long, ByVal pGROUPSLNO As Long, ByVal pEXAMNAME As Long, ByVal pSUBJECTSLNO As Integer, ByVal pMAXMARKS As Integer, ByVal pMINMARKS As Integer) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "F_UPDATE_GOVTEXAMSUBJ"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME ESLNO
            oParameter = oCommand.Parameters.Add("iEsSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ESLNO



            'ADD IN PARAMETER NAME COURSE SLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSESLNO

            'ADD IN PARAMETER NAME Group slno
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGROUPSLNO

            'ADD IN PARAMETER NAME Exam Name
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMNAME

            'ADD IN PARAMETER NAME Group slno
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMAXMARKS

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iMINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMINMARKS


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            Return strReturn

        Catch ex As Exception
            Throw ex
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function GovtSubjMap_FetchBySLNo(ByVal pEXAMSLNO As Integer) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "M_SELECT_ESLNO_GOVTEXAMSUBJ"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME PLACE SLNO
            oParameter = oCommand.Parameters.Add("iESLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            ''ADD IN PARAMETER NAME iStatus  'Either A-active
            'oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PStatus

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "GovtCGS")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function GovtSubjMap_Delete(ByVal pEXAMSLNO As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "F_DELETE_GOVTEXAMSUBJ"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBASLNo
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
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

#End Region

#Region "GovtSubjBatch"

    Public Function GovtSubj_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans
            oCommand.CommandText = "P_INSERT_GOVTEXAMSUB"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME exam name
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER subject
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME course
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'ADD IN PARAMETER NAME group
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'ADD IN PARAMETER NAME maxmarks
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAXMARKS"

            'ADD IN PARAMETER NAME minmarks
            oParameter = oCommand.Parameters.Add("iMINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINMARKS"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "BCS")

            OraTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            OraTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#End Region

End Class
