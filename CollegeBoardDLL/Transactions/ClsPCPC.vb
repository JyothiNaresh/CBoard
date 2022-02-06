'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Relation P.C.P.C
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 19-AUG-2006
'   FINAL BASELINE DATE               : 19-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsPCPC


#Region "Class Variables"
    Private oConn As OracleClient.OracleConnection
    Dim Con As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private OraTrans As OracleTransaction
    Dim ObjConn As Connection

#End Region

#Region "Single Mode Methods"


    Public Function PCPC_FetchBySLNo(ByVal PCPCSLNo As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "M_PCPC_SELECT_CYSLNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME PLACE SLNO
            oParameter = oCommand.Parameters.Add("iCPCSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCPCSLNo

            'ADD IN PARAMETER NAME iStatus  'Either A-active
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function PCPC_Insert(ByVal PCOURSESLNO As Long, ByVal PPVCOURSESLNO As Long, ByVal PRESLNO As Integer, ByVal Pdescription As String) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "F_INSERT_PCPC"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME CourseSlno
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOURSESLNO

            'ADD IN PARAMETER NAME Previous CourseSlno
            oParameter = oCommand.Parameters.Add("iPVCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PPVCOURSESLNO

            'ADD IN PARAMETER NAME Previous CourseSlno
            oParameter = oCommand.Parameters.Add("iPRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PRESLNO

            ', ByVal PRESLNO As Integer
            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pdescription

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


    Public Function PCPC_Update(ByVal PCPCSLNo As Long, ByVal PCOURSESLNO As Long, ByVal PPVCOURSESLNO As Long, ByVal PRESLNO As Integer, ByVal Pdescription As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "F_UPDATE_PCPC"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME Company slno
            oParameter = oCommand.Parameters.Add("iCPCSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCPCSLNo


            'ADD IN PARAMETER NAME Zone SLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOURSESLNO

            'ADD IN PARAMETER NAME Region slno
            oParameter = oCommand.Parameters.Add("iPVCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PPVCOURSESLNO

            'ADD IN PARAMETER NAME Previous CourseSlno
            oParameter = oCommand.Parameters.Add("iPRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PRESLNO

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
            '''Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function PCPC_Fetch(ByVal PStatus As String) As Data.DataSet

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "M_PCPC_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''ADD IN PARAMETER NAME PLACE SLNO
            'oParameter = oCommand.Parameters.Add("iCPCSLNo", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PCPCSLNo

            'ADD IN PARAMETER NAME iStatus  'Either A-active
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function PCPC_Delete(ByVal PCPCSLNo As Integer, ByVal pLogicalPhysical As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "F_DELETE_PCPC"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBASLNo
            oParameter = oCommand.Parameters.Add("iCPCSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCPCSLNo

            'ADD IN PARAMETER NAME iDeleteFlag
            oParameter = oCommand.Parameters.Add("iDeleteFlag", OracleType.Number, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(pLogicalPhysical)

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

#Region "Batch Mode Methods"

    Public Function CPC_InsertBatch(ByRef pDataSet As DataSet) As String

        Dim strReturn As String

        Dim adap As New OracleDataAdapter
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans
            oCommand.CommandText = "M_INSERTBATCH_CPC"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'ADD IN PARAMETER NAME PVCOURSESLNO
            oParameter = oCommand.Parameters.Add("iPVCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PVCOURSESLNO"

            'ADD IN PARAMETER NAME PVCOURSESLNO
            oParameter = oCommand.Parameters.Add("iPRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PRESLNO"

            'ADD IN PARAMETER iDescription
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = oCommand
            adap.Update(pDataSet, "PCPC")
            OraTrans.Commit()
            strReturn = "0-SUCCESS"

        Catch ex As Exception
            Throw ex
            OraTrans.Rollback()
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

#End Region

End Class
