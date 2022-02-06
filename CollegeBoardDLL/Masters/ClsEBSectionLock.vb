'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exam Branch Wise Locks
'   ACTIVITY                          : 
'   AUTHOR                            : G KISHORE
'   INITIAL BASELINE DATE             : 05-Nov-2012
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsEBSectionLock

#Region "Class Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection
    Private ReturnStr As String
#End Region

#Region "SECTIONS LOCKED Methods"

    Public Function SECLOCK_DELETE1(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "PRGIC_DELETE"
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

    Public Function SECLOCK_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "FDR_SELECT"
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

    Public Function SECLOCK_Insert11(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "PRGIC_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iPRGIC_NAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iEMPNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)


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

    Public Function SECLOCK_Update(ByVal pSLNO As Integer, ByVal pLOCK As String) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "EB_SEC_LOCK_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            oParameter = oCommand.Parameters.Add("iLOCK", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pLOCK


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

    Public Function SECLOCK_Insert(ByRef PDataSet As DataSet) As String
        Try

            Dim adap As New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans

            oCommand.CommandText = "EB_SECTIONS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"


            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "USERSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "EBSECLOCK")

            oTrans.Commit()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function SECLOCK_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "EB_SECTIONS_DELETE"
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

#End Region

End Class
