'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : Preparing Data Set for Required Methods
'   ACTIVITY                          : 
'   AUTHOR                            : J.Himavantha Rao
'   INITIAL BASELINE DATE             : 25-OCT-2010
'   FINAL BASELINE DATE               : 
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------

Imports System.Data.OracleClient
Imports System.Configuration
Imports System.Data

Public Class ClsFillControls

#Region "Class Variables"

    Private oConn As OracleConnection
    Private oCommand As OracleCommand
    Private oParameter As OracleParameter
    Private oAdapter As OracleDataAdapter
    Private Ds As DataSet
    Private ObjConn As Connection

#End Region

#Region "ReportType Combobox Filling"

    Public Function ReportType_Fetch(ByVal PStatus As Integer) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            Ds = New DataSet

            oCommand.CommandText = "PREPNEW_REPTYPE_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function

    Public Function MainSelection_Fetch(ByVal PStatus As Integer) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            Ds = New DataSet

            oCommand.CommandText = "P_MAINSELECTION_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function

    Public Function FilterSelection_Fetch(ByVal pSlno As Integer) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            Ds = New DataSet

            oCommand.CommandText = "P_FILTERSELECTION_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds

    End Function


    Public Function Exam_UserWise_RepType(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer, ByVal pRepTypeslno As Integer) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "REPORT_USERWISE_RPTYPEFILL"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iRPTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pRepTypeslno

            'ADD IN PARAMETER NAME DATACUR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function GetCommDataSet(ByVal SqlStr As String) As DataSet
        'TAKEN FROM CLSRPTCOMBOBOXFILLING
        Try
            oAdapter = New OracleDataAdapter
            Ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oCommand.CommandText = "GETCOMMANDATASET"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("iSqlStr", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlStr

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Ds
    End Function

#End Region


End Class
