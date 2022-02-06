Imports System.IO
Imports System.Data
Imports System.Data.OracleClient
Public Class NewProcess

#Region " Class Variables "
    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ObjConn As Connection
    Private Dset As DataSet
    Private DsetStuflt As DataSet

#End Region

#Region "Update Status & Tracking Status"

    Public Sub Tracking(ByVal pUSERSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pACTION As String)

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "P_EXAMPRCACTION_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUSERSLNO


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iACTION", OracleType.VarChar, 500)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACTION

            oCommand.ExecuteNonQuery()


        Catch ex As Exception
        Finally
            oConn.Close()
        End Try

    End Sub

#End Region

#Region " Common Methods"

    Public Function GetCommDataSet(ByVal SqlStr As String) As DataSet
        'TAKEN FROM CLSRPTCOMBOBOXFILLING
        Try
            oAdapter = New OracleDataAdapter
            Dset = New DataSet

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
            oAdapter.Fill(Dset)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return Dset
    End Function

#End Region

#Region " Ranking "

    Public Function RanksFor(ByVal iDEXAMSLNO As Integer, ByVal iEXAMTYPE As String, ByVal iUSERSLNO As Integer) As String

        Try
            Tracking(iDEXAMSLNO, iUSERSLNO, "Ranking Started...!")
            Select Case iEXAMTYPE
                Case "IPE"
                    Ranking(iDEXAMSLNO, "EXAM_SUBJECTTOTAL_SELECT")
                    Ranking(iDEXAMSLNO, "EXAM_TRACKTOTAL_TEMP_SELECT")
                Case "EAMCET"
                    Ranking(iDEXAMSLNO, "ECET_SUBJECTTOTAL_SELECT")
                    Ranking(iDEXAMSLNO, "ECET_TRACKTOTAL_SELECT")
                Case "IIT"
                    Ranking(iDEXAMSLNO, "IIT_SUBJECTTOTAL_SELECT")
                    Ranking(iDEXAMSLNO, "IIT_TRACKTOTAL_SELECT")
                    Ranking(iDEXAMSLNO, "IIT_PAPERSUBJECTTOTAL_SELECT")
                    Ranking(iDEXAMSLNO, "IIT_PAPERTRACKTOTAL_SELECT")
            End Select
            Tracking(iUSERSLNO, iDEXAMSLNO, "Ranking Completed...!")
            Return "Ranking Successfully Completed...!!!"
        Catch ex As Exception
            Return "Problem with Ranking"
        End Try

    End Function

    Public Sub Ranking(ByVal iDEXAMSLNo As Integer, ByVal SelectSpname As String)
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = SelectSpname '"EXAM_TOTALONTRACK_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNo


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
        Finally
            oConn.Close()
        End Try

    End Sub

#End Region

#Region " Analysis "

    Private Function GetStuFilterinfo(ByVal iDEXAMSLNO As Integer) As String

        Dim SqlStr, FiltStr As String

        SqlStr = "SELECT FILTER FROM EXAM_RPT_COMB_STUFILT_MAP WHERE LENGTH(TRIM(FILTER))>0 AND DEXAMSLNO =  " & iDEXAMSLNO.ToString
        DsetStuflt = GetCommDataSet(SqlStr)
        For i As Integer = 0 To DsetStuflt.Tables(0).Rows.Count() - 1
            FiltStr += DsetStuflt.Tables(0).Rows(i)("FILTER") + " AND"
        Next
        FiltStr.TrimEnd("AND")


    End Function

    Public Sub PrepareData(ByVal iDEXAMSLNO As Integer, ByVal iEXAMTYPE As String, ByVal iUSERSLNO As Integer)

        Try
            Tracking(iDEXAMSLNO, iUSERSLNO, "Student Info Fetching Started...!")



            Tracking(iDEXAMSLNO, iUSERSLNO, "Student Info Fetching Completed...!")
        Catch ex As Exception

        End Try

    End Sub

#End Region


End Class
