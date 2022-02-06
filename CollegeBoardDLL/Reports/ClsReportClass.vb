'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Middle layer for Reports
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 14-NOV-2006
'   FINAL BASELINE DATE               : 08-NOV-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------

Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsReportClass

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private iCommand As OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As Data.DataSet
    Private oTrans As OracleTransaction
    Private Result As String
    Private ObjConn As ReportConnection

#End Region

#Region "Methods"


    Public Function GetResults(ByVal iDEXAMSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oConn.Open()
            oCommand = New OracleCommand
            oCommand.CommandText = "EXAMRESULTS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function


    Public Function GetExams() As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oConn.Open()
            oCommand = New OracleCommand
            oCommand.CommandText = "GETEXAMS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
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


    Public Function StuEnquiry_TxtRpt(ByVal iADMSLNO As Integer) As DataSet

        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oConn.Open()
            oCommand = New OracleCommand
            oCommand.CommandText = "TXTRPT_STUENQUIRY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function


    Public Function GetReportsData(ByVal iDEXAMSLNO As Integer, ByVal StrProName As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oConn.Open()
            oCommand = New OracleCommand
            '"ERRORSLIST" For Errors List
            '"QUESTIONPAPERWEIGHTAGE" For QUESTION PAPER WEIGHTAGE
            oCommand.CommandText = StrProName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME StDataCur This is For Students
            oParameter = oCommand.Parameters.Add("StDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME StDataCur This is For Correct,Worng and Unattempt
            oParameter = oCommand.Parameters.Add("CwuDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME StDataCur This is For ErrorsList
            oParameter = oCommand.Parameters.Add("ErDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function


    Public Function GetRanks(ByVal iDEXAMSLNO As Integer, ByVal StrProcedureText As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_RPTTRACKWISERANKS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME StDataCur This is For Students
            oParameter = oCommand.Parameters.Add("StDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME TRDataCur 
            oParameter = oCommand.Parameters.Add("TRDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME TRrDataCur 
            oParameter = oCommand.Parameters.Add("TRrDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iStrSql 
            oParameter = oCommand.Parameters.Add("iStrSql", OracleType.VarChar, 2000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StrProcedureText

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds
    End Function


    Public Function GetTempResults(ByVal iDEXAMSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "TEMPEXAMRESULTS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

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

#Region "Topper List"


    Public Function TxtToppersList(ByVal StrRank As String, ByVal CommonQuery As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .

            oCommand = New OracleCommand


            oCommand.CommandText = "EXAM_RPTTOPERSERANKS"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("StDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oParameter = oCommand.Parameters.Add("EXAMDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("StrRank", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StrRank

            oParameter = oCommand.Parameters.Add("StrRankDatCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DEXAMSLNODataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("CommonQuery", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CommonQuery

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

#Region "Subject Wise Totals"


    Public Function GetTempExams() As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "GETEXAMSTEMP"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
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


    Public Function GetTcTrSbTotal(ByVal iDEXAMSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_TPTRSUBTOTAL_SELECT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("TOPICDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("TRACKDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("SNDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Int32)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function

#End Region

#Region " Phone Nos "


    Public Function GetPhoneCount() As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "GETBPCOUNT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
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

#Region "CommFillMethods"

    'A.SURENDAR REDDY ON 01-FEB-2006
    Public Function GetCommDataSet(ByVal SqlStr As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

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
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds
    End Function



    Public Function GetSubTotalRank(ByVal iDTStudent As String, ByVal iDTTotal As String, ByVal iDTSubjects As String, ByVal iDTAvgRank As String, ByVal iDTESTAvgRank As String, ByVal iDtTotalStu As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .

            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_SUBTOTALRANK_SELECT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("SNDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("ARDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oParameter = oCommand.Parameters.Add("ESTARDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("ToTalStuDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("iDTStudent", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTStudent

            oParameter = oCommand.Parameters.Add("iDTTotal", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTTotal

            oParameter = oCommand.Parameters.Add("iDTSubjects", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTSubjects

            oParameter = oCommand.Parameters.Add("iDTAvgRank", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTAvgRank

            oParameter = oCommand.Parameters.Add("iDTESTAvgRank", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTESTAvgRank

            oParameter = oCommand.Parameters.Add("iDtTotalStu", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDtTotalStu

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function

    Public Function GetEnteredNotEntered(ByVal iDTStudent As String, ByVal iDTTotal As String, ByVal iDTSubjects As String, ByVal iDTAvgRank As String, ByVal iDTESTAvgRank As String, ByVal iDtNotEntered As String, ByVal iDtTotalStu As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .

            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_ENTEREDNOT_SELECT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("SNDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("ARDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oParameter = oCommand.Parameters.Add("ESTARDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("NOTEDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oParameter = oCommand.Parameters.Add("ToTalStuDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output



            oParameter = oCommand.Parameters.Add("iDTStudent", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTStudent

            oParameter = oCommand.Parameters.Add("iDTTotal", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTTotal

            oParameter = oCommand.Parameters.Add("iDTSubjects", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTSubjects

            oParameter = oCommand.Parameters.Add("iDTAvgRank", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTAvgRank

            oParameter = oCommand.Parameters.Add("iDTESTAvgRank", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTESTAvgRank

            oParameter = oCommand.Parameters.Add("iDtNotEntered", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDtNotEntered


            oParameter = oCommand.Parameters.Add("iDtTotalStu", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDtTotalStu

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function
    Public Function GetProgressReport(ByVal iDTStudent As String, ByVal iDTSubjects As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_PROGRESSPRT_SELECT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oParameter = oCommand.Parameters.Add("iDTStudent", OracleType.VarChar, 15000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTStudent


            oParameter = oCommand.Parameters.Add("iDTSubjects", OracleType.VarChar, 15000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTSubjects


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function


    Public Function GetReportData(ByVal iDTStudent As String, ByVal iDTSubjects As String, ByVal iDTDetails As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_RPTPREMKS_SELECT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oParameter = oCommand.Parameters.Add("DetailsDataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oParameter = oCommand.Parameters.Add("iDTStudent", OracleType.VarChar, 15000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTStudent


            oParameter = oCommand.Parameters.Add("iDTSubjects", OracleType.VarChar, 15000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTSubjects

            oParameter = oCommand.Parameters.Add("iDTDetails", OracleType.VarChar, 15000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDTDetails

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function

#End Region

#Region "Rrevious Course Marks Range"


    Public Function PcmRange_Select(ByVal dsRANGE As DataSet, ByVal DtTable As String, ByVal PRECOUTYPESLNO As Integer, ByVal RANGEFOR As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_MRKRANGE_SELECT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iPRECOUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PRECOUTYPESLNO

            oParameter = oCommand.Parameters.Add("iRANGEFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = RANGEFOR

            oParameter = oCommand.Parameters.Add("DataCur1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(dsRANGE, DtTable)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return dsRANGE

    End Function


    Public Function PcmRange_Save(ByVal dsRANGE As DataSet, ByVal DtTable As String) As String
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oTrans = oConn.BeginTransaction()
            oCommand = New OracleCommand
            iCommand = New OracleCommand


            iCommand.CommandText = "EXAM_MRKRANGE_INSERT"
            iCommand.CommandType = CommandType.StoredProcedure
            iCommand.Connection = oConn
            iCommand.Transaction = oTrans

            oCommand.CommandText = "EXAM_MRKRANGE_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = oTrans



            oParameter = iCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            oParameter = iCommand.Parameters.Add("iFROMNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FROMNO"

            oParameter = iCommand.Parameters.Add("iTONO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TONO"

            oParameter = iCommand.Parameters.Add("iPRECOUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PRECOUTYPESLNO"

            oParameter = iCommand.Parameters.Add("iRANGEFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANGEFOR"

            oParameter = iCommand.Parameters.Add("iACTIVE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACTIVE"

            oAdapter.InsertCommand = iCommand
            '---
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            oParameter = oCommand.Parameters.Add("iFROMNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FROMNO"

            oParameter = oCommand.Parameters.Add("iTONO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TONO"

            oParameter = oCommand.Parameters.Add("iPRECOUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PRECOUTYPESLNO"

            oParameter = oCommand.Parameters.Add("iRANGEFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANGEFOR"

            oParameter = oCommand.Parameters.Add("iACTIVE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACTIVE"

            oAdapter.UpdateCommand = oCommand


            oAdapter.Update(dsRANGE, DtTable)

            oTrans.Commit()
            Return " Data Saved "
        Catch OrEx As OracleException
            oTrans.Rollback()
            Throw OrEx
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try



    End Function


    Public Function PcmRangeAnl(ByVal iCOURSESLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

            oCommand.CommandText = "RPT_MRKSELECT_RANGE_ANALYSIS"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSESLNO

            oParameter = oCommand.Parameters.Add("DataCur1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur2", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur3", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output



            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()

        End Try

        Return ds

    End Function

#End Region

#Region " Course Marks Range "

    Public Function CMRange_Select(ByVal dsRANGE As DataSet, ByVal DtTable As String, ByVal COURSESLNO As Integer, ByVal RANGEFOR As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_CMRKR_SELECT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            oParameter = oCommand.Parameters.Add("iRANGEFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = RANGEFOR

            oParameter = oCommand.Parameters.Add("DataCur1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(dsRANGE, DtTable)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return dsRANGE

    End Function


    Public Function CMRange_Save(ByVal dsRANGE As DataSet, ByVal DtTable As String) As String
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oTrans = oConn.BeginTransaction()
            oCommand = New OracleCommand
            iCommand = New OracleCommand


            iCommand.CommandText = "EXAM_CMRKR_INSERT"
            iCommand.CommandType = CommandType.StoredProcedure
            iCommand.Connection = oConn
            iCommand.Transaction = oTrans

            oCommand.CommandText = "EXAM_CMRKR_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = oTrans



            oParameter = iCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            oParameter = iCommand.Parameters.Add("iFROMNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FROMNO"

            oParameter = iCommand.Parameters.Add("iTONO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TONO"

            oParameter = iCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            oParameter = iCommand.Parameters.Add("iRANGEFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANGEFOR"

            oParameter = iCommand.Parameters.Add("iACTIVE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACTIVE"

            oAdapter.InsertCommand = iCommand
            '---
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            oParameter = oCommand.Parameters.Add("iFROMNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FROMNO"

            oParameter = oCommand.Parameters.Add("iTONO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TONO"

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            oParameter = oCommand.Parameters.Add("iRANGEFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANGEFOR"

            oParameter = oCommand.Parameters.Add("iACTIVE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACTIVE"

            oAdapter.UpdateCommand = oCommand


            oAdapter.Update(dsRANGE, DtTable)

            oTrans.Commit()
            Return " Data Saved "
        Catch OrEx As OracleException
            oTrans.Rollback()
            Throw OrEx
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try



    End Function

#End Region

#Region "Result Module Marks Range"

    Public Function RmRange_Select(ByVal dsRANGE As DataSet, ByVal DtTable As String, ByVal PRECOUTYPESLNO As Integer, ByVal RANGEFOR As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

            oCommand.CommandText = "RESULT_MRKRANGE_SELECT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iPRECOUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PRECOUTYPESLNO

            oParameter = oCommand.Parameters.Add("iRANGEFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = RANGEFOR

            oParameter = oCommand.Parameters.Add("DataCur1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(dsRANGE, DtTable)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return dsRANGE

    End Function

    Public Function RmRange_Save(ByVal dsRANGE As DataSet, ByVal DtTable As String) As String
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oTrans = oConn.BeginTransaction()
            oCommand = New OracleCommand
            iCommand = New OracleCommand


            iCommand.CommandText = "RESULT_MRKRANGE_INSERT"
            iCommand.CommandType = CommandType.StoredProcedure
            iCommand.Connection = oConn
            iCommand.Transaction = oTrans

            oCommand.CommandText = "RESULT_MRKRANGE_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = oTrans



            oParameter = iCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            oParameter = iCommand.Parameters.Add("iFROMNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FROMNO"

            oParameter = iCommand.Parameters.Add("iTONO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TONO"

            oParameter = iCommand.Parameters.Add("iPRECOUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PRECOUTYPESLNO"

            oParameter = iCommand.Parameters.Add("iRANGEFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANGEFOR"

            oParameter = iCommand.Parameters.Add("iACTIVE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACTIVE"

            oAdapter.InsertCommand = iCommand
            '---
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            oParameter = oCommand.Parameters.Add("iFROMNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FROMNO"

            oParameter = oCommand.Parameters.Add("iTONO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TONO"

            oParameter = oCommand.Parameters.Add("iPRECOUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PRECOUTYPESLNO"

            oParameter = oCommand.Parameters.Add("iRANGEFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANGEFOR"

            oParameter = oCommand.Parameters.Add("iACTIVE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACTIVE"

            oAdapter.UpdateCommand = oCommand


            oAdapter.Update(dsRANGE, DtTable)

            oTrans.Commit()
            Return " Data Saved "
        Catch OrEx As OracleException
            oTrans.Rollback()
            Throw OrEx
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try



    End Function

    Public Function RmRangeAnl(ByVal iCOURSESLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection 'establishing the Connection .
            oCommand = New OracleCommand

            oCommand.CommandText = "RPT_MRKSELECT_RANGE_ANALYSIS"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSESLNO

            oParameter = oCommand.Parameters.Add("DataCur1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur2", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur3", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output



            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()

        End Try

        Return ds

    End Function

#End Region


End Class
