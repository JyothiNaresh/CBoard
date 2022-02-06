'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating SOCIETY
'   ACTIVITY                          : 
'   AUTHOR                            : G KISHORE
'   INITIAL BASELINE DATE             : 20-Julu-2012
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ProgramIC

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

#Region "PROG IC Methods"

    Public Function PRGIC_DELETE(ByVal pSLNO As Integer) As Integer
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

    Public Function PRGIC_Select(ByVal pSLNO As Integer) As DataSet
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

    Public Function PRGIC_Insert(ByVal Arr As ArrayList) As Integer
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

    Public Function PRGIC_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "PRGIC_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iPRGIC_NAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
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

#End Region

#Region "PROGIC MAPPING METHODS"

    Public Function PRGIC_MAP_Delete(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "PROGIC_MAP_EXAMBRANCHS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMREGIONSLNO"

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            adap.InsertCommand = oCommand
            adap.DeleteCommand = oCommand
            adap.Update(PDataSet, "PROGIC")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function PRGIC_MAP_Insert(ByRef PDataSet As DataSet) As String
        Try

            Dim adap As New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans

            oCommand.CommandText = "PROGIC_MAP_EXAMBRANCHS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMREGIONSLNO"

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "PROGIC")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

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

    Public Function PRGIC_MAP_EB_Insert(ByRef PDataSet As DataSet) As String
        Try

            Dim adap As New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans

            oCommand.CommandText = "PROGIC_MAP_EXAMBRANCHS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMREGIONSLNO"

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "PROGIC")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

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

    Public Function PRGIC_MAP_EB_Delete(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "PROGIC_MAP_EXAMBRANCHS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMREGIONSLNO"

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            adap.InsertCommand = oCommand
            adap.DeleteCommand = oCommand
            adap.Update(PDataSet, "PROGIC")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function PRGIC_MAP_COMB_Insert(ByRef PDataSet As DataSet) As String
        Try

            Dim adap As New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans

            oCommand.CommandText = " PROGIC_MAP_COMBINATIONS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMREGIONSLNO"

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "PROGIC")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

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

    Public Function PRGIC_MAP_COMB_Delete(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "PROGIC_MAP_COMBINATIONS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMREGIONSLNO"

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMBINATIONKEY"

            'ADD IN PARAMETER exam name
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            adap.InsertCommand = oCommand
            adap.DeleteCommand = oCommand
            adap.Update(PDataSet, "PROGIC")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function PRGIC_MAP_Update(ByRef PDataSet As DataSet) As String
        Try

            Dim adap As New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans

            oCommand.CommandText = "PROGIC_MAPP_EXAMBRANCHS_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMREGIONSLNO"

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "PROGIC_MAP_EB")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

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

    Public Function PRGIC_MAP_Update_null(ByRef EBNO As Integer)
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "PROGIC_MAPP_EB_UPDATE_NULL"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EBNO
            'oParameter.SourceColumn = "EXAMREGIONSLNO"

            'oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'adap.InsertCommand = oCommand
            'adap.Update(PDataSet, "PROGIC_MAP_EB")

            'oCommand.ExecuteNonQuery()

            'oTrans.Commit()

            'ReturnStr = 1

            'Return ReturnStr

            oCommand.ExecuteNonQuery()
            'Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function


    Public Function PRGIC_MAP_Delete_DG(ByRef E As Integer, ByVal ENO As Integer, ByVal CK As Integer, ByVal COMACD As Integer) As String

        Dim adap As New OracleDataAdapter
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "PROGIC_MAP_EB_DG_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = E

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ENO

            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CK

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACD

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function PRGIC_EB_Delete_DG(ByRef E As Integer, ByVal ENO As Integer, ByVal COMACD As Integer) As String

        Dim adap As New OracleDataAdapter
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "PROGIC_MAP_EBS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = E

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ENO

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACD

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function PRGIC_COMBS_Delete_DG(ByRef E As Integer, ByVal ENO As Integer, ByVal CK As Integer, ByVal COMACD As Integer) As String

        Dim adap As New OracleDataAdapter
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "PROGIC_MAP_COMBS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = E

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ENO

            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CK


            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACD

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function PRGIC_MAP_Select(ByRef E As Integer, ByVal ENO As Integer, ByVal CK As Integer, ByVal COMACD As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "PROGIC_MAP_EB__SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iEXAMREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = E

            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ENO

            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CK

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACD

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

#End Region

End Class
